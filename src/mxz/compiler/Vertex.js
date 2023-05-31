
const INIT = 'isf_vertShaderInit();'

// isf_position // -1..1
const alias = {
  texcoord: 'isf_FragNormCoord', // 0..1
  width: 'RENDERSIZE.x'
}


export const VTX_DEFAULT = `

varying vec2 VTC_11;
varying vec2 VTC_00;
varying vec2 VTC_02;
varying vec2 VTC_20;
varying vec2 VTC_22;

void main() {
  ${INIT}

  VTC_11 = ${alias.texcoord};
  VTC_00 = ${alias.texcoord} + vec2(-${alias.width}, -${alias.width});
  VTC_02 = ${alias.texcoord} + vec2( ${alias.width}, -${alias.width});
  VTC_20 = ${alias.texcoord} + vec2( ${alias.width},  ${alias.width});
  VTC_22 = ${alias.texcoord} + vec2(-${alias.width},  ${alias.width});
}`;


var HEADER = `
    /*
    precision mediump float;
    attribute vec2 position; // isf_fragCoord
    attribute vec2 texcoord; // isf_FragNormCoord

    uniform vec2 resolution;
    uniform float ${alias.width};
    */
    
`


var VERT_DIAG5 = `
    ${HEADER}

    varying vec2 VTC_11;
    varying vec2 VTC_00;
    varying vec2 VTC_02;
    varying vec2 VTC_20;
    varying vec2 VTC_22;

    void main() {
        ${INIT}

        VTC_11 = ${alias.texcoord};
        VTC_00 = ${alias.texcoord} + vec2(-${alias.width}, -${alias.width});
        VTC_02 = ${alias.texcoord} + vec2( ${alias.width}, -${alias.width});
        VTC_20 = ${alias.texcoord} + vec2( ${alias.width},  ${alias.width});
        VTC_22 = ${alias.texcoord} + vec2(-${alias.width},  ${alias.width});
    }`;

var VERT_PASS = `
    ${HEADER}

    varying vec2 v_texcoord;

    void main() {

        v_texcoord = ${alias.texcoord};
    }`;


var VERT_BOX8 = `
    ${HEADER}

    varying vec2 VTC_00;
    varying vec2 VTC_01;
    varying vec2 VTC_02;
    varying vec2 VTC_10;
    varying vec2 VTC_12;
    varying vec2 VTC_20;
    varying vec2 VTC_21;
    varying vec2 VTC_22;

    void main() {
        ${INIT}

    
        VTC_00 = ${alias.texcoord} + vec2(-${alias.width}, -${alias.width});
        VTC_01 = ${alias.texcoord} + vec2( 0,       -${alias.width});
        VTC_02 = ${alias.texcoord} + vec2( ${alias.width}, -${alias.width});
        VTC_10 = ${alias.texcoord} + vec2(-${alias.width},  0);
        VTC_12 = ${alias.texcoord} + vec2( ${alias.width},  0);
        VTC_20 = ${alias.texcoord} + vec2(-${alias.width},  ${alias.width});
        VTC_21 = ${alias.texcoord} + vec2( 0,        ${alias.width});
        VTC_22 = ${alias.texcoord} + vec2( ${alias.width},  ${alias.width});
    }`;

var cross5VertexShaderSrc = `
    ${HEADER}

    varying vec2 VTC_01;
    varying vec2 VTC_10;
    varying vec2 VTC_11;
    varying vec2 VTC_12;
    varying vec2 VTC_21;

    void main() {
        ${INIT}

        VTC_01 = ${alias.texcoord} + vec2(0, -${alias.width});
        VTC_10 = ${alias.texcoord} + vec2(-${alias.width}, 0);
        VTC_11 = ${alias.texcoord};
        VTC_12 = ${alias.texcoord} + vec2(${alias.width}, 0);
        VTC_21 = ${alias.texcoord} + vec2(0, ${alias.width});
    }`;

var VERT_EMBOSS = `
    ${HEADER}

    varying vec2 VTC_00;
    varying vec2 VTC_01;
    varying vec2 VTC_02;
    varying vec2 VTC_10;
    varying vec2 VTC_12;
    varying vec2 VTC_20;
    varying vec2 VTC_21;
    varying vec2 VTC_22;

    void main() {
        ${INIT}
        
        VTC_00 = ${alias.texcoord} + vec2(-${alias.width} - 0.01, -${alias.width} - 0.01);
        VTC_01 = ${alias.texcoord} + vec2( 0, -${alias.width} - 0.01);
        VTC_02 = ${alias.texcoord} + vec2( ${alias.width} + 0.01, -${alias.width} - 0.01);
        VTC_10 = ${alias.texcoord} + vec2(-${alias.width} - 0.01,  0);
        VTC_12 = ${alias.texcoord} + vec2( ${alias.width} + 0.01,  0);
        VTC_20 = ${alias.texcoord} + vec2(-${alias.width} - 0.01,  ${alias.width} + 0.01);
        VTC_21 = ${alias.texcoord} + vec2( 0, ${alias.width} + 0.01);
        VTC_22 = ${alias.texcoord} + vec2( ${alias.width} + 0.01,  ${alias.width} + 0.01);
    }`;

var VERT_LAPLACE = `
    ${HEADER}
    
    varying vec2 VTC_01;
    varying vec2 VTC_10;
    varying vec2 VTC_11;
    varying vec2 VTC_12;
    varying vec2 VTC_21;

    void main() {
        ${INIT}

        VTC_01 = ${alias.texcoord} + vec2(0, -${alias.width} - 0.01);
        VTC_10 = ${alias.texcoord} + vec2(-${alias.width} - 0.01, 0);
        VTC_11 = ${alias.texcoord};
        VTC_12 = ${alias.texcoord} + vec2(${alias.width} + 0.01, 0);
        VTC_21 = ${alias.texcoord} + vec2(0, ${alias.width} + 0.01);
    }`;

var VERT_MEDIAN = `
    ${HEADER}

    varying vec2 VTC_0;
    varying vec2 VTC_1;
    varying vec2 VTC_2;

    void main() {
        ${INIT}

      VTC_0 = ${alias.texcoord};
      VTC_1 = ${alias.texcoord} - ${alias.width};
      VTC_2 = ${alias.texcoord} + ${alias.width};
  }`;


export const CONVOLUTION = [

    // BLUR

    {
      name:'BLUR', 
      frag:'blurFragmentShaderSrc',
      vert: VERT_DIAG5
    },

    // SHARPEN

    {
      name:'SHARPEN', 
      frag:'sharpenFragmentShaderSrc',
      vert: VERT_DIAG5
    },

    // BOX_8

    {
      name:'DILATE', 
      frag:'dilateFragmentShaderSrc',
      vert: VERT_BOX8
    },
    {
      name:'ERODE', 
      frag:'erodeFragmentShaderSrc',
      vert: VERT_BOX8
    },

    // MEDIAN

    {
      name:'MEDIAN', 
      frag:'medianFragmentShaderSrc',
      vert: VERT_MEDIAN
    },


    // EMBOSS

    {
      name:'EMBOSS', 
      frag:'embossFragmentShaderSrc',
      vert: VERT_EMBOSS
    },

    // LAPLACE

    {
      name:'LAPLACE', 
      frag:'laplaceFragmentShaderSrc',
      vert: VERT_LAPLACE
    },

    // RADIAL

    {
      name:'RADIAL BLUR', 
      frag:'radialblurFragmentShaderSrc',
      vert: VERT_PASS
    }
]

