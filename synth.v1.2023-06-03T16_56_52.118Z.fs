/*
{
  "DESCRIPTION": "COMPILED: 6_3_2023_ 6_56_52 PM",
  "CREDIT": "MX",
  "PERSISTENT_BUFFERS": [
    "u814",
    "u982",
    "u999"
  ],
  "CATEGORIES": [
    "Source",
    "Light",
    "Convolution",
    "Deform",
    "Mask"
  ],
  "INPUTS": [
    {
      "NAME": "inputImage",
      "TYPE": "image"
    },
    {
      "NAME": "Preview",
      "TYPE": "bool",
      "default": false
    },
    {
      "NAME": "PreviewSrc",
      "TYPE": "long",
      "default": -1
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "A1 Source BlendMode",
      "TYPE": "long",
      "NAME": "u112BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "A1 Source BlendAmt",
      "TYPE": "float",
      "NAME": "u112BlendAmt"
    },
    {
      "DEFAULT": {
        "type": "camera",
        "path": "CCTV"
      },
      "GUI": "ExtSource",
      "TYPE": "image",
      "NAME": "u112Src",
      "LABEL": "A1 Source Src"
    },
    {
      "DEFAULT": 2,
      "TYPE": "long",
      "NAME": "u112Rows",
      "LABEL": "A1 Source Rows"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u112Columns",
      "LABEL": "A1 Source Columns"
    },
    {
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u112Index",
      "LABEL": "A1 Source Index"
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "B1 Light BlendMode",
      "TYPE": "long",
      "NAME": "u721BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "B1 Light BlendAmt",
      "TYPE": "float",
      "NAME": "u721BlendAmt"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u721Mini",
      "LABEL": "B1 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u721Invert",
      "LABEL": "B1 Light Invert"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Lightness",
        "Exposure",
        "Brightness"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u721LightMode",
      "LABEL": "B1 Light LightMode",
      "VALUES": [
        0,
        1,
        2
      ]
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u721Low",
      "LABEL": "B1 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0.091796875,
      "TYPE": "float",
      "NAME": "u721Light",
      "LABEL": "B1 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.984375,
      "TYPE": "float",
      "NAME": "u721High",
      "LABEL": "B1 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u721Saturation",
      "LABEL": "B1 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u721Shift",
      "LABEL": "B1 Light Shift"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Basic",
        "Tint",
        "Colorise",
        "Tweak"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u721ColorMode",
      "LABEL": "B1 Light ColorMode",
      "VALUES": [
        0,
        1,
        2,
        3
      ]
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u721Flip",
      "LABEL": "B1 Light Flip"
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "C1 Source BlendMode",
      "TYPE": "long",
      "NAME": "u814BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "C1 Source BlendAmt",
      "TYPE": "float",
      "NAME": "u814BlendAmt"
    },
    {
      "DEFAULT": {
        "type": "feedback"
      },
      "GUI": "ExtSource",
      "TYPE": "image",
      "NAME": "u814Src",
      "LABEL": "C1 Source Src"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u814Rows",
      "LABEL": "C1 Source Rows"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u814Columns",
      "LABEL": "C1 Source Columns"
    },
    {
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u814Index",
      "LABEL": "C1 Source Index"
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "D1 Convolution BlendMode",
      "TYPE": "long",
      "NAME": "u982BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "D1 Convolution BlendAmt",
      "TYPE": "float",
      "NAME": "u982BlendAmt"
    },
    {
      "LABELS": [
        "SHARPEN",
        "DITHER"
      ],
      "GUI": "MultiClick",
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u982TYPE",
      "LABEL": "D1 Convolution TYPE",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "DEFAULT": 0.056640625,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u982Amt",
      "LABEL": "D1 Convolution Amt"
    },
    {
      "DEFAULT": 0.2,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u982Threshold",
      "LABEL": "D1 Convolution Threshold"
    },
    {
      "DEFAULT": 0.0361328125,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u982Radius",
      "LABEL": "D1 Convolution Radius"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u982Jitter",
      "LABEL": "D1 Convolution Jitter"
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "E1 Deform BlendMode",
      "TYPE": "long",
      "NAME": "u755BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "E1 Deform BlendAmt",
      "TYPE": "float",
      "NAME": "u755BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u755Mini",
      "LABEL": "E1 Deform Mini"
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 112,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u755Src",
      "LABEL": "E1 Deform Src"
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u755SrcAmount",
      "LABEL": "E1 Deform SrcAmount"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u755Invert",
      "LABEL": "E1 Deform Invert"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0.21484375,
      "TYPE": "float",
      "NAME": "u755Offset",
      "LABEL": "E1 Deform Offset"
    },
    {
      "MAX": [
        1,
        1
      ],
      "MIN": [
        -1,
        -1
      ],
      "DEFAULT": [
        0.05078125,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u755XY",
      "LABEL": "E1 Deform XY"
    },
    {
      "MAX": [
        1,
        1
      ],
      "MIN": [
        -1,
        -1
      ],
      "DEFAULT": [
        0.478515625,
        -0.72265625
      ],
      "TYPE": "point2D",
      "NAME": "u755Zoom",
      "LABEL": "E1 Deform Zoom"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u755Rotate",
      "LABEL": "E1 Deform Rotate"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": -0.048828125,
      "TYPE": "float",
      "NAME": "u755Degree",
      "LABEL": "E1 Deform Degree"
    },
    {
      "MAX": [
        1,
        1
      ],
      "MIN": [
        0,
        0
      ],
      "DEFAULT": [
        0.5,
        0.5
      ],
      "TYPE": "point2D",
      "NAME": "u755Origin",
      "LABEL": "E1 Deform Origin"
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "F1 Mask BlendMode",
      "TYPE": "long",
      "NAME": "u655BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "F1 Mask BlendAmt",
      "TYPE": "float",
      "NAME": "u655BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Basic",
        "Advanced"
      ],
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u655Mode",
      "LABEL": "F1 Mask Mode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 755,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u655Background",
      "LABEL": "F1 Mask Background"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 721,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u655Foreground",
      "LABEL": "F1 Mask Foreground"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 721,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u655Mask",
      "LABEL": "F1 Mask Mask"
    },
    {
      "LINK": "Mode:1",
      "GUI": "MultiClick",
      "LABELS": [
        "Lightness",
        "Brightness",
        "RGB"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u655LightMode",
      "LABEL": "F1 Mask LightMode",
      "VALUES": [
        0,
        1,
        2
      ]
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u655Invert",
      "LABEL": "F1 Mask Invert"
    },
    {
      "MAX": [
        1,
        1
      ],
      "MIN": [
        0,
        0
      ],
      "DEFAULT": [
        0.484375,
        1
      ],
      "TYPE": "point2D",
      "NAME": "u655Threshold",
      "LABEL": "F1 Mask Threshold"
    },
    {
      "MAX": [
        1,
        1
      ],
      "MIN": [
        0,
        0
      ],
      "DEFAULT": [
        0.3623046875,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u655Smooth",
      "LABEL": "F1 Mask Smooth"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u655SatInfluence",
      "LABEL": "F1 Mask SatInfluence"
    },
    {
      "LABELS": [
        "NORM",
        "ADD",
        "DARKEN",
        "SCREEN",
        "OVERLAY",
        "HARD",
        "SOFT",
        "PIN",
        "DIFFERENCE",
        "REFLECT",
        "LIGHTEN",
        "VIVID",
        "SUBTRACT",
        "MULTI",
        "AVERAGE",
        "COLORBURN",
        "COLORDODGE",
        "EXCLUSION",
        "GLOW",
        "HARD_MIX",
        "BURN",
        "DODGE",
        "LINEAR",
        "NEGATE",
        "PHOENIX"
      ],
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "G1 Light BlendMode",
      "TYPE": "long",
      "NAME": "u247BlendMode",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7,
        8,
        9,
        10,
        11,
        12,
        13,
        14,
        15,
        16,
        17,
        18,
        19,
        20,
        21,
        22,
        23,
        24
      ]
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "G1 Light BlendAmt",
      "TYPE": "float",
      "NAME": "u247BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u247Mini",
      "LABEL": "G1 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u247Invert",
      "LABEL": "G1 Light Invert"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Lightness",
        "Exposure",
        "Brightness"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u247LightMode",
      "LABEL": "G1 Light LightMode",
      "VALUES": [
        0,
        1,
        2
      ]
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.015625,
      "TYPE": "float",
      "NAME": "u247Low",
      "LABEL": "G1 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": -0.08984375,
      "TYPE": "float",
      "NAME": "u247Light",
      "LABEL": "G1 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u247High",
      "LABEL": "G1 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0.111328125,
      "TYPE": "float",
      "NAME": "u247Saturation",
      "LABEL": "G1 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": -0.03515625,
      "TYPE": "float",
      "NAME": "u247Shift",
      "LABEL": "G1 Light Shift"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Basic",
        "Tint",
        "Colorise",
        "Tweak"
      ],
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u247ColorMode",
      "LABEL": "G1 Light ColorMode",
      "VALUES": [
        0,
        1,
        2,
        3
      ]
    },
    {
      "LINK": "ColorMode:1",
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.130859375,
      "TYPE": "float",
      "NAME": "u247TintAmount",
      "LABEL": "G1 Light TintAmount"
    },
    {
      "LINK": "ColorMode:1",
      "DEGREES": 359,
      "MAX": 180,
      "MIN": -180,
      "DEFAULT": -12.3046875,
      "TYPE": "float",
      "NAME": "u247TintHue",
      "LABEL": "G1 Light TintHue"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u247Flip",
      "LABEL": "G1 Light Flip"
    }
  ],
  "PASSES": [
    {
      "TARGET": "u814",
      "WIDTH": "$WIDTH",
      "HEIGHT": "$HEIGHT",
      "PERSISTENT": true
    },
    {
      "TARGET": "u982",
      "WIDTH": "$WIDTH",
      "HEIGHT": "$HEIGHT",
      "PERSISTENT": true
    },
    {
      "TARGET": "u999",
      "WIDTH": "$WIDTH",
      "HEIGHT": "$HEIGHT",
      "PERSISTENT": true
    }
  ]
}
*/



float CLAMP( float v, float min, float max ) {

    if (v > max) v = max;
    if (v < min) v = min;
    return v;
}


// wenn yu perfekt lieber Gott boese (Nam june Paik 1963)

#define COLOR_MAP(f, a, b) vec3(f(a.r, b.r), f(a.g, b.g), f(a.b, b.b))
#define PI 3.14159265358979323846264338327
#define HPI 1.5707963267948966

/*  EXPERIMENTAL CONVOLUTION

varying vec2 VTC_11;
varying vec2 VTC_00;
varying vec2 VTC_02;
varying vec2 VTC_20;
varying vec2 VTC_22;
*/


vec3 SRGB2LIN(vec3 c) { return c*c; }
vec3 LIN2SRGB(vec3 c) { return sqrt(c); }

//note: uniform pdf rand [0;1]

float HASH12N(vec2 p)
{
    p  = fract(p * vec2(5.3987, 5.4421));
    p += dot(p.yx, p.xy + vec2(21.5351, 14.3137));
    return fract(p.x * p.y * 95.4307);
}

vec2 PIXELATE( vec2 coord, vec2 size ) {
    return floor( coord / size ) * size;
}

float ADD(float a, float b) { return min(a + b, 1.0); }
float COLORBURN(float a, float b) { return (b == 0.0) ? b : max((1.0 - ((1.0 - a) / b)), 0.0); }
float DARKEN(float a, float b) { return min(b, a); }
float LIGHTEN(float a, float b) { return max(b, a); }
float PIN(float a, float b) { return (b < 0.5) ? DARKEN(a, (2.0 * b)) : LIGHTEN(a , (2.0 * (b - 0.5))); }
float COLORDODGE(float a, float b) { return (b == 1.0) ? b : min(a / (1.0 - b), 1.0); }
float REFLECT(float a, float b) { return (b == 1.0) ? b : min(a * a / (1.0 - b), 1.0); }
float VIVID(float a, float b) { return (b < 0.5) ? COLORBURN(a, (2.0 * b)) : COLORDODGE(a, (2.0 * (b - 0.5))); }
float HARD_MIX(float a, float b) { return (VIVID(a, b) < 0.5) ? 0.0 : 1.0; }
float OVERLAY(float a, float b) { return a < 0.5 ? (2.0 * a * b) : (1.0 - 2.0 * (1.0 - a) * (1.0 - b)); }
float DODGE(float a, float b) { return min(a + b, 1.0); }
float SCREEN(float a, float b) { return 1.0 - ((1.0 - a) * (1.0 - b)); }
float SOFT(float a, float b) { return (b < 0.5) ? (2.0 * a * b + a * a * (1.0 - 2.0 * b)) : (sqrt(a) * (2.0 * b - 1.0) + 2.0 * a * (1.0 - b)); }
float SUBTRACT(float a, float b) { return max(a + b - 1.0, 0.0); }
float LINEAR(float a, float b) { return b < 0.5 ? SUBTRACT(a, (2.0 * b)) : DODGE(a, (2.0 * (b - 0.5))); }

float SUM_RGBA( vec4 v ) {
    return v.r + v.g + v.b;
}

float SUM_RGB( vec3 v ) {
    return v.r + v.g + v.b;
}

float PHI = 1.61803398874989484820459;  // Φ = Golden Ratio  


float HASH(float n) { return fract(sin(n) * 1e4); }
float HASH(vec2 p) { return fract(1e4 * sin(17.0 * p.x + p.y * 0.1) * (0.1 + abs(sin(p.y * 13.0 + p.x)))); }


vec3 GAMMA_CORRECT(vec3 color, float gamma){
    return pow(color, vec3(1.0/gamma));
}

vec3 LEVEL_RANGE(vec3 color, float minInput, float maxInput){
    return min(max(color - vec3(minInput), vec3(0.0)) / (vec3(maxInput) - vec3(minInput)), vec3(1.0));
}

vec3 LEVELS(vec3 color, float minInput, float gamma, float maxInput){
    return GAMMA_CORRECT(LEVEL_RANGE(color, minInput, maxInput), gamma);
}

float RANDOM(vec2 co)
{
    return fract(sin(dot(co.xy, vec2(12.9898, 78.233))) * 43758.5453);
}

vec2 NORM_TO_VEC2( vec2 xy ) {

    xy.x = ( ( xy.x * 2.0 ) - 1.0 );
    xy.y = ( ( xy.y * 2.0 ) - 1.0 );
    return xy;
}
vec2 NORM_TO_VEC2( float x, float y ) {


    x = ( ( x * 2.0 ) - 1.0 );
    y = ( ( y * 2.0 ) - 1.0 );
    return vec2(x,y);
}

float BRIGHT( vec4 xyz ) {

    return (xyz.r + xyz.g + xyz.b)/3.0;
}

float MAP(float oldValue, float oldMin, float oldMax, float newMin, float newMax) {
    float oldRange = oldMax - oldMin;
    float newRange = newMax - newMin;

    float newVal = ((oldValue - oldMin) * newRange / oldRange) + newMin;
    return newVal;
}

float MAP(float oldValue, float oldMin, float oldMax, float newMin, float newMax, bool clamp) {
    float oldRange = oldMax - oldMin;
    float newRange = newMax - newMin;

    float newVal = ((oldValue - oldMin) * newRange / oldRange) + newMin;
    if (clamp) return CLAMP(newVal, min(newMin,newMax), max(newMin,newMax));
    return newVal;
}


float FMOD( float a, float b ) {
    return a - b * floor(a/b);
}


int WITHIN(float value, float low, float high) {
  bool a = value > low && value < high;
  bool b = value + 1.0 > low && value + 1.0 < high;
  bool c = value - 1.0 > low && value - 1.0 < high;
  if (a) return 1;
  if (b) return 2;
  if (c) return 3;
  return 0;
}


vec2 INTERSECTION(vec2 a,vec2 b,vec2 c,vec2 d) {
    float ua, ub, denom = (d.y - c.y)*(b.x - a.x) - (d.x - c.x)*(b.y - a.y);
    if (denom == 0.0) return vec2(-1.0,-1.0);
    ua = ((d.x - c.x)*(a.y - c.y) - (d.y - c.y)*(a.x - c.x))/denom;
    ub = ((b.x - a.x)*(a.y - c.y) - (b.y - a.y)*(a.x - c.x))/denom;
    return vec2(
        a.x + ua * (b.x - a.x),
        a.y + ua * (b.y - a.y)
    );
}
vec2 INTERLACE_VEC2(vec2 pointA, vec2 pointB, vec2 pointC, vec2 pointD) {

  float z1 = (pointA.x - pointB.x);
  float z2 = (pointC.x - pointD.x);
  float z3 = (pointA.y - pointB.y);
  float z4 = (pointC.y - pointD.y);
  float dist = z1 * z4 - z3 * z2;
  vec2 blank = vec2(-1.0,-1.0);
  if (dist == 0.0) {
    return blank;
  }
  float tempA = (pointA.x * pointB.y - pointA.y * pointB.x);
  float tempB = (pointC.x * pointD.y - pointC.y * pointD.x);
  float xCoor = (tempA * z2 - z1 * tempB) / dist;
  float yCoor = (tempA * z4 - z3 * tempB) / dist;

  return vec2(xCoor, yCoor);
}

vec2 ROTATE_VEC2(vec2 origin, vec2 point, float angle) {
  float rad = (PI / 180.0) * angle;
  float _cos = cos(rad);
  float _sin = sin(rad);
  float run = point.x - origin.x;
  float rise = point.y - origin.y;
  float cx = (_cos * run) + (_sin * rise) + origin.x;
  float cy = (_cos * rise) - (_sin * run) + origin.y;
  return vec2(
    cx,
    cy
  );
}


float ANGLE( vec2 a, vec2 b ) {
    return ((atan(b.y - a.y, b.x - a.x)  * 360.0 / PI) + 360.0) / 2.0;
}

vec2 VEC2_FROM_ANGLE(vec2 xy, float angle, float dist) {
    float x = cos(angle * PI / 180.0) * dist + xy.x;
    float y = sin(angle * PI / 180.0) * dist + xy.y;
    return vec2(x,y);
}


vec2 VEC2_POLAR( vec2 a, vec2 b, vec2 c) {

    float slope = (a.y - b.y) / (a.x - b.x);
    float m = -1.0 / slope;
    float x = (m * c.x - c.y - slope * a.x + a.y) / (m - slope);
    float y = m * x - m * c.x + c.y;
    return vec2(x,y);
}

float VEC2_POLAR_DIST(vec2 a, vec2 b, vec2 c) {

    return ((c.x - a.x)*(b.x - a.x) + (c.y - a.y)*(b.y - a.y)) /
    (pow(b.x - a.x, 2.0) + pow(b.y - a.y, 2.0));
}



vec3 CMYK_TO_RGB (vec4 cmyk) {
    float c = cmyk.x;
    float m = cmyk.y;
    float y = cmyk.z;
    float k = cmyk.w;

    float invK = 1.0 - k;
    float r = 1.0 - min(1.0, c * invK + k);
    float g = 1.0 - min(1.0, m * invK + k);
    float b = 1.0 - min(1.0, y * invK + k);
    return clamp(vec3(r, g, b), 0.0, 1.0);
}

vec4 RGB_TO_CMYK (vec3 rgb) {
    float r = rgb.r;
    float g = rgb.g;
    float b = rgb.b;
    float k = min(1.0 - r, min(1.0 - g, 1.0 - b));
    vec3 cmy = vec3(0.0);
    float invK = 1.0 - k;
    if (invK != 0.0) {
        cmy.x = (1.0 - r - k) / invK;
        cmy.y = (1.0 - g - k) / invK;
        cmy.z = (1.0 - b - k) / invK;
    }
    return clamp(vec4(cmy, k), 0.0, 1.0);
}

vec3 RGB_TO_HSL(vec3 color) {
    vec3 hsl; // init to 0 to avoid warnings ? (and reverse if + remove first part)

    float fmin = min(min(color.r, color.g), color.b); //Min. value of RGB
    float fmax = max(max(color.r, color.g), color.b); //Max. value of RGB
    float delta = fmax - fmin; //Delta RGB value

    hsl.z = (fmax + fmin) / 2.0; // Luminance

    if (delta == 0.0) //This is a gray, no chroma...
    {
        hsl.x = 0.0; // Hue
        hsl.y = 0.0; // Saturation
    } else //Chromatic data...
    {
        if (hsl.z < 0.5)
            hsl.y = delta / (fmax + fmin); // Saturation
        else
            hsl.y = delta / (2.0 - fmax - fmin); // Saturation

        float deltaR = (((fmax - color.r) / 6.0) + (delta / 2.0)) / delta;
        float deltaG = (((fmax - color.g) / 6.0) + (delta / 2.0)) / delta;
        float deltaB = (((fmax - color.b) / 6.0) + (delta / 2.0)) / delta;

        if (color.r == fmax)
            hsl.x = deltaB - deltaG; // Hue
        else if (color.g == fmax)
            hsl.x = (1.0 / 3.0) + deltaR - deltaB; // Hue
        else if (color.b == fmax)
            hsl.x = (2.0 / 3.0) + deltaG - deltaR; // Hue

        if (hsl.x < 0.0)
            hsl.x += 1.0; // Hue
        else if (hsl.x > 1.0)
            hsl.x -= 1.0; // Hue
    }

    return hsl;
}

float HUE_TO_RGB(float f1, float f2, float hue) {
    if (hue < 0.0)
        hue += 1.0;
    else if (hue > 1.0)
        hue -= 1.0;
    float res;
    if ((6.0 * hue) < 1.0)
        res = f1 + (f2 - f1) * 6.0 * hue;
    else if ((2.0 * hue) < 1.0)
        res = f2;
    else if ((3.0 * hue) < 2.0)
        res = f1 + (f2 - f1) * ((2.0 / 3.0) - hue) * 6.0;
    else
        res = f1;
    return res;
}

vec3 HSL_TO_RGB(vec3 hsl) {
    vec3 rgb;
    
    if (hsl.y == 0.0) {
        rgb = vec3(hsl.z); // Luminance
    } else {
        float f2;
        
        if (hsl.z < 0.5)
            f2 = hsl.z * (1.0 + hsl.y);
        else
            f2 = hsl.z + hsl.y - hsl.y * hsl.z;
            
        float f1 = 2.0 * hsl.z - f2;
        
        rgb.r = HUE_TO_RGB(f1, f2, hsl.x + (1.0/3.0));
        rgb.g = HUE_TO_RGB(f1, f2, hsl.x);
        rgb.b = HUE_TO_RGB(f1, f2, hsl.x - (1.0/3.0));
    }   
    return rgb;
}

vec3 HSL_TO_RGB(float h, float s, float l) {
    return HSL_TO_RGB(vec3(h, s, l));
}


vec3 RGB_SHIFT(vec3 color, float hue) {
    hue *= 6.28318530718;
    const vec3 k = vec3(0.57735, 0.57735, 0.57735);
    float cosAngle = cos(hue);
    return vec3(color * cosAngle + cross(k, color) * sin(hue) + k * dot(k, color) * (1.0 - cosAngle));
}

vec3 HSV_TO_RGB(vec3 c)
{
vec4 K = vec4(1.0, 2.0 / 3.0, 1.0 / 3.0, 3.0);
vec3 p = abs(fract(c.xxx + K.xyz) * 6.0 - K.www);
return c.z * mix(K.xxx, clamp(p - K.xxx, 0.0, 1.0), c.y);
}

vec3 RGB_TO_HSV(vec3 rgb) {
    float Cmax = max(rgb.r, max(rgb.g, rgb.b));
    float Cmin = min(rgb.r, min(rgb.g, rgb.b));
    float delta = Cmax - Cmin;

    vec3 hsv = vec3(0., 0., Cmax);

    if (Cmax > Cmin) {
        hsv.y = delta / Cmax;

        if (rgb.r == Cmax)
            hsv.x = (rgb.g - rgb.b) / delta;
        else {
            if (rgb.g == Cmax)
                hsv.x = 2. + (rgb.b - rgb.r) / delta;
            else
                hsv.x = 4. + (rgb.r - rgb.g) / delta;
        }
        hsv.x = fract(hsv.x / 6.);
    }
    return hsv;
}


vec3 GRID( float width, vec2 coord ) {
    float size = width * RENDERSIZE.x;
    vec3 a = HSL_TO_RGB( vec3(0.0,0.0,0.9) );
    vec3 b = HSL_TO_RGB( vec3(0.0,0.0,0.7) );

    if (size == 0.0)    {
        return a;
    } else if ((mod((coord.x / size),2.0) < 1.0)&&(mod((coord.y / size),2.0) > 1.0))  {
        return a;
    } else if ((mod((coord.x / size),2.0) > 1.0)&&(mod((coord.y / size),2.0) < 1.0))  {
        return a;
    }
    
    return b;

}

float SAW( float t ) {
    return 1.0-abs(2.*fract(t/PI)-1.);
}

float WAVE( float t, float shape, float amp, float exp ) {

    float sine = sin(t);
    float saw = SAW(t);
    return pow((mix(sine,saw,shape)*(1.+amp))-(amp/2.),exp);
}




vec3 NORM( vec3 a, vec3 b) {
	return b;
}

vec3 ADD( vec3 a, vec3 b) {
	return min(a + b, vec3(1.0));
}

vec3 DARKEN( vec3 a, vec3 b) {
	return COLOR_MAP(DARKEN, a, b);
}

vec3 SCREEN( vec3 a, vec3 b) {
	return COLOR_MAP(SCREEN, a, b);
}

vec3 OVERLAY( vec3 a, vec3 b) {
	return COLOR_MAP(OVERLAY, a, b);
}

vec3 HARD( vec3 a, vec3 b) {
	return OVERLAY(b, a);
}

vec3 SOFT( vec3 a, vec3 b) {
	return COLOR_MAP(SOFT, a, b);
}

vec3 PIN( vec3 a, vec3 b) {
	return COLOR_MAP(PIN, a, b);
}

vec3 DIFFERENCE( vec3 a, vec3 b) {
	return abs(a - b);
}

vec3 REFLECT( vec3 a, vec3 b) {
	return COLOR_MAP(REFLECT, a, b);
}

vec3 LIGHTEN( vec3 a, vec3 b) {
	return COLOR_MAP(LIGHTEN, a, b);
}

vec3 VIVID( vec3 a, vec3 b) {
	return COLOR_MAP(VIVID, a, b);
}

vec3 SUBTRACT( vec3 a, vec3 b) {
	return max(a + b - vec3(1.0), vec3(0.0));
}

vec3 MULTI( vec3 a, vec3 b) {
	return a * b;
}

vec3 AVERAGE( vec3 a, vec3 b) {
	return (a + b) / 2.0;
}

vec3 COLORBURN( vec3 a, vec3 b) {
	return COLOR_MAP(COLORBURN, a, b);
}

vec3 COLORDODGE( vec3 a, vec3 b) {
	return COLOR_MAP(COLORDODGE, a, b);
}

vec3 EXCLUSION( vec3 a, vec3 b) {
	return a + b - 2.0 * a * b;
}

vec3 GLOW( vec3 a, vec3 b) {
	return REFLECT(b, a);
}

vec3 HARD_MIX( vec3 a, vec3 b) {
	return COLOR_MAP(HARD_MIX, a, b);
}

vec3 BURN( vec3 a, vec3 b) {
	return max(a + b - vec3(1.0), vec3(0.0));
}

vec3 DODGE( vec3 a, vec3 b) {
	return min(a + b, vec3(1.0));
}

vec3 LINEAR( vec3 a, vec3 b) {
	return COLOR_MAP(LINEAR, a, b);
}

vec3 NEGATE( vec3 a, vec3 b) {
	return vec3(1.0) - abs(vec3(1.0) - a - b);
}

vec3 PHOENIX( vec3 a, vec3 b) {
	return min(a, b) - max(a, b) + vec3(1.0);
}
vec4 u112;

vec4 u721;

vec4 u755;

vec4 u655;

vec4 u247;

const float u721TintAmount = 0.000;

const float u721TintHue = 0.000;

const float u721Levels = 0.000;

const float u721Spacing = 0.500;

const float u721Smooth = 0.000;

const float u721Vibrance = 0.000;

const float u247Levels = 0.000;

const float u247Spacing = 0.500;

const float u247Smooth = 0.000;

const float u247Vibrance = 0.000;

int TOTAL_PASSES = 7;

vec2 POSITION_FRAG( ) {
	return gl_FragCoord.xy;
}

vec2 POSITION_NORM( ) {
	vec2 p = isf_FragNormCoord;
	// p *= 2.;
	// if (p.y < 0.5) p.y = p.y * 1.5;
	return p;
}

vec2 CENTER( ) {
	return vec2( 0.5, 0.5 ) * RENDERSIZE;
}

vec3 BLEND( int mode, vec3 a, vec3 b, float amount) {
	vec3 color;
	if (mode == 0) { color = NORM(a, b); }
	else if (mode == 1) { color = ADD(a, b); }
	else if (mode == 2) { color = DARKEN(a, b); }
	else if (mode == 3) { color = SCREEN(a, b); }
	else if (mode == 4) { color = OVERLAY(a, b); }
	else if (mode == 5) { color = HARD(a, b); }
	else if (mode == 6) { color = SOFT(a, b); }
	else if (mode == 7) { color = PIN(a, b); }
	else if (mode == 8) { color = DIFFERENCE(a, b); }
	else if (mode == 9) { color = REFLECT(a, b); }
	else if (mode == 10) { color = LIGHTEN(a, b); }
	else if (mode == 11) { color = VIVID(a, b); }
	else if (mode == 12) { color = SUBTRACT(a, b); }
	else if (mode == 13) { color = MULTI(a, b); }
	else if (mode == 14) { color = AVERAGE(a, b); }
	else if (mode == 15) { color = COLORBURN(a, b); }
	else if (mode == 16) { color = COLORDODGE(a, b); }
	else if (mode == 17) { color = EXCLUSION(a, b); }
	else if (mode == 18) { color = GLOW(a, b); }
	else if (mode == 19) { color = HARD_MIX(a, b); }
	else if (mode == 20) { color = BURN(a, b); }
	else if (mode == 21) { color = DODGE(a, b); }
	else if (mode == 22) { color = LINEAR(a, b); }
	else if (mode == 23) { color = NEGATE(a, b); }
	else if (mode == 24) { color = PHOENIX(a, b); }
	return mix(a, color, amount);
}

vec4 MAKE_PASS( int blendMode, vec4 srcA, vec4 srcB, float slider) {
	float amt = slider * srcB.a;
	float first = clamp( amt * 2.0, 0.0, 1.0);
	float second = clamp( (amt - 0.5) * 2.0, 0.0, 1.0);
	
	vec3 blend = BLEND( blendMode, srcA.rgb, srcB.rgb, first);
	// 0.5 - 1.0 = 0.0 - 1.0
	return vec4( mix( blend, srcB.rgb, second), 1.0);
}
vec4 Source( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, sampler2D Src, int Rows, int Columns, int Index) {
	return INPUT;
}

vec4 Light( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, bool Mini, bool Invert, int LightMode, float Low, float Light, float High, float Saturation, float Shift, int ColorMode, float TintAmount, float TintHue, float Levels, float Spacing, float Smooth, bool Flip, float Vibrance) {
	float MINI = Mini ? 0.2 : 1.;
	
	vec3 hsl = RGB_TO_HSL( INPUT.rgb );
	
	if (ColorMode == 3) {
	
	
	
	float maxDelta = sqrt(hsl.y) - hsl.y;
	hsl.y += (maxDelta * Vibrance);
	
	} else if (ColorMode == 1) {
	
	
	
	vec3 tint = vec3(TintHue / 360.0,1.0,0.5);
	hsl = RGB_TO_HSL(mix(HSL_TO_RGB(hsl),HSL_TO_RGB(tint),TintAmount * hsl.z * MINI));
	
	} else if (ColorMode == 2) {
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	float space = 1./Levels;
	float snapped = hsl.z - FMOD(hsl.z,space);
	float blend = FMOD(hsl.z,space)*Levels;
	if (blend > 0.5) blend -= blend - 0.5;
	blend *= 2.;
	
	float h1 = snapped * Spacing;
	float h2 = (snapped + space) * Spacing;
	vec3 rgb1 = HSL_TO_RGB(vec3(h1, 1.0, 0.5));
	vec3 rgb2 = HSL_TO_RGB(vec3(h2, 1.0, 0.5));
	
	hsl = RGB_TO_HSL(mix(rgb1,rgb2,blend*Smooth));
	
	}
	
	/*------------ SATURATION ------------*/
	
	hsl.y += Saturation * MINI;
	hsl.y = clamp( hsl.y, 0.0, 1.0 );
	hsl.x = FMOD( hsl.x + (Shift * MINI), 1.0);
	
	/*------------ LIGHT / RGB ------------*/
	
	vec3 rgb = HSL_TO_RGB(hsl);
	vec3 final;
	
	if (LightMode == 0) {
	
	
	
	vec3 hsl = RGB_TO_HSL(rgb);
	hsl.z += Light * MINI;
	final = HSL_TO_RGB(hsl);
	
	} else if (LightMode == 1) {
	
	
	
	final = rgb * pow(2.0, Light * MINI);
	
	} else if (LightMode == 2) {
	
	
	
	vec3 hsv = RGB_TO_HSV(rgb);
	hsv.z += Light * MINI;
	final = HSV_TO_RGB(hsv);
	
	}
	
	/*------------ INVERT ------------*/
	
	if (Invert) final = RGB_SHIFT( vec3(1.0,1.0,1.0) - final, 0.5);
	
	/*------------ LOW / HIGH ------------*/
	
	float low = Low * (MINI/2.);
	float high = 1.0 - (High * (MINI/2.));
	
	/*------------ NOISE ------------*/
	
	return vec4( LEVELS(final.rgb, Low, 1.0, High).rgb, INPUT.a );
}

vec4 Convolutionu982( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, int TYPE, float Amt, float Threshold, float Radius, bool Jitter) {
	vec2 pos = POS_NORM;
	float amt = Amt;
	float Amount = Amt;
	
	if (TYPE == 0) {
	
	/*
	LumaSharpen 1.4.1
	
	original hlsl by Christian Cann Schuldt Jensen ~ CeeJay.dk
	port to glsl by Anon
	
	It blurs the original pixel with the surrounding pixels and then subtracts this blur to sharpen the image.
	It does this in luma to avoid color artifacts and allows limiting the maximum sharpning to avoid or lessen halo artifacts.
	
	This is similar to using Unsharp Mask in Photoshop.
	*/
	
	float sharp_strength = Amount;
	float sharp_clamp = sharp_strength;
	float offset_bias = Radius * 10.0;
	
	#define COEFLUMA vec3(0.299, 0.587, 0.114)
	
	
	vec4 colorInput = IMG_NORM_PIXEL(u814, POS_NORM);
	
	vec3 ori = colorInput.rgb;
	vec3 sharp_strength_luma = (COEFLUMA * sharp_strength);
	
	
	
	
	float px = 1.0/RENDERSIZE.x;
	float py = 1.0/RENDERSIZE.y;
	vec2 xy = gl_FragCoord.xy;
	
	
	
	vec3 blur_ori = IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias).rgb;
	blur_ori *= 0.25;
	vec3 sharp = ori - blur_ori;
	vec4 sharp_strength_luma_clamp = vec4(sharp_strength_luma * (0.5 / sharp_clamp),0.5);
	float sharp_luma = clamp((dot(vec4(sharp,1.0), sharp_strength_luma_clamp)), 0.0,1.0 );
	sharp_luma = (sharp_clamp * 2.0) * sharp_luma - sharp_clamp;
	colorInput.rgb = colorInput.rgb + sharp_luma;
	
	return clamp(colorInput, 0.0,1.0);
	
	
	
	for (int i = 0; i < 4; i++) {
	
	float blur_ori = IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u814, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias)[i];
	
	blur_ori *= 0.25;
	
	
	float sharp = ori[i] - blur_ori;
	
	
	float sharp_strength_luma_clamp = sharp_strength_luma[i] * (0.5 / sharp_clamp);
	
	float sharp_luma = clamp((sharp + sharp_strength_luma_clamp), 0.0,1.0 );
	sharp_luma = (sharp_clamp * 2.0) * sharp_luma - sharp_clamp;
	
	
	
	colorInput[i] = colorInput[i] + sharp_luma;
	}
	
	return clamp(colorInput, 0.0,1.0);
	
	} else if (TYPE == 1) {
	
	
	
	vec3 res = vec3(RENDERSIZE, 1.);
	float time = TIME;
	
	const vec2 blurdir = vec2( 1.0, 0.0 );
	
	float blurdist_px = float(RENDERSIZE.x*Radius);
	vec2 POS = POS_FRAG;
	vec2 suv = POS / res.xy;
	vec2 uv = POS / res.xy;
	
	float blur = 10. * amt * blurdist_px;
	blur *= .1;
	
	float da = 6.283;
	float a = 1.0;
	
	if (Jitter) {
	a = da * HASH12N(uv+(time));
	} else {
	a = da * HASH12N(uv);
	}
	
	vec3 sumcol = vec3(0.0);
	
	for (int i=0;i<10;++i) {
	vec2 ofs = vec2( cos(a), sin(a) ) / res.xy * blur*float(i+1)*.31;
	vec2 p = uv+(ofs/10.);
	vec3 pix = IMG_NORM_PIXEL(u814, p).rgb;
	sumcol = sumcol+SRGB2LIN(pix);
	a += da;
	}
	
	sumcol = sumcol / 10.;
	sumcol = max( sumcol, 0.0 );
	
	return vec4( LIN2SRGB( sumcol ), INPUT.a);
	} else {
	
	
	return IMG_NORM_PIXEL(u814, pos );
	
	}
}

vec4 Deformu755( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, bool Mini, vec4 Src, float SrcAmount, bool Invert, float Offset, vec2 XY, vec2 Zoom, bool Rotate, float Degree, vec2 Origin) {
	vec2 pos = POS_NORM;
	vec2 center = vec2( 0.5, 0.5 );
	float off = Offset;
	float all = mix(SUM_RGBA(Src)/3.0,1.0,1.0-SrcAmount);
	if (Invert) all = 1.0 - all;
	float bb = (all*2.0)-1.0;
	bb += off;
	
	float mini = Mini ? 0.02 : 1.;
	
	vec2 xy = XY * vec2(mini,mini);
	vec2 zoom = Zoom * vec2(mini,mini);
	
	float angle = ANGLE(center, pos);
	
	pos.x += xy.x * bb;
	pos.y += xy.y * bb;
	pos.x += (((pos.x * 2.0) - 1.0) * zoom.x) * bb;
	pos.y += ((pos.y * 2.0) - 1.0) * (zoom.y * bb);
	if (Rotate) pos = ROTATE_VEC2(Origin, pos, 	Degree * bb * 180. * mini);
	
	return IMG_NORM_PIXEL(u982,pos);
}

vec4 Mask( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, int Mode, vec4 Background, vec4 Foreground, vec4 Mask, int LightMode, bool Invert, vec2 Threshold, vec2 Smooth, float SatInfluence) {
	vec3 mask = INPUT.rgb;
	vec3 foreground = INPUT.rgb;
	
	if (Mode == 1) {
	mask = Mask.rgb;
	foreground = Foreground.rgb;
	}
	
	float amt;
	float sat = RGB_TO_HSL(mask).y;
	
	if (LightMode == 0) {
	
	amt = RGB_TO_HSL(mask).z;
	} else if (LightMode == 1) {
	
	amt = RGB_TO_HSV(mask).z;
	} else {
	
	amt = mask.r + mask.g + mask.b;
	}
	
	if (Invert) amt = 1.0 - amt;
	
	float ll = MAP(Threshold.x,0.0,1.0,-0.1,1.1);
	float hh = MAP(Threshold.y,0.0,1.0,-0.1,1.1);
	
	float low = MAP(amt,ll, ll+Smooth.x,1.0,0.0, true);
	float high = MAP(amt,hh-Smooth.y,hh,0.0,1.0, false);
	float blend = CLAMP(max(low,high),-1.0,1.0);
	blend = MAP(blend,0.0,1.0,-1.0,1.0);
	
	blend *= 1.0 + (sat * SatInfluence * 1.);
	blend = (blend+1.0)/2.0;
	
	return vec4( mix(foreground,Background.rgb,blend), 1.0);
}
void main( ) {
	vec2 POS_NORM = POSITION_NORM();
	vec2 POS_FRAG = POSITION_FRAG();
	vec4 BG = vec4(0.0); // GRID(0.02, POS_FRAG);
	vec4 temp = BG;
	
	/*   Source u112  */
	temp = texture2D(u112Src, (POS_NORM * vec2( (1. / float(u112Rows )), 1.0) + vec2(((1. / float(u112Rows )) * float(u112Index) ),0.0) ));
	u112 = MAKE_PASS( u112BlendMode, BG, temp, u112BlendAmt);
	
	/*   Light u721  */
	temp = Light(u112,0,POS_NORM,POS_FRAG,u721Mini,u721Invert,u721LightMode,u721Low,u721Light,u721High,u721Saturation,u721Shift,u721ColorMode,u721TintAmount,u721TintHue,u721Levels,u721Spacing,u721Smooth,u721Flip,u721Vibrance);
	u721 = MAKE_PASS( u721BlendMode, u112, temp, u721BlendAmt);
	
	/* PASS  Source u814  */
	temp = texture2D(u814Src, (POS_NORM * vec2( (1. / float(u814Rows )), 1.0) + vec2(((1. / float(u814Rows )) * float(u814Index) ),0.0) ));
	gl_FragColor = MAKE_PASS( u814BlendMode, u721, temp, u814BlendAmt);
	if ( PASSINDEX == 0 ) { return; }
	
	/* PASS  Convolution u982  */
	temp = Convolutionu982(IMG_NORM_PIXEL(u814, POS_NORM),1,POS_NORM,POS_FRAG,u982TYPE,u982Amt,u982Threshold,u982Radius,u982Jitter);
	gl_FragColor = MAKE_PASS( u982BlendMode, IMG_NORM_PIXEL(u814, POS_NORM), temp, u982BlendAmt);
	if ( PASSINDEX == 1 ) { return; }
	
	/*   Deform u755  */
	temp = Deformu755(IMG_NORM_PIXEL(u982, POS_NORM),2,POS_NORM,POS_FRAG,u755Mini,u112,u755SrcAmount,u755Invert,u755Offset,u755XY,u755Zoom,u755Rotate,u755Degree,u755Origin);
	u755 = MAKE_PASS( u755BlendMode, IMG_NORM_PIXEL(u982, POS_NORM), temp, u755BlendAmt);
	
	/*   Mask u655  */
	temp = Mask(u755,2,POS_NORM,POS_FRAG,u655Mode,u755,u721,u721,u655LightMode,u655Invert,u655Threshold,u655Smooth,u655SatInfluence);
	u655 = MAKE_PASS( u655BlendMode, u755, temp, u655BlendAmt);
	
	/* PASS  Light u247  */
	temp = Light(u655,2,POS_NORM,POS_FRAG,u247Mini,u247Invert,u247LightMode,u247Low,u247Light,u247High,u247Saturation,u247Shift,u247ColorMode,u247TintAmount,u247TintHue,u247Levels,u247Spacing,u247Smooth,u247Flip,u247Vibrance);
	gl_FragColor = MAKE_PASS( u247BlendMode, u655, temp, u247BlendAmt);
	if ( PASSINDEX == 2 ) { return; }
}
/*--BEGIN_PROJECT--{"_PREVIEW":"Light:u247","_PROJECTION":{"rotate":[0,0,0],"skew":[0,0],"scale":[0.7294921875,1],"translate":[0,0]},"_TITLES":{},"_SOURCES":[],"_SEQUENCE":[["Source:u112"],["Light:u721"],["Source:u814"],["Convolution:u982"],["Deform:u755"],["Mask:u655"],["Light:u247"],[],[],[],[],[],[],[],[],[],[],[]],"_UNIFORMS":{"u112BlendMode":0,"u112BlendAmt":1,"u112Src":{"type":"camera","path":"CCTV"},"u112Rows":2,"u112Columns":1,"u112Index":0,"u721BlendMode":0,"u721BlendAmt":1,"u721Mini":false,"u721Invert":false,"u721LightMode":0,"u721Low":0,"u721Light":0.091796875,"u721High":0.984375,"u721Saturation":0,"u721Shift":0,"u721ColorMode":0,"u721TintAmount":0,"u721TintHue":0,"u721Levels":0,"u721Spacing":0.5,"u721Smooth":0,"u721Flip":false,"u721Vibrance":0,"u814BlendMode":0,"u814BlendAmt":1,"u814Src":{"type":"feedback"},"u814Rows":1,"u814Columns":1,"u814Index":0,"u982BlendMode":0,"u982BlendAmt":1,"u982TYPE":0,"u982Amt":0.056640625,"u982Threshold":0.2,"u982Radius":0.0361328125,"u982Jitter":false,"u755BlendMode":0,"u755BlendAmt":1,"u755Mini":true,"u755Src":112,"u755SrcAmount":1,"u755Invert":false,"u755Offset":0.21484375,"u755XY":[0.05078125,0],"u755Zoom":[0.478515625,-0.72265625],"u755Rotate":false,"u755Degree":-0.048828125,"u755Origin":[0.5,0.5],"u655BlendMode":0,"u655BlendAmt":1,"u655Mode":1,"u655Background":755,"u655Foreground":721,"u655Mask":721,"u655LightMode":0,"u655Invert":false,"u655Threshold":[0.484375,1],"u655Smooth":[0.3623046875,0],"u655SatInfluence":0,"u247BlendMode":0,"u247BlendAmt":1,"u247Mini":true,"u247Invert":false,"u247LightMode":0,"u247Low":0.015625,"u247Light":-0.08984375,"u247High":1,"u247Saturation":0.111328125,"u247Shift":-0.03515625,"u247ColorMode":1,"u247TintAmount":0.130859375,"u247TintHue":-12.3046875,"u247Levels":0,"u247Spacing":0.5,"u247Smooth":0,"u247Flip":false,"u247Vibrance":0},"_CURRENT_VIEW":"application","_DIMENSIONS":{"width":1280,"height":720},"_ASSIGNMENTS":{},"_HIDDEN":{"u597Mask":true,"u597Recursion":true,"u597Scroll":true,"u597Alternate":true,"u149Mask":true,"u149Recursion":true,"u149Scroll":true,"u149Alternate":true,"u237Mask":true,"u237Recursion":false,"u237Scroll":false,"u237Alternate":false,"u319TintAmount":true,"u319TintHue":true,"u319Levels":true,"u319Spacing":true,"u319Smooth":true,"u319Vibrance":true,"u432undefined":true,"u597undefined":true,"u149undefined":true,"u237undefined":true,"u247TintAmount":false,"u247TintHue":false,"u247Levels":true,"u247Spacing":true,"u247Smooth":true,"u247Vibrance":true,"u171Foreground":false,"u171Mask":false,"u171LightMode":false,"u721TintAmount":true,"u721TintHue":true,"u721Levels":true,"u721Spacing":true,"u721Smooth":true,"u721Vibrance":true,"u755undefined":true,"u269undefined":true,"u171undefined":true,"u655Foreground":false,"u655Mask":false,"u655LightMode":false,"u655undefined":true}}--END_PROJECT--*/
