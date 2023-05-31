import math from 'mathjs-expression-parser';

import ISFGLState from './ISFGLState';
import ISFGLProgram from './ISFGLProgram';
import ISFBuffer from './ISFBuffer';
import ISFParser from './ISFParser';
import ISFTexture from './ISFTexture';
import LineMapper from './ISFLineMapper';

const DEBUG = false
const SAY = (m, e) => (DEBUG) ? console.log(`[ISFRenderer] ${m}`, e || '') : null
const mathJsEval = math.eval;

function ISFRenderer(ctx) {
  SAY('[ISFRenderer] constructor:', ctx)
  this.ctx = ctx;
  this.gl = ctx;
  this.uniforms = [];
  this.contextState = new ISFGLState(this.ctx);
  this.setupPaintToScreen();
  this.startTime = Date.now();
  this.lastRenderTime = Date.now();
  this.frameIndex = 0;
  this.parser = {};
}

ISFRenderer.prototype.loadSource = function loadSource(fragmentISF, vertexISFOpt) {
  SAY('[ISFRenderer] parsing shader...')
  this.parser = new ISFParser();
  this.parser.parse(fragmentISF, vertexISFOpt);
  this.sourceChanged(this.parser.fragmentShader, this.parser.vertexShader, this.parser);
};

ISFRenderer.prototype.sourceChanged = function sourceChanged(fragmentShader, vertexShader, model) {
  SAY('[ISFRenderer] source loading...')
  this.fragmentShader = fragmentShader;
  this.vertexShader = vertexShader;
  this.model = model;
  if (!this.model.valid) {
    this.valid = false;
    this.error = this.model.error;
    this.errorLine = this.model.errorLine;
    console.error(this.valid, this.error, this.errorLine);
    return;
  }
  try {
    this.valid = true;
    this.error = null;
    this.errorLine = null;
    this.setupGL();
    this.initUniforms();
    for (let i = 0; i < model.inputs.length; i++) {
      const input = model.inputs[i];
      if (input.DEFAULT !== undefined) {
        this.setValue(input.NAME, input.DEFAULT);
      }
    }
  } catch (e) {
    this.valid = false;
    this.error = e;
    this.errorLine = LineMapper(e, this.fragmentShader, this.model.rawFragmentShader);
  }
};

ISFRenderer.prototype.initUniforms = function initUniforms() {
  SAY('[ISFRenderer] initialising uniforms...')
  this.uniforms = this.findUniforms(this.fragmentShader);
  const inputs = this.model.inputs;
  for (let i = 0; i < inputs.length; ++i) {
    const input = inputs[i];
    const uniform = this.uniforms[input.NAME];
    if (!uniform) {
      continue;
    }
    uniform.value = this.model[input.NAME];
    if (uniform.type === 't') {
      uniform.texture = new ISFTexture({}, this.contextState);
    }
  }
  this.pushTextures();
};

ISFRenderer.prototype.setValue = function setValue(name, value) {
  // SAY(`[ISFRenderer] setting value... "${name}" ${value}`)
  this.program.use();

  const uniform = this.uniforms[name];
  if (!uniform) {
    console.error(`No uniform named ${name}`);
    return;
  }
  uniform.value = value;
  if (uniform.type === 't') {
    uniform.textureLoaded = false;
  }
  this.pushUniform(uniform);
};

ISFRenderer.prototype.getValue = function getValue(name) {
  return this.uniforms[name];
};

ISFRenderer.prototype.setNormalizedValue = function setNormalizedValue(name, normalizedValue) {
  SAY(`[ISFRenderer] setting normalized value... "${name}" ${normalizedValue}`)
  const inputs = this.model.inputs;
  let input = null;
  for (let i = 0; i < inputs.length; i++) {
    const thisInput = inputs[i];
    if (thisInput.NAME === name) {
      input = thisInput;
      break;
    }
  }
  if (input && input.MIN !== undefined && input.MAX !== undefined) {
    this.setValue(name, input.MIN + (input.MAX - input.MIN) * normalizedValue);
  } else {
    SAY('Trying to set normalized value without MIN and MAX input', name, input);
  }
};

ISFRenderer.prototype.setupPaintToScreen = function setupPaintToScreen() {
  SAY(`[ISFRenderer] setting up painting to screen...`, this)
  this.paintProgram = new ISFGLProgram(this.ctx, this.basicVertexShader, this.basicFragmentShader);
  return this.paintProgram.bindVertices();
};

ISFRenderer.prototype.setupGL = function setupGL() {
  SAY(`[ISFRenderer] setting up ISFGLProgram...`)
  this.cleanup();
  this.program = new ISFGLProgram(this.ctx, this.vertexShader, this.fragmentShader);
  this.program.bindVertices();
  this.generatePersistentBuffers();
};

ISFRenderer.prototype.generatePersistentBuffers = function generatePersistentBuffers() {
  SAY(`[ISFRenderer] generating persistent buffers...`)
  this.renderBuffers = [];
  const passes = this.model.passes;
  for (let i = 0; i < passes.length; ++i) {
    const pass = passes[i];
    const buffer = new ISFBuffer(pass, this.contextState);
    pass.buffer = buffer;
    this.renderBuffers.push(buffer);
  }
};

ISFRenderer.prototype.paintToScreen = function paintToScreen(destination, target) {
  SAY(`[ISFRenderer] painting to screen...`)
  this.paintProgram.use();
  this.ctx.bindFramebuffer(this.ctx.FRAMEBUFFER, null);
  this.ctx.viewport(0, 0, destination.width, destination.height);
  const loc = this.paintProgram.getUniformLocation('tex');
  target.readTexture().bind(loc);
  this.ctx.drawArrays(this.ctx.TRIANGLES, 0, 6);
  this.program.use();
};

ISFRenderer.prototype.pushTextures = function pushTextures() {
  SAY(`[ISFRenderer] push textures...`)
  Object.keys(this.uniforms).forEach((u) => {
    const uniform = this.uniforms[u];
    if (uniform.type === 't') this.pushTexture(uniform);
  });
};

ISFRenderer.prototype.pushTexture = function pushTexture(uniform) {
  // SAY(`[ISFRenderer] push texture (single)...`)
  if (!uniform.value) {
    return;
  }

  if (
    uniform.value.constructor.name !== 'OffscreenCanvas' &&
    (
      uniform.value.tagName !== 'CANVAS' &&
      !uniform.value.complete &&
      uniform.value.readyState !== 4)
    ) {
    return;
  }

  const loc = this.program.getUniformLocation(uniform.name);
  uniform.texture.bind(loc);
  this.ctx.texImage2D(
    this.ctx.TEXTURE_2D, 0, this.ctx.RGBA, this.ctx.RGBA, this.ctx.UNSIGNED_BYTE, uniform.value);
  if (!uniform.textureLoaded) {
    const img = uniform.value;
    uniform.textureLoaded = true;
    const w = img.naturalWidth || img.width || img.videoWidth;
    const h = img.naturalHeight || img.height || img.videoHeight;
    this.setValue(`_${uniform.name}_imgSize`, [w, h]);
    this.setValue(`_${uniform.name}_imgRect`, [0, 0, 1, 1]);
    this.setValue(`_${uniform.name}_flip`, false);
  }
};

ISFRenderer.prototype.pushUniforms = function pushUniforms() {
  SAY(`[ISFRenderer] push uniforms...`)
  for (const uniform of this.uniforms) {
    this.pushUniform(uniform);
  }
};

ISFRenderer.prototype.pushUniform = function pushUniform(uniform) {
  // SAY(`[ISFRenderer] push uniform (single)...`)
  const loc = this.program.getUniformLocation(uniform.name);
  if (loc !== -1) {
    if (uniform.type === 't') {
      this.pushTexture(uniform);
      return;
    }
    const v = uniform.value;
    switch (uniform.type) {
      case 'f':
        this.ctx.uniform1f(loc, v);
        break;
      case 'v2':
        this.ctx.uniform2f(loc, v[0], v[1]);
        break;
      case 'v3':
        this.ctx.uniform3f(loc, v[0], v[1], v[2]);
        break;
      case 'v4':
        this.ctx.uniform4f(loc, v[0], v[1], v[2], v[3]);
        break;
      case 'i':
        this.ctx.uniform1i(loc, v);
        break;
      case 'color':
        this.ctx.uniform4f(loc, v[0], v[1], v[2], v[3]);
        break;
      default:
        SAY(`Unknown type for uniform setting ${uniform.type}`, uniform);
        break;
    }
  }
};

ISFRenderer.prototype.findUniforms = function findUniforms(shader) {
  SAY(`[ISFRenderer] find uniform... `)
  const lines = shader.split('\n');
  const uniforms = {};
  const len = lines.length;
  for (let i = 0; i < len; ++i) {
    const line = lines[i].trim();
    if (line.indexOf('uniform') === 0) {
      const tokens = line.split(' ');
      const name = tokens[2].substring(0, tokens[2].length - 1);
      const uniform = this.typeToUniform(tokens[1]);
      uniform.name = name;
      uniforms[name] = uniform;
    }
  }
  return uniforms;
};

ISFRenderer.prototype.typeToUniform = function typeToUniform(type) {
  switch (type) {
    case 'float':
      return {
        type: 'f',
        value: 0,
      };
    case 'vec2':
      return {
        type: 'v2',
        value: [0, 0],
      };
    case 'vec3':
      return {
        type: 'v3',
        value: [0, 0, 0],
      };
    case 'vec4':
      return {
        type: 'v4',
        value: [0, 0, 0, 0],
      };
    case 'bool':
      return {
        type: 'i',
        value: 0,
      };
    case 'int':
      return {
        type: 'i',
        value: 0,
      };
    case 'color':
      return {
        type: 'v4',
        value: [0, 0, 0, 0],
      };
    case 'point2D':
      return {
        type: 'v2',
        value: [0, 0],
        isPoint: true,
      };
    case 'sampler2D':
      return {
        type: 't',
        value: {
          complete: false,
          readyState: 0,
        },
        texture: null,
        textureUnit: null,
      };
    default:
      throw new Error(`Unknown uniform type in ISFRenderer.typeToUniform: ${type}`);
  }
};

ISFRenderer.prototype.setDateUniforms = function setDateUniforms() {
  const now = Date.now();
  this.setValue('TIME', (now - this.startTime) / 1000);
  this.setValue('TIMEDELTA', (now - this.lastRenderTime) / 1000);
  this.setValue('FRAMEINDEX', this.frameIndex++);
  const date = new Date();
  this.setValue('DATE', [date.getFullYear(), date.getMonth() + 1, date.getDate(), date.getHours() * 3600 + date.getMinutes() * 60 + date.getSeconds()]);
  this.lastRenderTime = now;
};

ISFRenderer.prototype.draw = function draw(destination) {
  this.contextState.reset();
  this.program.use();
  this.setDateUniforms();

  const buffers = this.renderBuffers;
  for (let i = 0; i < buffers.length; ++i) {
    const buffer = buffers[i];
    const readTexture = buffer.readTexture();
    const loc = this.program.getUniformLocation(buffer.name);
    readTexture.bind(loc);
    if (buffer.name) {
      this.setValue(`_${buffer.name}_imgSize`, [buffer.width, buffer.height]);
      this.setValue(`_${buffer.name}_imgRect`, [0, 0, 1, 1]);
      this.setValue(`_${buffer.name}_flip`, false);
    }
  }
  let lastTarget = null;
  const passes = this.model.passes;
  for (let i = 0; i < passes.length; ++i) {
    const pass = passes[i];
    this.setValue('PASSINDEX', i);
    const buffer = pass.buffer;
    if (pass.target) {
      const w = this.evaluateSize(destination, pass.width);
      const h = this.evaluateSize(destination, pass.height);
      buffer.setSize(w, h);
      const writeTexture = buffer.writeTexture();
      this.ctx.bindFramebuffer(this.ctx.FRAMEBUFFER, buffer.fbo);
      this.ctx.framebufferTexture2D(
        this.ctx.FRAMEBUFFER,
        this.ctx.COLOR_ATTACHMENT0,
        this.ctx.TEXTURE_2D,
        writeTexture.texture,
        0);
      this.setValue('RENDERSIZE', [buffer.width, buffer.height]);
      lastTarget = buffer;
      this.ctx.viewport(0, 0, w, h);
    } else {
      const renderWidth = destination.width;
      const renderHeight = destination.height;
      this.ctx.bindTexture(this.ctx.TEXTURE_2D, null);
      this.ctx.bindFramebuffer(this.ctx.FRAMEBUFFER, null);
      this.setValue('RENDERSIZE', [renderWidth, renderHeight]);
      lastTarget = null;
      this.ctx.viewport(0, 0, renderWidth, renderHeight);
    }
    this.ctx.drawArrays(this.ctx.TRIANGLES, 0, 6);
    this.ctx.bindTexture(this.ctx.TEXTURE_2D, null);
    this.ctx.bindFramebuffer(this.ctx.FRAMEBUFFER, null);
  }

  for (let i = 0; i < buffers.length; ++i) {
    buffers[i].flip();
  }
  if (lastTarget) {
    this.paintToScreen(destination, lastTarget);
  }
};

ISFRenderer.prototype.evaluateSize = function evaluateSize(destination, formula) {
  formula += '';
  let s = formula.replace('$WIDTH', destination?.offsetWidth || destination?.width).replace('$HEIGHT', destination?.offsetHeight || destination?.height);
  for (const name in this.uniforms) {
    if ({}.hasOwnProperty.call(this.uniforms, name)) {
      const uniform = this.uniforms[name];
      s = s.replace(`$${name}`, uniform.value);
    }
  }

  return mathJsEval(s);
};

ISFRenderer.prototype.cleanup = function cleanup() {
  SAY(`[ISFRenderer] cleaning up...`)
  this.contextState.reset();
  if (this.renderBuffers) {
    for (let i = 0; i < this.renderBuffers.length; ++i) {
      this.renderBuffers[i].destroy();
    }
  }
};

ISFRenderer.prototype.basicVertexShader = "precision mediump float;\nprecision mediump int;\nattribute vec2 isf_position; // -1..1\nvarying vec2 texCoord;\n\nvoid main(void) {\n  // Since webctx doesn't support ftransform, we do this by hand.\n  gl_Position = vec4(isf_position, 0, 1);\n  texCoord = isf_position;\n}\n";

ISFRenderer.prototype.basicFragmentShader = 'precision mediump float;\nuniform sampler2D tex;\nvarying vec2 texCoord;\nvoid main()\n{\n  gl_FragColor = texture2D(tex, texCoord * 0.5 + 0.5);\n  //gl_FragColor = vec4(texCoord.x);\n}';

export default ISFRenderer;
