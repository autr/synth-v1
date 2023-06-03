/*
{
  "DESCRIPTION": "COMPILED: 01_06_2023_ 01_55_54",
  "CREDIT": "MX",
  "PERSISTENT_BUFFERS": [
    "u112",
    "u237",
    "u999"
  ],
  "CATEGORIES": [
    "Source",
    "Deform",
    "Shape",
    "Convolution",
    "Light"
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
        "type": "feedback"
      },
      "GUI": "ExtSource",
      "TYPE": "image",
      "NAME": "u112Src",
      "LABEL": "A1 Source Src"
    },
    {
      "DEFAULT": 1,
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
      "LABEL": "B1 Deform BlendMode",
      "TYPE": "long",
      "NAME": "u432BlendMode",
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
      "LABEL": "B1 Deform BlendAmt",
      "TYPE": "float",
      "NAME": "u432BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u432Mini",
      "LABEL": "B1 Deform Mini"
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 112,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u432Src",
      "LABEL": "B1 Deform Src"
    },
    {
      "DEFAULT": 0.775390625,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u432SrcAmount",
      "LABEL": "B1 Deform SrcAmount"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u432Invert",
      "LABEL": "B1 Deform Invert"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": -0.134765625,
      "TYPE": "float",
      "NAME": "u432Offset",
      "LABEL": "B1 Deform Offset"
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
        0.216796875,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u432XY",
      "LABEL": "B1 Deform XY"
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
        0.529296875,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u432Zoom",
      "LABEL": "B1 Deform Zoom"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u432Rotate",
      "LABEL": "B1 Deform Rotate"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u432Degree",
      "LABEL": "B1 Deform Degree"
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
      "NAME": "u432Origin",
      "LABEL": "B1 Deform Origin"
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
      "DEFAULT": 1,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "C1 Shape BlendMode",
      "TYPE": "long",
      "NAME": "u597BlendMode",
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
      "DEFAULT": 0.6083984375,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "C1 Shape BlendAmt",
      "TYPE": "float",
      "NAME": "u597BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "MATTE",
        "INVERT",
        "MASK",
        "ALPHA"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u597Mode",
      "LABEL": "C1 Shape Mode",
      "VALUES": [
        0,
        1,
        2,
        3
      ]
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "SHAPE",
        "RECURSIVE"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u597ShapeMode",
      "LABEL": "C1 Shape ShapeMode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "LABELS": [
        "Horizontal",
        "Vertical",
        "Triangle",
        "Square",
        "Pentagon",
        "Hexagon",
        "Heptagon",
        "Octagon"
      ],
      "DEFAULT": 3,
      "TYPE": "long",
      "NAME": "u597Shape",
      "LABEL": "C1 Shape Shape",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7
      ]
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u597Circular",
      "LABEL": "C1 Shape Circular"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u597Smooth",
      "LABEL": "C1 Shape Smooth"
    },
    {
      "MAX": 1.5,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u597Size",
      "LABEL": "C1 Shape Size"
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
        0.431640625,
        0.5
      ],
      "TYPE": "point2D",
      "NAME": "u597Center",
      "LABEL": "C1 Shape Center"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u597Rotate",
      "LABEL": "C1 Shape Rotate"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u597Invert",
      "LABEL": "C1 Shape Invert"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u597Fit",
      "LABEL": "C1 Shape Fit"
    },
    {
      "DEFAULT": [
        0.6396484375,
        1,
        0.5673828125
      ],
      "MAX": [
        1,
        1,
        1
      ],
      "MIN": [
        0,
        0,
        0
      ],
      "TYPE": "color",
      "NAME": "u597Color",
      "LABEL": "C1 Shape Color"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u597Alpha",
      "LABEL": "C1 Shape Alpha"
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
      "DEFAULT": 17,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "D1 Shape BlendMode",
      "TYPE": "long",
      "NAME": "u149BlendMode",
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
      "DEFAULT": 0.6083984375,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "D1 Shape BlendAmt",
      "TYPE": "float",
      "NAME": "u149BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "MATTE",
        "INVERT",
        "MASK",
        "ALPHA"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u149Mode",
      "LABEL": "D1 Shape Mode",
      "VALUES": [
        0,
        1,
        2,
        3
      ]
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "SHAPE",
        "RECURSIVE"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u149ShapeMode",
      "LABEL": "D1 Shape ShapeMode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "LABELS": [
        "Horizontal",
        "Vertical",
        "Triangle",
        "Square",
        "Pentagon",
        "Hexagon",
        "Heptagon",
        "Octagon"
      ],
      "DEFAULT": 3,
      "TYPE": "long",
      "NAME": "u149Shape",
      "LABEL": "D1 Shape Shape",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7
      ]
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u149Circular",
      "LABEL": "D1 Shape Circular"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u149Smooth",
      "LABEL": "D1 Shape Smooth"
    },
    {
      "MAX": 1.5,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u149Size",
      "LABEL": "D1 Shape Size"
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
      "NAME": "u149Center",
      "LABEL": "D1 Shape Center"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u149Rotate",
      "LABEL": "D1 Shape Rotate"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u149Invert",
      "LABEL": "D1 Shape Invert"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u149Fit",
      "LABEL": "D1 Shape Fit"
    },
    {
      "DEFAULT": [
        1,
        1,
        1
      ],
      "MAX": [
        1,
        1,
        1
      ],
      "MIN": [
        0,
        0,
        0
      ],
      "TYPE": "color",
      "NAME": "u149Color",
      "LABEL": "D1 Shape Color"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u149Alpha",
      "LABEL": "D1 Shape Alpha"
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
      "DEFAULT": 16,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "E1 Shape BlendMode",
      "TYPE": "long",
      "NAME": "u237BlendMode",
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
      "DEFAULT": 0.5048828125,
      "MAX": 1,
      "MIN": 0,
      "LABEL": "E1 Shape BlendAmt",
      "TYPE": "float",
      "NAME": "u237BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "MATTE",
        "INVERT",
        "MASK",
        "ALPHA"
      ],
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u237Mode",
      "LABEL": "E1 Shape Mode",
      "VALUES": [
        0,
        1,
        2,
        3
      ]
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "SHAPE",
        "RECURSIVE"
      ],
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u237ShapeMode",
      "LABEL": "E1 Shape ShapeMode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "LABELS": [
        "Horizontal",
        "Vertical",
        "Triangle",
        "Square",
        "Pentagon",
        "Hexagon",
        "Heptagon",
        "Octagon"
      ],
      "DEFAULT": 3,
      "TYPE": "long",
      "NAME": "u237Shape",
      "LABEL": "E1 Shape Shape",
      "VALUES": [
        0,
        1,
        2,
        3,
        4,
        5,
        6,
        7
      ]
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u237Circular",
      "LABEL": "E1 Shape Circular"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5458984375,
      "TYPE": "float",
      "NAME": "u237Smooth",
      "LABEL": "E1 Shape Smooth"
    },
    {
      "MAX": 1.5,
      "MIN": 0,
      "DEFAULT": 0.3046875,
      "TYPE": "float",
      "NAME": "u237Size",
      "LABEL": "E1 Shape Size"
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
        0.4111328125,
        0.5
      ],
      "TYPE": "point2D",
      "NAME": "u237Center",
      "LABEL": "E1 Shape Center"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u237Rotate",
      "LABEL": "E1 Shape Rotate"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u237Invert",
      "LABEL": "E1 Shape Invert"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u237Fit",
      "LABEL": "E1 Shape Fit"
    },
    {
      "LINK": "ShapeMode:1",
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u237Recursion",
      "LABEL": "E1 Shape Recursion"
    },
    {
      "LINK": "ShapeMode:1",
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0.0703125,
      "TYPE": "float",
      "NAME": "u237Scroll",
      "LABEL": "E1 Shape Scroll"
    },
    {
      "LINK": "ShapeMode:1",
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.4423828125,
      "TYPE": "float",
      "NAME": "u237Alternate",
      "LABEL": "E1 Shape Alternate"
    },
    {
      "DEFAULT": [
        0.9521484375,
        1,
        0.453125
      ],
      "MAX": [
        1,
        1,
        1
      ],
      "MIN": [
        0,
        0,
        0
      ],
      "TYPE": "color",
      "NAME": "u237Color",
      "LABEL": "E1 Shape Color"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u237Alpha",
      "LABEL": "E1 Shape Alpha"
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
      "LABEL": "F1 Convolution BlendMode",
      "TYPE": "long",
      "NAME": "u141BlendMode",
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
      "LABEL": "F1 Convolution BlendAmt",
      "TYPE": "float",
      "NAME": "u141BlendAmt"
    },
    {
      "LABELS": [
        "SHARPEN",
        "DITHER"
      ],
      "GUI": "MultiClick",
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u141TYPE",
      "LABEL": "F1 Convolution TYPE",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "DEFAULT": 0.6396484375,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u141Amt",
      "LABEL": "F1 Convolution Amt"
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u141Threshold",
      "LABEL": "F1 Convolution Threshold"
    },
    {
      "DEFAULT": 0.2138671875,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u141Radius",
      "LABEL": "F1 Convolution Radius"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u141Jitter",
      "LABEL": "F1 Convolution Jitter"
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
      "NAME": "u319BlendMode",
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
      "NAME": "u319BlendAmt"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u319Mini",
      "LABEL": "G1 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u319Invert",
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
      "NAME": "u319LightMode",
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
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u319Low",
      "LABEL": "G1 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u319Light",
      "LABEL": "G1 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u319High",
      "LABEL": "G1 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u319Saturation",
      "LABEL": "G1 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": -0.0361328125,
      "TYPE": "float",
      "NAME": "u319Shift",
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
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u319ColorMode",
      "LABEL": "G1 Light ColorMode",
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
      "NAME": "u319Flip",
      "LABEL": "G1 Light Flip"
    }
  ],
  "PASSES": [
    {
      "TARGET": "u112",
      "WIDTH": "$WIDTH",
      "HEIGHT": "$HEIGHT",
      "PERSISTENT": true
    },
    {
      "TARGET": "u237",
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
vec4 u432;

vec4 u597;

vec4 u149;

vec4 u141;

vec4 u319;

const float u597Mask = -1.000;

const float u597Recursion = 0.500;

const float u597Scroll = 0.000;

const float u597Alternate = 0.000;

const float u149Mask = -1.000;

const float u149Recursion = 0.500;

const float u149Scroll = 0.000;

const float u149Alternate = 0.000;

const float u237Mask = -1.000;

const float u319TintAmount = 0.000;

const float u319TintHue = 0.000;

const float u319Levels = 0.000;

const float u319Spacing = 0.500;

const float u319Smooth = 0.000;

const float u319Vibrance = 0.000;

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

vec4 Deformu432( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, bool Mini, vec4 Src, float SrcAmount, bool Invert, float Offset, vec2 XY, vec2 Zoom, bool Rotate, float Degree, vec2 Origin) {
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
	
	return IMG_NORM_PIXEL(u112,pos);
}

vec4 Shape( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, int Mode, int ShapeMode, vec4 Mask, int Shape, float Circular, float Smooth, float Size, vec2 Center, float Rotate, bool Invert, bool Fit, float Recursion, float Scroll, float Alternate, vec4 Color, bool Alpha) {
	bool SnapShape = true;
	float Skew = 0.5;
	
	vec2 pos = POS_FRAG;
	float ratio = RENDERSIZE.y / RENDERSIZE.x;
	
	vec2 center = Center * RENDERSIZE;
	vec2 trueCenter = vec2( 0.5, 0.5 ) * RENDERSIZE;
	
	vec3 rgb = INPUT.rgb;
	bool inv = false;
	
	pos = ROTATE_VEC2( center, pos, Rotate * 360.0 );
	
	if (Fit) pos.x = (pos.x * ratio) + (( RENDERSIZE.x - RENDERSIZE.y) / 2.0);
	
	float shape = float(Shape);
	float pointsTotal = shape + 1.0;
	float segmentAng = 360.0 / pointsTotal;
	float miniAngle = segmentAng * mod( pointsTotal, 1. );
	
	float flip = 90.;
	int p = int( floor( pointsTotal ) );
	if (p == 2) {
	flip +=  miniAngle / 2. ;
	flip += 180.;
	} else if (p == 3) {
	flip +=  miniAngle / 2. ;
	} else if (p == 4) {
	flip -= (segmentAng / 2.0);
	flip - (miniAngle / 2.);
	inv = !inv;
	} else if (p == 5) {
	flip += 180.;
	flip +=  miniAngle / 2. ;
	inv = !inv;
	} else if (p == 6) {
	flip -= (segmentAng / 2.0);
	flip +=  miniAngle / 2. ;
	inv = !inv;
	} else if (p == 7) {
	flip +=  miniAngle / 2. ;
	inv = !inv;
	} else if (p == 8) {
	flip -= (segmentAng / 2.0);
	flip +=  miniAngle / 2. ;
	} else if (p == 9) {
	flip +=  miniAngle / 2. ;
	} else if (p == 10) {
	flip -= (segmentAng / 2.0);
	flip +=  miniAngle / 2. ;
	inv = !inv;
	} else if (p == 11) {
	inv = !inv;
	}
	
	pos = ROTATE_VEC2( center, pos, flip );
	
	float posAngle = ANGLE( center, pos );
	float centerDist = distance(center, pos);
	bool isMini = posAngle > 360.0 - miniAngle && posAngle < 360.;
	
	float prevAngle = posAngle -mod( posAngle, segmentAng );
	float midpointAngle;
	
	if (!isMini) {
	
	
	
	midpointAngle = prevAngle + (segmentAng / 2.0);
	
	} else {
	
	midpointAngle = -( (miniAngle) / 2.0 );
	
	}
	
	vec2 rotatedLoc = ROTATE_VEC2( center, pos, midpointAngle );
	vec2 rotatePrev = ROTATE_VEC2( center, pos, midpointAngle);
	
	float ogDist2Center = distance( rotatedLoc.x, center.x );
	float dist2Center = ogDist2Center;
	float DIST = RENDERSIZE.x * Size;
	float HDIST = DIST / 2.0;
	
	
	
	float alter = (ShapeMode == 1) ? Alternate : 0.0;
	bool ODD = mod( posAngle, segmentAng * (1.0 + alter) ) > segmentAng;
	if (ODD) dist2Center += DIST / 2.0;
	
	dist2Center -= TIME * Scroll * DIST;
	centerDist -= TIME * Scroll * DIST;
	
	float skew = MAP( Skew, 0.0, 1.0, -1.0, 1.0);
	float pointy = abs( center.y - rotatePrev.y  ) * skew * 10.;
	
	float idxDist = mix( dist2Center, centerDist, Circular) + pointy;
	float idxMod = mod( idxDist, DIST );
	int idx = int( (idxDist - idxMod) / DIST );
	
	vec3 red = vec3(0.0);
	
	float wipe = Recursion * DIST;
	float smo = (DIST * Smooth);
	bool isRecur = ShapeMode == 1;
	if (!isRecur) idxMod = idxDist;
	red.r = MAP(idxMod, wipe, wipe + smo, 1.0, 0.0);
	red.r = clamp(red.r, 0.0, 1.0);
	
	if (Invert) red.r = 1.0 - red.r;
	
	vec3 black = vec3(0.0,0.0,0.0);
	vec3 white = vec3(1.0,1.0,1.0);
	
	if ( Mode == 0 ) {
	
	return vec4( HSL_TO_RGB( Color[0], Color[1], Color[2] * red.r ), 1.0);
	
	} else if (Mode == 1) {
	vec3 invt = RGB_SHIFT(vec3(1.0,1.0,1.0)-rgb,0.5);
	vec3 mixed = (invt * red.r) + (rgb * (1.0-red.r));
	return vec4( mixed, 1.0);
	} else if (Mode == 2) {
	return vec4( mix(Mask.rgb,rgb,red.r), 1.0);
	} else {
	return vec4( mix(Mask.rgb,rgb,red.r), 1.0);
	}
}

vec4 Convolutionu141( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, int TYPE, float Amt, float Threshold, float Radius, bool Jitter) {
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
	
	
	vec4 colorInput = IMG_NORM_PIXEL(u237, POS_NORM);
	
	vec3 ori = colorInput.rgb;
	vec3 sharp_strength_luma = (COEFLUMA * sharp_strength);
	
	
	
	
	float px = 1.0/RENDERSIZE.x;
	float py = 1.0/RENDERSIZE.y;
	vec2 xy = gl_FragCoord.xy;
	
	
	
	vec3 blur_ori = IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias).rgb;
	blur_ori *= 0.25;
	vec3 sharp = ori - blur_ori;
	vec4 sharp_strength_luma_clamp = vec4(sharp_strength_luma * (0.5 / sharp_clamp),0.5);
	float sharp_luma = clamp((dot(vec4(sharp,1.0), sharp_strength_luma_clamp)), 0.0,1.0 );
	sharp_luma = (sharp_clamp * 2.0) * sharp_luma - sharp_clamp;
	colorInput.rgb = colorInput.rgb + sharp_luma;
	
	return clamp(colorInput, 0.0,1.0);
	
	
	
	for (int i = 0; i < 4; i++) {
	
	float blur_ori = IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u237, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias)[i];
	
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
	vec3 pix = IMG_NORM_PIXEL(u237, p).rgb;
	sumcol = sumcol+SRGB2LIN(pix);
	a += da;
	}
	
	sumcol = sumcol / 10.;
	sumcol = max( sumcol, 0.0 );
	
	return vec4( LIN2SRGB( sumcol ), INPUT.a);
	} else {
	
	
	return IMG_NORM_PIXEL(u237, pos );
	
	}
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
void main( ) {
	vec2 POS_NORM = POSITION_NORM();
	vec2 POS_FRAG = POSITION_FRAG();
	vec4 BG = vec4(0.0); // GRID(0.02, POS_FRAG);
	vec4 temp = BG;
	
	/* PASS  Source u112  */
	temp = texture2D(u112Src, (POS_NORM * vec2( (1. / float(u112Rows )), 1.0) + vec2(((1. / float(u112Rows )) * float(u112Index) ),0.0) ));
	gl_FragColor = MAKE_PASS( u112BlendMode, BG, temp, u112BlendAmt);
	if ( PASSINDEX == 0 ) { return; }
	
	/*   Deform u432  */
	temp = Deformu432(IMG_NORM_PIXEL(u112, POS_NORM),1,POS_NORM,POS_FRAG,u432Mini,IMG_NORM_PIXEL(u112, POS_NORM),u432SrcAmount,u432Invert,u432Offset,u432XY,u432Zoom,u432Rotate,u432Degree,u432Origin);
	u432 = MAKE_PASS( u432BlendMode, IMG_NORM_PIXEL(u112, POS_NORM), temp, u432BlendAmt);
	
	/*   Shape u597  */
	temp = Shape(u432,1,POS_NORM,POS_FRAG,u597Mode,u597ShapeMode,BG,u597Shape,u597Circular,u597Smooth,u597Size,u597Center,u597Rotate,u597Invert,u597Fit,u597Recursion,u597Scroll,u597Alternate,u597Color,u597Alpha);
	u597 = MAKE_PASS( u597BlendMode, u432, temp, u597BlendAmt);
	
	/*   Shape u149  */
	temp = Shape(u597,1,POS_NORM,POS_FRAG,u149Mode,u149ShapeMode,BG,u149Shape,u149Circular,u149Smooth,u149Size,u149Center,u149Rotate,u149Invert,u149Fit,u149Recursion,u149Scroll,u149Alternate,u149Color,u149Alpha);
	u149 = MAKE_PASS( u149BlendMode, u597, temp, u149BlendAmt);
	
	/* PASS  Shape u237  */
	temp = Shape(u149,1,POS_NORM,POS_FRAG,u237Mode,u237ShapeMode,BG,u237Shape,u237Circular,u237Smooth,u237Size,u237Center,u237Rotate,u237Invert,u237Fit,u237Recursion,u237Scroll,u237Alternate,u237Color,u237Alpha);
	gl_FragColor = MAKE_PASS( u237BlendMode, u149, temp, u237BlendAmt);
	if ( PASSINDEX == 1 ) { return; }
	
	/*   Convolution u141  */
	temp = Convolutionu141(IMG_NORM_PIXEL(u237, POS_NORM),2,POS_NORM,POS_FRAG,u141TYPE,u141Amt,u141Threshold,u141Radius,u141Jitter);
	u141 = MAKE_PASS( u141BlendMode, IMG_NORM_PIXEL(u237, POS_NORM), temp, u141BlendAmt);
	
	/* PASS  Light u319  */
	temp = Light(u141,2,POS_NORM,POS_FRAG,u319Mini,u319Invert,u319LightMode,u319Low,u319Light,u319High,u319Saturation,u319Shift,u319ColorMode,u319TintAmount,u319TintHue,u319Levels,u319Spacing,u319Smooth,u319Flip,u319Vibrance);
	gl_FragColor = MAKE_PASS( u319BlendMode, u141, temp, u319BlendAmt);
	if ( PASSINDEX == 2 ) { return; }
}
/*--BEGIN_PROJECT--{"_PREVIEW":"Deform:u432","_PROJECTION":{"rotate":[0,0,0],"skew":[0,0],"scale":[1,1],"translate":[0,0]},"_TITLES":{},"_SOURCES":[],"_SEQUENCE":[["Source:u112"],["Deform:u432"],["Shape:u597"],["Shape:u149"],["Shape:u237"],["Convolution:u141"],["Light:u319"]],"_UNIFORMS":{"u112BlendMode":0,"u112BlendAmt":1,"u112Src":{"type":"feedback"},"u112Rows":1,"u112Columns":1,"u112Index":0,"u432BlendMode":0,"u432BlendAmt":1,"u432Mini":true,"u432Src":112,"u432SrcAmount":0.775390625,"u432Invert":false,"u432Offset":-0.134765625,"u432XY":[0.216796875,0],"u432Zoom":[0.529296875,0],"u432Rotate":false,"u432Degree":1,"u432Origin":[0.5,0.5],"u597BlendMode":1,"u597BlendAmt":0.6083984375,"u597Mode":0,"u597ShapeMode":0,"u597Mask":-1,"u597Shape":3,"u597Circular":0,"u597Smooth":0,"u597Size":0.5,"u597Center":[0.431640625,0.5],"u597Rotate":0.5,"u597Invert":false,"u597Fit":false,"u597Recursion":0.5,"u597Scroll":0,"u597Alternate":0,"u597Color":[0.6396484375,1,0.5673828125],"u597Alpha":false,"u149BlendMode":17,"u149BlendAmt":0.6083984375,"u149Mode":0,"u149ShapeMode":0,"u149Mask":-1,"u149Shape":3,"u149Circular":1,"u149Smooth":0,"u149Size":0.5,"u149Center":[0.5,0.5],"u149Rotate":0.5,"u149Invert":false,"u149Fit":false,"u149Recursion":0.5,"u149Scroll":0,"u149Alternate":0,"u149Color":[1,1,1],"u149Alpha":false,"u237BlendMode":16,"u237BlendAmt":0.5048828125,"u237Mode":0,"u237ShapeMode":1,"u237Mask":-1,"u237Shape":3,"u237Circular":1,"u237Smooth":0.5458984375,"u237Size":0.3046875,"u237Center":[0.4111328125,0.5],"u237Rotate":0.5,"u237Invert":false,"u237Fit":false,"u237Recursion":0,"u237Scroll":0.0703125,"u237Alternate":0.4423828125,"u237Color":[0.9521484375,1,0.453125],"u237Alpha":false,"u141BlendMode":0,"u141BlendAmt":1,"u141TYPE":0,"u141Amt":0.6396484375,"u141Threshold":1,"u141Radius":0.2138671875,"u141Jitter":false,"u319BlendMode":0,"u319BlendAmt":1,"u319Mini":false,"u319Invert":false,"u319LightMode":0,"u319Low":0,"u319Light":0,"u319High":1,"u319Saturation":0,"u319Shift":-0.0361328125,"u319ColorMode":0,"u319TintAmount":0,"u319TintHue":0,"u319Levels":0,"u319Spacing":0.5,"u319Smooth":0,"u319Flip":false,"u319Vibrance":0},"_CURRENT_VIEW":"application","_DIMENSIONS":{"width":720,"height":576},"_ASSIGNMENTS":{},"_HIDDEN":{"u597Mask":true,"u597Recursion":true,"u597Scroll":true,"u597Alternate":true,"u149Mask":true,"u149Recursion":true,"u149Scroll":true,"u149Alternate":true,"u237Mask":true,"u237Recursion":false,"u237Scroll":false,"u237Alternate":false,"u319TintAmount":true,"u319TintHue":true,"u319Levels":true,"u319Spacing":true,"u319Smooth":true,"u319Vibrance":true,"u432undefined":true,"u597undefined":true,"u149undefined":true,"u237undefined":true}}--END_PROJECT--*/
