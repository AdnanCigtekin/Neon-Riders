Shader "CoreDumped/BuildingShader" {
	Properties {
		_MainTint ("Diffuse Tint",Color) = (1,1,1,1)
		_MainTex ("Base (RGB)", 2D) = "white" {}

	}
		SubShader{
			Tags { 
			"Queue" = "Transparent"
			"IgnoreProjector" = "True"
			"RenderType" = "Transparent"
		}
			LOD 200

			CGPROGRAM
			// Physically based Standard lighting model, and enable shadows on all light types
			#pragma surface surf Standard 

			// Use shader model 3.0 target, to get nicer looking lighting
			#pragma target 3.0
		
		fixed4 _MainTint;
		fixed _LerpSpeed;
		sampler2D _MainTex;

		struct Input {
			float2 uv_MainTex;
		};


		fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) {
			fixed2 scrolledUV = IN.uv_MainTex;


			

			float4 c = tex2D(_MainTex, IN.uv_MainTex) * _MainTint;
			o.Albedo = c.rgb * (_MainTint);
			

		}
		ENDCG
	}
	FallBack "Diffuse"
}
