/*
{
  "DESCRIPTION": "COMPILED: 04_07_2024_ 14_40_18",
  "CREDIT": "MX",
  "PERSISTENT_BUFFERS": [
    "u852",
    "u853",
    "u191",
    "u999"
  ],
  "CATEGORIES": [
    "Source",
    "Light",
    "Shape",
    "Deform",
    "Mask",
    "Convolution"
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
      "NAME": "u763BlendMode",
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
      "NAME": "u763BlendAmt"
    },
    {
      "DEFAULT": {
        "type": "camera",
        "path": "FaceTime HD Camera (3A71:F4B5)"
      },
      "GUI": "ExtSource",
      "TYPE": "image",
      "NAME": "u763Src",
      "LABEL": "A1 Source Src"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u763Rows",
      "LABEL": "A1 Source Rows"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u763Columns",
      "LABEL": "A1 Source Columns"
    },
    {
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u763Index",
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
      "LABEL": "A2 Light BlendMode",
      "TYPE": "long",
      "NAME": "u833BlendMode",
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
      "LABEL": "A2 Light BlendAmt",
      "TYPE": "float",
      "NAME": "u833BlendAmt"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u833Mini",
      "LABEL": "A2 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u833Invert",
      "LABEL": "A2 Light Invert"
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
      "NAME": "u833LightMode",
      "LABEL": "A2 Light LightMode",
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
      "NAME": "u833Low",
      "LABEL": "A2 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u833Light",
      "LABEL": "A2 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u833High",
      "LABEL": "A2 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u833Saturation",
      "LABEL": "A2 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u833Shift",
      "LABEL": "A2 Light Shift"
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
      "NAME": "u833ColorMode",
      "LABEL": "A2 Light ColorMode",
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
      "NAME": "u833Flip",
      "LABEL": "A2 Light Flip"
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
      "LABEL": "B1 Shape BlendMode",
      "TYPE": "long",
      "NAME": "u924BlendMode",
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
      "LABEL": "B1 Shape BlendAmt",
      "TYPE": "float",
      "NAME": "u924BlendAmt"
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
      "NAME": "u924Mode",
      "LABEL": "B1 Shape Mode",
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
      "NAME": "u924ShapeMode",
      "LABEL": "B1 Shape ShapeMode",
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
      "NAME": "u924Shape",
      "LABEL": "B1 Shape Shape",
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
      "NAME": "u924Circular",
      "LABEL": "B1 Shape Circular"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u924Smooth",
      "LABEL": "B1 Shape Smooth"
    },
    {
      "MAX": 1.5,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u924Size",
      "LABEL": "B1 Shape Size"
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
      "NAME": "u924Center",
      "LABEL": "B1 Shape Center"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u924Rotate",
      "LABEL": "B1 Shape Rotate"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u924Invert",
      "LABEL": "B1 Shape Invert"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u924Fit",
      "LABEL": "B1 Shape Fit"
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
      "NAME": "u924Color",
      "LABEL": "B1 Shape Color"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u924Alpha",
      "LABEL": "B1 Shape Alpha"
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
      "LABEL": "C1 Shape BlendMode",
      "TYPE": "long",
      "NAME": "u865BlendMode",
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
      "LABEL": "C1 Shape BlendAmt",
      "TYPE": "float",
      "NAME": "u865BlendAmt"
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
      "NAME": "u865Mode",
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
      "NAME": "u865ShapeMode",
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
      "NAME": "u865Shape",
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
      "NAME": "u865Circular",
      "LABEL": "C1 Shape Circular"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u865Smooth",
      "LABEL": "C1 Shape Smooth"
    },
    {
      "MAX": 1.5,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u865Size",
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
        0.5,
        0.5
      ],
      "TYPE": "point2D",
      "NAME": "u865Center",
      "LABEL": "C1 Shape Center"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 0.5,
      "TYPE": "float",
      "NAME": "u865Rotate",
      "LABEL": "C1 Shape Rotate"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u865Invert",
      "LABEL": "C1 Shape Invert"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u865Fit",
      "LABEL": "C1 Shape Fit"
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
      "NAME": "u865Color",
      "LABEL": "C1 Shape Color"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u865Alpha",
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
      "DEFAULT": 0,
      "MAX": 25,
      "MIN": 0,
      "LABEL": "D1 Source BlendMode",
      "TYPE": "long",
      "NAME": "u651BlendMode",
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
      "LABEL": "D1 Source BlendAmt",
      "TYPE": "float",
      "NAME": "u651BlendAmt"
    },
    {
      "DEFAULT": {
        "type": "feedback"
      },
      "GUI": "ExtSource",
      "TYPE": "image",
      "NAME": "u651Src",
      "LABEL": "D1 Source Src"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u651Rows",
      "LABEL": "D1 Source Rows"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u651Columns",
      "LABEL": "D1 Source Columns"
    },
    {
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u651Index",
      "LABEL": "D1 Source Index"
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
      "LABEL": "D2 Light BlendMode",
      "TYPE": "long",
      "NAME": "u852BlendMode",
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
      "LABEL": "D2 Light BlendAmt",
      "TYPE": "float",
      "NAME": "u852BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u852Mini",
      "LABEL": "D2 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u852Invert",
      "LABEL": "D2 Light Invert"
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
      "NAME": "u852LightMode",
      "LABEL": "D2 Light LightMode",
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
      "NAME": "u852Low",
      "LABEL": "D2 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": -0.05078125,
      "TYPE": "float",
      "NAME": "u852Light",
      "LABEL": "D2 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u852High",
      "LABEL": "D2 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u852Saturation",
      "LABEL": "D2 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u852Shift",
      "LABEL": "D2 Light Shift"
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
      "NAME": "u852ColorMode",
      "LABEL": "D2 Light ColorMode",
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
      "DEFAULT": 0.6396484375,
      "TYPE": "float",
      "NAME": "u852TintAmount",
      "LABEL": "D2 Light TintAmount"
    },
    {
      "LINK": "ColorMode:1",
      "DEGREES": 359,
      "MAX": 180,
      "MIN": -180,
      "DEFAULT": 13.0078125,
      "TYPE": "float",
      "NAME": "u852TintHue",
      "LABEL": "D2 Light TintHue"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u852Flip",
      "LABEL": "D2 Light Flip"
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
      "LABEL": "D3 Deform BlendMode",
      "TYPE": "long",
      "NAME": "u458BlendMode",
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
      "LABEL": "D3 Deform BlendAmt",
      "TYPE": "float",
      "NAME": "u458BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u458Mini",
      "LABEL": "D3 Deform Mini"
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 924,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u458Src",
      "LABEL": "D3 Deform Src"
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u458SrcAmount",
      "LABEL": "D3 Deform SrcAmount"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u458Invert",
      "LABEL": "D3 Deform Invert"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u458Offset",
      "LABEL": "D3 Deform Offset"
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
        0.03125,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u458XY",
      "LABEL": "D3 Deform XY"
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
        0.072265625,
        0.05078125
      ],
      "TYPE": "point2D",
      "NAME": "u458Zoom",
      "LABEL": "D3 Deform Zoom"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u458Rotate",
      "LABEL": "D3 Deform Rotate"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": -0.009765625,
      "TYPE": "float",
      "NAME": "u458Degree",
      "LABEL": "D3 Deform Degree"
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
      "NAME": "u458Origin",
      "LABEL": "D3 Deform Origin"
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
      "LABEL": "E1 Source BlendMode",
      "TYPE": "long",
      "NAME": "u832BlendMode",
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
      "LABEL": "E1 Source BlendAmt",
      "TYPE": "float",
      "NAME": "u832BlendAmt"
    },
    {
      "DEFAULT": {
        "type": "feedback"
      },
      "GUI": "ExtSource",
      "TYPE": "image",
      "NAME": "u832Src",
      "LABEL": "E1 Source Src"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u832Rows",
      "LABEL": "E1 Source Rows"
    },
    {
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u832Columns",
      "LABEL": "E1 Source Columns"
    },
    {
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u832Index",
      "LABEL": "E1 Source Index"
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
      "LABEL": "E2 Light BlendMode",
      "TYPE": "long",
      "NAME": "u853BlendMode",
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
      "LABEL": "E2 Light BlendAmt",
      "TYPE": "float",
      "NAME": "u853BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u853Mini",
      "LABEL": "E2 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u853Invert",
      "LABEL": "E2 Light Invert"
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
      "NAME": "u853LightMode",
      "LABEL": "E2 Light LightMode",
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
      "NAME": "u853Low",
      "LABEL": "E2 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0.009765625,
      "TYPE": "float",
      "NAME": "u853Light",
      "LABEL": "E2 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u853High",
      "LABEL": "E2 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u853Saturation",
      "LABEL": "E2 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u853Shift",
      "LABEL": "E2 Light Shift"
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
      "NAME": "u853ColorMode",
      "LABEL": "E2 Light ColorMode",
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
      "DEFAULT": 0.5673828125,
      "TYPE": "float",
      "NAME": "u853TintAmount",
      "LABEL": "E2 Light TintAmount"
    },
    {
      "LINK": "ColorMode:1",
      "DEGREES": 359,
      "MAX": 180,
      "MIN": -180,
      "DEFAULT": -179.6484375,
      "TYPE": "float",
      "NAME": "u853TintHue",
      "LABEL": "E2 Light TintHue"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u853Flip",
      "LABEL": "E2 Light Flip"
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
      "LABEL": "E3 Deform BlendMode",
      "TYPE": "long",
      "NAME": "u749BlendMode",
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
      "LABEL": "E3 Deform BlendAmt",
      "TYPE": "float",
      "NAME": "u749BlendAmt"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u749Mini",
      "LABEL": "E3 Deform Mini"
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 865,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u749Src",
      "LABEL": "E3 Deform Src"
    },
    {
      "DEFAULT": 1,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u749SrcAmount",
      "LABEL": "E3 Deform SrcAmount"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u749Invert",
      "LABEL": "E3 Deform Invert"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u749Offset",
      "LABEL": "E3 Deform Offset"
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
        0,
        0.009765625
      ],
      "TYPE": "point2D",
      "NAME": "u749XY",
      "LABEL": "E3 Deform XY"
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
        0.072265625
      ],
      "TYPE": "point2D",
      "NAME": "u749Zoom",
      "LABEL": "E3 Deform Zoom"
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u749Rotate",
      "LABEL": "E3 Deform Rotate"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0.05078125,
      "TYPE": "float",
      "NAME": "u749Degree",
      "LABEL": "E3 Deform Degree"
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
      "NAME": "u749Origin",
      "LABEL": "E3 Deform Origin"
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
      "LABEL": "F1 Light BlendMode",
      "TYPE": "long",
      "NAME": "u895BlendMode",
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
      "LABEL": "F1 Light BlendAmt",
      "TYPE": "float",
      "NAME": "u895BlendAmt"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u895Mini",
      "LABEL": "F1 Light Mini"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u895Invert",
      "LABEL": "F1 Light Invert"
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
      "NAME": "u895LightMode",
      "LABEL": "F1 Light LightMode",
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
      "NAME": "u895Low",
      "LABEL": "F1 Light Low"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u895Light",
      "LABEL": "F1 Light Light"
    },
    {
      "MAX": 1,
      "MIN": 0,
      "DEFAULT": 1,
      "TYPE": "float",
      "NAME": "u895High",
      "LABEL": "F1 Light High"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u895Saturation",
      "LABEL": "F1 Light Saturation"
    },
    {
      "DEGREES": 359,
      "SMOOTH": 0,
      "POSITION": -1,
      "MAX": 0.5,
      "MIN": -0.5,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u895Shift",
      "LABEL": "F1 Light Shift"
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
      "NAME": "u895ColorMode",
      "LABEL": "F1 Light ColorMode",
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
      "NAME": "u895Flip",
      "LABEL": "F1 Light Flip"
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
      "LABEL": "G1 Mask BlendMode",
      "TYPE": "long",
      "NAME": "u958BlendMode",
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
      "LABEL": "G1 Mask BlendAmt",
      "TYPE": "float",
      "NAME": "u958BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Basic",
        "Advanced"
      ],
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u958Mode",
      "LABEL": "G1 Mask Mode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 458,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u958Background",
      "LABEL": "G1 Mask Background"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 749,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u958Foreground",
      "LABEL": "G1 Mask Foreground"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 865,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u958Mask",
      "LABEL": "G1 Mask Mask"
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
      "NAME": "u958LightMode",
      "LABEL": "G1 Mask LightMode",
      "VALUES": [
        0,
        1,
        2
      ]
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u958Invert",
      "LABEL": "G1 Mask Invert"
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
        0.4521484375,
        1
      ],
      "TYPE": "point2D",
      "NAME": "u958Threshold",
      "LABEL": "G1 Mask Threshold"
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
        0,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u958Smooth",
      "LABEL": "G1 Mask Smooth"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u958SatInfluence",
      "LABEL": "G1 Mask SatInfluence"
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
      "LABEL": "H1 Mask BlendMode",
      "TYPE": "long",
      "NAME": "u147BlendMode",
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
      "LABEL": "H1 Mask BlendAmt",
      "TYPE": "float",
      "NAME": "u147BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Basic",
        "Advanced"
      ],
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u147Mode",
      "LABEL": "H1 Mask Mode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 833,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u147Background",
      "LABEL": "H1 Mask Background"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 958,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u147Foreground",
      "LABEL": "H1 Mask Foreground"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 924,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u147Mask",
      "LABEL": "H1 Mask Mask"
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
      "NAME": "u147LightMode",
      "LABEL": "H1 Mask LightMode",
      "VALUES": [
        0,
        1,
        2
      ]
    },
    {
      "DEFAULT": true,
      "TYPE": "bool",
      "NAME": "u147Invert",
      "LABEL": "H1 Mask Invert"
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
        0,
        1
      ],
      "TYPE": "point2D",
      "NAME": "u147Threshold",
      "LABEL": "H1 Mask Threshold"
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
        0,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u147Smooth",
      "LABEL": "H1 Mask Smooth"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u147SatInfluence",
      "LABEL": "H1 Mask SatInfluence"
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
      "LABEL": "I1 Mask BlendMode",
      "TYPE": "long",
      "NAME": "u191BlendMode",
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
      "LABEL": "I1 Mask BlendAmt",
      "TYPE": "float",
      "NAME": "u191BlendAmt"
    },
    {
      "GUI": "MultiClick",
      "LABELS": [
        "Basic",
        "Advanced"
      ],
      "DEFAULT": 1,
      "TYPE": "long",
      "NAME": "u191Mode",
      "LABEL": "I1 Mask Mode",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "MAX": 999,
      "GUI": "OpSelect",
      "DEFAULT": 833,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u191Background",
      "LABEL": "I1 Mask Background"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 147,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u191Foreground",
      "LABEL": "I1 Mask Foreground"
    },
    {
      "MAX": 999,
      "LINK": "Mode:1",
      "GUI": "OpSelect",
      "DEFAULT": 833,
      "MIN": -1,
      "TYPE": "float",
      "NAME": "u191Mask",
      "LABEL": "I1 Mask Mask"
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
      "NAME": "u191LightMode",
      "LABEL": "I1 Mask LightMode",
      "VALUES": [
        0,
        1,
        2
      ]
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u191Invert",
      "LABEL": "I1 Mask Invert"
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
        0.3798828125,
        1
      ],
      "TYPE": "point2D",
      "NAME": "u191Threshold",
      "LABEL": "I1 Mask Threshold"
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
        0,
        0
      ],
      "TYPE": "point2D",
      "NAME": "u191Smooth",
      "LABEL": "I1 Mask Smooth"
    },
    {
      "MAX": 1,
      "MIN": -1,
      "DEFAULT": 0,
      "TYPE": "float",
      "NAME": "u191SatInfluence",
      "LABEL": "I1 Mask SatInfluence"
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
      "LABEL": "J1 Convolution BlendMode",
      "TYPE": "long",
      "NAME": "u824BlendMode",
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
      "LABEL": "J1 Convolution BlendAmt",
      "TYPE": "float",
      "NAME": "u824BlendAmt"
    },
    {
      "LABELS": [
        "SHARPEN",
        "DITHER"
      ],
      "GUI": "MultiClick",
      "DEFAULT": 0,
      "TYPE": "long",
      "NAME": "u824TYPE",
      "LABEL": "J1 Convolution TYPE",
      "VALUES": [
        0,
        1
      ]
    },
    {
      "DEFAULT": 0.390625,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u824Amt",
      "LABEL": "J1 Convolution Amt"
    },
    {
      "DEFAULT": 0.2,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u824Threshold",
      "LABEL": "J1 Convolution Threshold"
    },
    {
      "DEFAULT": 0.046875,
      "MAX": 1,
      "MIN": 0,
      "TYPE": "float",
      "NAME": "u824Radius",
      "LABEL": "J1 Convolution Radius"
    },
    {
      "DEFAULT": false,
      "TYPE": "bool",
      "NAME": "u824Jitter",
      "LABEL": "J1 Convolution Jitter"
    }
  ],
  "PASSES": [
    {
      "TARGET": "u852",
      "WIDTH": "$WIDTH",
      "HEIGHT": "$HEIGHT",
      "PERSISTENT": true
    },
    {
      "TARGET": "u853",
      "WIDTH": "$WIDTH",
      "HEIGHT": "$HEIGHT",
      "PERSISTENT": true
    },
    {
      "TARGET": "u191",
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
vec4 u763;

vec4 u833;

vec4 u924;

vec4 u865;

vec4 u651;

vec4 u458;

vec4 u832;

vec4 u749;

vec4 u895;

vec4 u958;

vec4 u147;

vec4 u824;

const float u833TintAmount = 0.000;

const float u833TintHue = 0.000;

const float u833Levels = 0.000;

const float u833Spacing = 0.500;

const float u833Smooth = 0.000;

const float u833Vibrance = 0.000;

const float u924Mask = -1.000;

const float u924Recursion = 0.500;

const float u924Scroll = 0.000;

const float u924Alternate = 0.000;

const float u865Mask = -1.000;

const float u865Recursion = 0.500;

const float u865Scroll = 0.000;

const float u865Alternate = 0.000;

const float u852Levels = 0.000;

const float u852Spacing = 0.500;

const float u852Smooth = 0.000;

const float u852Vibrance = 0.000;

const float u853Levels = 0.000;

const float u853Spacing = 0.500;

const float u853Smooth = 0.000;

const float u853Vibrance = 0.000;

const float u895TintAmount = 0.000;

const float u895TintHue = 0.000;

const float u895Levels = 0.000;

const float u895Spacing = 0.500;

const float u895Smooth = 0.000;

const float u895Vibrance = 0.000;

int TOTAL_PASSES = 15;

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

vec4 Deformu458( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, bool Mini, vec4 Src, float SrcAmount, bool Invert, float Offset, vec2 XY, vec2 Zoom, bool Rotate, float Degree, vec2 Origin) {
	vec2 pos = POS_NORM;
	vec2 center = vec2( 0.5, 0.5 );
	float off = Offset;
	float all = mix(SUM_RGBA(Src)/3.0,1.0,1.0-SrcAmount);
	if (Invert) all = 1.0 - all;
	float bb = (all*2.0)-1.0;
	bb += off;
	
	float mini = Mini ? 0.1 : 1.;
	
	vec2 xy = XY * vec2(mini,mini);
	vec2 zoom = Zoom * vec2(mini,mini);
	
	float angle = ANGLE(center, pos);
	
	pos.x += xy.x * bb;
	pos.y += xy.y * bb;
	pos.x += (((pos.x * 2.0) - 1.0) * zoom.x) * bb;
	pos.y += ((pos.y * 2.0) - 1.0) * (zoom.y * bb);
	if (Rotate) pos = ROTATE_VEC2(Origin, pos, 	Degree * bb * 180. * mini);
	
	return IMG_NORM_PIXEL(u852,pos);
}

vec4 Deformu749( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, bool Mini, vec4 Src, float SrcAmount, bool Invert, float Offset, vec2 XY, vec2 Zoom, bool Rotate, float Degree, vec2 Origin) {
	vec2 pos = POS_NORM;
	vec2 center = vec2( 0.5, 0.5 );
	float off = Offset;
	float all = mix(SUM_RGBA(Src)/3.0,1.0,1.0-SrcAmount);
	if (Invert) all = 1.0 - all;
	float bb = (all*2.0)-1.0;
	bb += off;
	
	float mini = Mini ? 0.1 : 1.;
	
	vec2 xy = XY * vec2(mini,mini);
	vec2 zoom = Zoom * vec2(mini,mini);
	
	float angle = ANGLE(center, pos);
	
	pos.x += xy.x * bb;
	pos.y += xy.y * bb;
	pos.x += (((pos.x * 2.0) - 1.0) * zoom.x) * bb;
	pos.y += ((pos.y * 2.0) - 1.0) * (zoom.y * bb);
	if (Rotate) pos = ROTATE_VEC2(Origin, pos, 	Degree * bb * 180. * mini);
	
	return IMG_NORM_PIXEL(u853,pos);
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

vec4 Convolutionu824( vec4 INPUT, int IN_PASS, vec2 POS_NORM, vec2 POS_FRAG, int TYPE, float Amt, float Threshold, float Radius, bool Jitter) {
	vec2 pos = POS_NORM;
	float amt = Amt * 0.5;
	float Amount = Amt * 0.5;
	
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
	float offset_bias = Radius;
	
	#define COEFLUMA vec3(0.299, 0.587, 0.114)
	
	
	vec4 colorInput = IMG_NORM_PIXEL(u191, POS_NORM);
	
	vec3 ori = colorInput.rgb;
	vec3 sharp_strength_luma = (COEFLUMA * sharp_strength);
	
	
	
	
	float px = 1.0/RENDERSIZE.x;
	float py = 1.0/RENDERSIZE.y;
	vec2 xy = gl_FragCoord.xy;
	
	
	
	vec3 blur_ori = IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias).rgb;
	blur_ori += IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias).rgb;
	blur_ori *= 0.25;
	vec3 sharp = ori - blur_ori;
	vec4 sharp_strength_luma_clamp = vec4(sharp_strength_luma * (0.5 / sharp_clamp),0.5);
	float sharp_luma = clamp((dot(vec4(sharp,1.0), sharp_strength_luma_clamp)), 0.0,1.0 );
	sharp_luma = (sharp_clamp * 2.0) * sharp_luma - sharp_clamp;
	colorInput.rgb = colorInput.rgb + sharp_luma;
	
	return clamp(colorInput, 0.0,1.0);
	
	
	
	for (int i = 0; i < 4; i++) {
	
	float blur_ori = IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(px,-py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(-px,-py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(px,py) * 0.5 * offset_bias)[i];
	blur_ori += IMG_NORM_PIXEL(u191, POS_NORM.xy + vec2(-px,py) * 0.5 * offset_bias)[i];
	
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
	vec3 pix = IMG_NORM_PIXEL(u191, p).rgb;
	sumcol = sumcol+SRGB2LIN(pix);
	a += da;
	}
	
	sumcol = sumcol / 10.;
	sumcol = max( sumcol, 0.0 );
	
	return vec4( LIN2SRGB( sumcol ), INPUT.a);
	} else {
	
	
	return IMG_NORM_PIXEL(u191, pos );
	
	}
}
void main( ) {
	vec2 POS_NORM = POSITION_NORM();
	vec2 POS_FRAG = POSITION_FRAG();
	vec4 BG = vec4(0.0); // GRID(0.02, POS_FRAG);
	vec4 temp = BG;
	
	/*   Source u763  */
	temp = texture2D(u763Src, (POS_NORM * vec2( (1. / float(u763Rows )), 1.0) + vec2(((1. / float(u763Rows )) * float(u763Index) ),0.0) ));
	u763 = MAKE_PASS( u763BlendMode, BG, temp, u763BlendAmt);
	
	/*   Light u833  */
	temp = Light(u763,0,POS_NORM,POS_FRAG,u833Mini,u833Invert,u833LightMode,u833Low,u833Light,u833High,u833Saturation,u833Shift,u833ColorMode,u833TintAmount,u833TintHue,u833Levels,u833Spacing,u833Smooth,u833Flip,u833Vibrance);
	u833 = MAKE_PASS( u833BlendMode, u763, temp, u833BlendAmt);
	
	/*   Shape u924  */
	temp = Shape(u833,0,POS_NORM,POS_FRAG,u924Mode,u924ShapeMode,BG,u924Shape,u924Circular,u924Smooth,u924Size,u924Center,u924Rotate,u924Invert,u924Fit,u924Recursion,u924Scroll,u924Alternate,u924Color,u924Alpha);
	u924 = MAKE_PASS( u924BlendMode, u833, temp, u924BlendAmt);
	
	/*   Shape u865  */
	temp = Shape(u924,0,POS_NORM,POS_FRAG,u865Mode,u865ShapeMode,BG,u865Shape,u865Circular,u865Smooth,u865Size,u865Center,u865Rotate,u865Invert,u865Fit,u865Recursion,u865Scroll,u865Alternate,u865Color,u865Alpha);
	u865 = MAKE_PASS( u865BlendMode, u924, temp, u865BlendAmt);
	
	/*   Source u651  */
	temp = texture2D(u651Src, (POS_NORM * vec2( (1. / float(u651Rows )), 1.0) + vec2(((1. / float(u651Rows )) * float(u651Index) ),0.0) ));
	u651 = MAKE_PASS( u651BlendMode, u865, temp, u651BlendAmt);
	
	/* PASS  Light u852  */
	temp = Light(u651,0,POS_NORM,POS_FRAG,u852Mini,u852Invert,u852LightMode,u852Low,u852Light,u852High,u852Saturation,u852Shift,u852ColorMode,u852TintAmount,u852TintHue,u852Levels,u852Spacing,u852Smooth,u852Flip,u852Vibrance);
	gl_FragColor = MAKE_PASS( u852BlendMode, u651, temp, u852BlendAmt);
	if ( PASSINDEX == 0 ) { return; }
	
	/*   Deform u458  */
	temp = Deformu458(IMG_NORM_PIXEL(u852, POS_NORM),1,POS_NORM,POS_FRAG,u458Mini,u924,u458SrcAmount,u458Invert,u458Offset,u458XY,u458Zoom,u458Rotate,u458Degree,u458Origin);
	u458 = MAKE_PASS( u458BlendMode, IMG_NORM_PIXEL(u852, POS_NORM), temp, u458BlendAmt);
	
	/*   Source u832  */
	temp = texture2D(u832Src, (POS_NORM * vec2( (1. / float(u832Rows )), 1.0) + vec2(((1. / float(u832Rows )) * float(u832Index) ),0.0) ));
	u832 = MAKE_PASS( u832BlendMode, u458, temp, u832BlendAmt);
	
	/* PASS  Light u853  */
	temp = Light(u832,1,POS_NORM,POS_FRAG,u853Mini,u853Invert,u853LightMode,u853Low,u853Light,u853High,u853Saturation,u853Shift,u853ColorMode,u853TintAmount,u853TintHue,u853Levels,u853Spacing,u853Smooth,u853Flip,u853Vibrance);
	gl_FragColor = MAKE_PASS( u853BlendMode, u832, temp, u853BlendAmt);
	if ( PASSINDEX == 1 ) { return; }
	
	/*   Deform u749  */
	temp = Deformu749(IMG_NORM_PIXEL(u853, POS_NORM),2,POS_NORM,POS_FRAG,u749Mini,u865,u749SrcAmount,u749Invert,u749Offset,u749XY,u749Zoom,u749Rotate,u749Degree,u749Origin);
	u749 = MAKE_PASS( u749BlendMode, IMG_NORM_PIXEL(u853, POS_NORM), temp, u749BlendAmt);
	
	/*   Light u895  */
	temp = Light(u749,2,POS_NORM,POS_FRAG,u895Mini,u895Invert,u895LightMode,u895Low,u895Light,u895High,u895Saturation,u895Shift,u895ColorMode,u895TintAmount,u895TintHue,u895Levels,u895Spacing,u895Smooth,u895Flip,u895Vibrance);
	u895 = MAKE_PASS( u895BlendMode, u749, temp, u895BlendAmt);
	
	/*   Mask u958  */
	temp = Mask(u895,2,POS_NORM,POS_FRAG,u958Mode,u458,u749,u865,u958LightMode,u958Invert,u958Threshold,u958Smooth,u958SatInfluence);
	u958 = MAKE_PASS( u958BlendMode, u895, temp, u958BlendAmt);
	
	/*   Mask u147  */
	temp = Mask(u958,2,POS_NORM,POS_FRAG,u147Mode,u833,u958,u924,u147LightMode,u147Invert,u147Threshold,u147Smooth,u147SatInfluence);
	u147 = MAKE_PASS( u147BlendMode, u958, temp, u147BlendAmt);
	
	/* PASS  Mask u191  */
	temp = Mask(u147,2,POS_NORM,POS_FRAG,u191Mode,u833,u147,u833,u191LightMode,u191Invert,u191Threshold,u191Smooth,u191SatInfluence);
	gl_FragColor = MAKE_PASS( u191BlendMode, u147, temp, u191BlendAmt);
	if ( PASSINDEX == 2 ) { return; }
	
	/* PASS  Convolution u824  */
	temp = Convolutionu824(IMG_NORM_PIXEL(u191, POS_NORM),3,POS_NORM,POS_FRAG,u824TYPE,u824Amt,u824Threshold,u824Radius,u824Jitter);
	gl_FragColor = MAKE_PASS( u824BlendMode, IMG_NORM_PIXEL(u191, POS_NORM), temp, u824BlendAmt);
	if ( PASSINDEX == 3 ) { return; }
}
/*--BEGIN_PROJECT--{"_PREVIEW":"Convolution:u824","_PROJECTION":{"rotate":[0,0,0],"skew":[0,0],"scale":[1,1],"translate":[0,0]},"_TITLES":{},"_SOURCES":[],"_SEQUENCE":[["Source:u763","Light:u833"],["Shape:u924"],["Shape:u865"],["Source:u651","Light:u852","Deform:u458"],["Source:u832","Light:u853","Deform:u749"],["Light:u895"],["Mask:u958"],["Mask:u147"],["Mask:u191"],["Convolution:u824"]],"_UNIFORMS":{"u763BlendMode":0,"u763BlendAmt":1,"u763Src":{"type":"camera","path":"FaceTime HD Camera (3A71:F4B5)"},"u763Rows":1,"u763Columns":1,"u763Index":0,"u833BlendMode":0,"u833BlendAmt":1,"u833Mini":false,"u833Invert":false,"u833LightMode":0,"u833Low":0,"u833Light":0,"u833High":1,"u833Saturation":0,"u833Shift":0,"u833ColorMode":0,"u833TintAmount":0,"u833TintHue":0,"u833Levels":0,"u833Spacing":0.5,"u833Smooth":0,"u833Flip":false,"u833Vibrance":0,"u924BlendMode":0,"u924BlendAmt":1,"u924Mode":0,"u924ShapeMode":0,"u924Mask":-1,"u924Shape":3,"u924Circular":0,"u924Smooth":0,"u924Size":0.5,"u924Center":[0.5,0.5],"u924Rotate":0.5,"u924Invert":false,"u924Fit":false,"u924Recursion":0.5,"u924Scroll":0,"u924Alternate":0,"u924Color":[1,1,1],"u924Alpha":false,"u865BlendMode":0,"u865BlendAmt":1,"u865Mode":0,"u865ShapeMode":0,"u865Mask":-1,"u865Shape":3,"u865Circular":0,"u865Smooth":0,"u865Size":0.5,"u865Center":[0.5,0.5],"u865Rotate":0.5,"u865Invert":false,"u865Fit":false,"u865Recursion":0.5,"u865Scroll":0,"u865Alternate":0,"u865Color":[1,1,1],"u865Alpha":false,"u651BlendMode":0,"u651BlendAmt":1,"u651Src":{"type":"feedback"},"u651Rows":1,"u651Columns":1,"u651Index":0,"u852BlendMode":0,"u852BlendAmt":1,"u852Mini":true,"u852Invert":false,"u852LightMode":0,"u852Low":0,"u852Light":-0.05078125,"u852High":1,"u852Saturation":0,"u852Shift":0,"u852ColorMode":1,"u852TintAmount":0.6396484375,"u852TintHue":13.0078125,"u852Levels":0,"u852Spacing":0.5,"u852Smooth":0,"u852Flip":false,"u852Vibrance":0,"u458BlendMode":0,"u458BlendAmt":1,"u458Mini":true,"u458Src":924,"u458SrcAmount":1,"u458Invert":false,"u458Offset":0,"u458XY":[0.03125,0],"u458Zoom":[0.072265625,0.05078125],"u458Rotate":true,"u458Degree":-0.009765625,"u458Origin":[0.5,0.5],"u832BlendMode":0,"u832BlendAmt":1,"u832Src":{"type":"feedback"},"u832Rows":1,"u832Columns":1,"u832Index":0,"u853BlendMode":0,"u853BlendAmt":1,"u853Mini":true,"u853Invert":false,"u853LightMode":0,"u853Low":0,"u853Light":0.009765625,"u853High":1,"u853Saturation":0,"u853Shift":0,"u853ColorMode":1,"u853TintAmount":0.5673828125,"u853TintHue":-179.6484375,"u853Levels":0,"u853Spacing":0.5,"u853Smooth":0,"u853Flip":false,"u853Vibrance":0,"u749BlendMode":0,"u749BlendAmt":1,"u749Mini":true,"u749Src":865,"u749SrcAmount":1,"u749Invert":false,"u749Offset":0,"u749XY":[0,0.009765625],"u749Zoom":[0.216796875,0.072265625],"u749Rotate":true,"u749Degree":0.05078125,"u749Origin":[0.5,0.5],"u895BlendMode":0,"u895BlendAmt":1,"u895Mini":false,"u895Invert":false,"u895LightMode":0,"u895Low":0,"u895Light":0,"u895High":1,"u895Saturation":0,"u895Shift":0,"u895ColorMode":0,"u895TintAmount":0,"u895TintHue":0,"u895Levels":0,"u895Spacing":0.5,"u895Smooth":0,"u895Flip":false,"u895Vibrance":0,"u958BlendMode":0,"u958BlendAmt":1,"u958Mode":1,"u958Background":458,"u958Foreground":749,"u958Mask":865,"u958LightMode":0,"u958Invert":false,"u958Threshold":[0.4521484375,1],"u958Smooth":[0,0],"u958SatInfluence":0,"u147BlendMode":0,"u147BlendAmt":1,"u147Mode":1,"u147Background":833,"u147Foreground":958,"u147Mask":924,"u147LightMode":0,"u147Invert":true,"u147Threshold":[0,1],"u147Smooth":[0,0],"u147SatInfluence":0,"u191BlendMode":0,"u191BlendAmt":1,"u191Mode":1,"u191Background":833,"u191Foreground":147,"u191Mask":833,"u191LightMode":0,"u191Invert":false,"u191Threshold":[0.3798828125,1],"u191Smooth":[0,0],"u191SatInfluence":0,"u824BlendMode":0,"u824BlendAmt":1,"u824TYPE":0,"u824Amt":0.390625,"u824Threshold":0.2,"u824Radius":0.046875,"u824Jitter":false,"u749Rows":1,"u749Columns":1,"u749Index":0,"u914BlendMode":0,"u914BlendAmt":1,"u914Mode":0,"u914ShapeMode":0,"u914Mask":-1,"u914Shape":3,"u914Circular":0,"u914Smooth":0,"u914Size":0.5,"u914Center":[0.5,0.5],"u914Rotate":0.5,"u914Invert":false,"u914Fit":false,"u914Recursion":0.5,"u914Scroll":0,"u914Alternate":0,"u914Color":[1,1,1],"u914Alpha":false},"_CURRENT_VIEW":"application","_DIMENSIONS":{"width":1280,"height":720},"_ASSIGNMENTS":{},"_HIDDEN":{"u924Mask":true,"u924Recursion":true,"u924Scroll":true,"u924Alternate":true,"u865Mask":true,"u865Recursion":true,"u865Scroll":true,"u865Alternate":true,"u852TintAmount":false,"u852TintHue":false,"u852Levels":true,"u852Spacing":true,"u852Smooth":true,"u852Vibrance":true,"u853TintAmount":false,"u853TintHue":false,"u853Levels":true,"u853Spacing":true,"u853Smooth":true,"u853Vibrance":true,"u895TintAmount":true,"u895TintHue":true,"u895Levels":true,"u895Spacing":true,"u895Smooth":true,"u895Vibrance":true,"u958Foreground":false,"u958Mask":false,"u958LightMode":false,"u147Foreground":false,"u147Mask":false,"u147LightMode":false,"u191Foreground":false,"u191Mask":false,"u191LightMode":false,"u833TintAmount":true,"u833TintHue":true,"u833Levels":true,"u833Spacing":true,"u833Smooth":true,"u833Vibrance":true,"u924undefined":true,"u865undefined":true,"u458undefined":true,"u749undefined":true,"u958undefined":true,"u147undefined":true,"u191undefined":true}}--END_PROJECT--*/
