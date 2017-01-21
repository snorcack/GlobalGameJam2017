Shader "Unlit/Transparent HSB"
{
    Properties
    {
        _MainTex ("Base (RGB), Alpha (A)", 2D) = "black" {}
        _Color ("Main Color", COLOR) = (1,1,1,1)

        [Header(Hue and Saturation)] 
        _Hue ("Hue", Range (0,1)) = 0
        _Brightness ("Brightness", Range (0,1)) = 0.5
        _Contrast ("Contrast", Range (0,1)) = 0.5
        _Saturation ("Saturation", Range (0,1)) =0.5
        _StencilComp ("Stencil Comparison", Float) = 8
    }
 
    SubShader
    {
        LOD 100
 
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }
        			Stencil {

				Ref [_StencilComp]
				Comp equal
				pass replace 

			}
        Cull Off
        Lighting Off
        ZWrite Off
        Fog { Mode Off }
        Offset -1, -1
        Blend SrcAlpha OneMinusSrcAlpha
 
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
             
            #include "UnityCG.cginc"
            #include "HSB.cginc"
 
            struct appdata_t
            {
                float4 vertex : POSITION;
                float2 texcoord : TEXCOORD0;
                fixed4 color : COLOR;
            };
 
            struct v2f
            {
                float4 vertex : SV_POSITION;
                half2 texcoord : TEXCOORD0;
                fixed4 color : COLOR;
            };
 
            sampler2D _MainTex;
            fixed4 _Color;
            Float _Hue;
            Float _Brightness;
            Float _Contrast;
            Float _Saturation;
         
            v2f vert (appdata_t v)
            {
                v2f o;
                o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
                o.texcoord = v.texcoord;
                o.color = v.color;
                return o;
            }
             
            fixed4 frag (v2f i) : COLOR
            {
                float4 startColor = tex2D(_MainTex, i.texcoord);
                //2.0 + (B-R)/(max-min)

               // _Hue = 2.0 + (_Color.b-_Color.r)/ (_Color.g - _Color.b);
                fixed4 targetHue = fixed4 (_Hue, _Brightness, _Contrast, _Saturation);
                float4 hsbColor = applyHSBEffect(startColor, targetHue);
                return hsbColor;
            }
            ENDCG
        }
    }
 
    SubShader
    {
        LOD 100
 
        Tags
        {
            "Queue" = "Transparent"
            "IgnoreProjector" = "True"
            "RenderType" = "Transparent"
        }
     
        Pass
        {
            Cull Off
            Lighting Off
            ZWrite Off
            Fog { Mode Off }
            Offset -1, -1
            ColorMask RGB
            //AlphaTest Greater .01
            Blend SrcAlpha OneMinusSrcAlpha
            ColorMaterial AmbientAndDiffuse
         
            SetTexture [_MainTex]
            {
                Combine Texture * Primary
            }
        }
    }
}
 