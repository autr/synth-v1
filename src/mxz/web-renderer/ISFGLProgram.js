function ISFGLProgram(gl, vs, fs) {
  console.log('HELLO', gl)
  this.gl = gl;
  console.log('🚨 shaders:', this.gl.VERTEX_SHADER)
  this.vShader = this.createShader(vs, this.gl.VERTEX_SHADER);
  this.fShader = this.createShader(fs, this.gl.FRAGMENT_SHADER);
  this.program = this.createProgram(this.vShader, this.fShader);
  this.locations = {};
}

ISFGLProgram.prototype.use = function glProgramUse() {
  try {
    this.gl.useProgram(this.program);
  } catch(err) {
    console.error(err)
    console.error(this.gl.getError())
  }
};

ISFGLProgram.prototype.getUniformLocation = function getUniformLocation(name) {
  return this.gl.getUniformLocation(this.program, name);
};

ISFGLProgram.prototype.bindVertices = function bindVertices() {
  this.use();
  const positionLocation = this.gl.getAttribLocation(this.program, 'isf_position');
  this.buffer = this.gl.createBuffer();
  this.gl.bindBuffer(this.gl.ARRAY_BUFFER, this.buffer);
  const vertexArray = new Float32Array(
    [-1.0, -1.0, 1.0,
      -1.0, -1.0, 1.0,
      -1.0, 1.0, 1.0,
      -1.0, 1.0, 1.0]);
  this.gl.bufferData(this.gl.ARRAY_BUFFER, vertexArray, this.gl.STATIC_DRAW);
  this.gl.enableVertexAttribArray(positionLocation);
  this.gl.vertexAttribPointer(positionLocation, 2, this.gl.FLOAT, false, 0, 0);
};

ISFGLProgram.prototype.cleanup = function cleanup() {
  this.gl.deleteShader(this.fShader);
  this.gl.deleteShader(this.vShader);
  this.gl.deleteProgram(this.program);
  this.gl.deleteBuffer(this.buffer);
};

ISFGLProgram.prototype.createShader = function createShader(src, type) {
  const shader = this.gl.createShader(type);
  this.gl.shaderSource(shader, src);
  this.gl.compileShader(shader);
  const compiled = this.gl.getShaderParameter(shader, this.gl.COMPILE_STATUS);
  window.shaderSrc = src
  console.log('🚨 compiled:', compiled, this.gl.getShaderInfoLog(shader))
  if (!compiled) {
    const lastError = this.gl.getShaderInfoLog(shader);
    const lookup = src.split('\n')
    console.log(lastError)
    lastError.split('\n').forEach(line => {
      line = line.substring(9)
      const num = parseInt(line.split(':')?.[0] || 0)
      const msg = line.split(':')?.[1] || 'N/A'
      console.error(`${msg} ${line.split(':')?.[2]}`)
      let txt = ''
      for ( let i = num - 1; i < num + 1; i++) {
        txt += `${i}: ${lookup[i].replaceAll('\t','').replaceAll('\n','')}\n`
      }
      console.log(txt)

    })
    throw new Error({
      message: lastError,
      type: 'shader',
    });
  }
  return shader;
};

ISFGLProgram.prototype.createProgram = function createProgram(vShader, fShader) {
  const program = this.gl.createProgram();
  this.gl.attachShader(program, vShader);
  this.gl.attachShader(program, fShader);
  this.gl.linkProgram(program);
  const linked = this.gl.getProgramParameter(program, this.gl.LINK_STATUS);
  if (!linked) {
    const lastError = this.gl.getProgramInfoLog(program);
    console.log('Error in program linking', lastError);
    throw new Error({
      message: lastError,
      type: 'program',
    });
  }
  return program;
};


export default ISFGLProgram;
