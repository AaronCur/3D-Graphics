// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced '_World2Object' with 'unity_WorldToObject'

Shader "ShaderSandbox/BasicsLighting/Gouraud Shading With Phong Model" {
	//https://en.wikibooks.org/wiki/Cg_Programming/Unity/Specular_Highlights

	Properties{
		// k_{\text{a}}, which is an ambient reflection constant, the ratio of reflection of the ambient term present in all points in the scene rendered, and
		_Ka("Ambient Reflectance", Float) = 1.0
		// k_{\text{d}}, which is a diffuse reflection constant, the ratio of reflection of the diffuse term of incoming light (Lambertian reflectance),
		_Kd("Lambertian Reflectance", Float) = 1.0
		// k_{\text{s}}, which is a specular reflection constant, the ratio of reflection of the specular term of incoming light,
		_Ks("Specular Reflectance", Float) = 1.0
		// \alpha , which is a shininess constant for this material, which is larger for surfaces that are smoother and more mirror-like. When this constant is large the specular highlight is small.
		_Alfa("Shininess", Float) = 10

		_DiffuseColor("Diffuse Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_SpecularColor("Specular Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}
		SubShader{
		Pass{
		// indicate that our pass is the "base" pass in forward
		// rendering pipeline. It gets ambient and main directional
		// light data set up; light direction in _WorldSpaceLightPos0
		// and color in _LightColor0
		Tags{ "LightMode" = "ForwardBase" }

		CGPROGRAM

#pragma vertex vert
#pragma fragment frag

		uniform float _Ka, _Kd, _Ks;
	uniform float _Alfa;
	uniform float4 _DiffuseColor;
	uniform float4 _SpecularColor;

	uniform float4 _LightColor0;

	struct appdata {
		float4 vertex : POSITION;
		float3 normal : NORMAL;
	};

	struct v2f {
		float4 position : SV_POSITION;
		float4 color : COLOR0;
	};

	v2f vert(appdata v) {
		v2f o;

		float4x4 modelMatrix = unity_ObjectToWorld;
		float3x3 modelMatrixInverse = unity_WorldToObject;

		// transform vertex position in clip space position
		o.position = UnityObjectToClipPos(v.vertex);

		float3 normalDir = normalize(mul(v.normal, modelMatrix));
		float3 lightDir = normalize(_WorldSpaceLightPos0.xyz);
		float3 viewDir = normalize(_WorldSpaceCameraPos - mul(modelMatrix, v.vertex).xyz);

		float4 ambientReflection = _Ka * UNITY_LIGHTMODEL_AMBIENT;

		float nl = max(0.0, dot(normalDir, lightDir));
		float3 diffuseReflection = _Kd * _DiffuseColor.rgb * _LightColor0.rgb * nl;

		// reflection of LightDir by the normal
		//float3 reflectedDir = 2.0 * ln * normalDir - lightDir;
		float3 reflectedDir = reflect(-lightDir, normalDir);
		float rv = max(0.0, dot(reflectedDir, viewDir));
		float specularAmount = pow(rv, _Alfa);
		float3 specularReflection = _Ks * _SpecularColor.rgb * _LightColor0.rgb * specularAmount;

		o.color = float4(ambientReflection + diffuseReflection + specularReflection, 1.0);

		return o;
	}

	fixed4 frag(v2f v) : SV_TARGET{
		return fixed4(v.color);
	}
		ENDCG
	}
	}
}