/*-------------------------------------------------

	System Designed,
	Code Written,
	by Kunihiro Sasakawa as s2kw@jigax.jp

-------------------------------------------------*/


Shader "jigaX/SkyBox/SkyTest000" {
	Properties {
		_Color ("Color", Color) = (1,1,1,1)
		//_Time( "Time", float ) = 0
	}
	SubShader {
		pass{
			Tags { "RenderType"="Opaque" }
			LOD 200

			CGPROGRAM
// Upgrade NOTE: excluded shader from DX11 and Xbox360; has structs without semantics (struct v2f members srcPos)
#pragma exclude_renderers d3d11 xbox360


			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			fixed4 _Color;
			//float _Time;
			float4 vert (float4 v:POSITION) : SV_POSITION{
				return mul(UNITY_MATRIX_MVP,v);
			}
			
			float4 frag( float4 sp : VPOS ) : SV_Target{
				float blue = 1.0-( sp.x / _ScreenParams.x + sp.y / _ScreenParams.y );
				
				//return _SinTime;
				//return _Time / 100;
				float height = sp.y / _ScreenParams.y;
				float width = sp.x / _ScreenParams.x;
				float t = _SinTime.x;
				return float4( height * width *t  + 0.5, height * t + 0.5,1.0,1.0);
			}
			
			ENDCG
		} // pass
	} 
}
