Shader "Unlit/WaveAreaShader"
{
	Properties
	{
		
		_StencilComp ("Stencil Comparison", Float) = 8
	}
	SubShader
	{
		Tags { "RenderType"="Transparent + 10" }
		LOD 100

		Pass
		{
		ColorMask 0
		Stencil {

				Ref [_StencilComp]
				Comp always
				pass replace 

			}

		}
	}
}
