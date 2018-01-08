// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Cg shader for RGB cube" {
	SubShader{
		Pass{
		CGPROGRAM

#pragma vertex vert // vert function is the vertex shader 
#pragma fragment frag // frag function is the fragment shader
#include "UnityCG.cginc"

		// for multiple vertex output parameters an output structure 
		// is defined:
		struct vertexOutput {
		float4 pos : SV_POSITION;
		float4 col : TEXCOORD0;

	};
	struct vertexInput {
		float4 vertex : POSITION; // position (in object coordinates, 
								  // i.e. local or model coordinates)
		float4 tangent : TANGENT;
		// vector orthogonal to the surface normal
		float3 normal : NORMAL; // surface normal vector (in object
								// coordinates; usually normalized to unit length)
		float4 texcoord : TEXCOORD0;  // 0th set of texture 
									  // coordinates (a.k.a. “UV”; between 0 and 1) 
		float4 texcoord1 : TEXCOORD1; // 1st set of tex. coors. 
		float4 texcoord2 : TEXCOORD2; // 2nd set of tex. coors. 
		float4 texcoord3 : TEXCOORD3; // 3rd set of tex. coors. 
		float4 color : COLOR; // color (usually constant)
	};

	vertexOutput vert(appdata_full input)
	{
		vertexOutput output;

		//output.pos = UnityObjectToClipPos(input.vertex);
		//output.col = input.texcoord;
		//output.col = float4(0.0, 0.0, 0.0, 1.0);
		//Was black becuase alpha was set to 0 and all rgb values were more than one,
		//pUT RGB VALUES LESS than one and put alpha to 1 to get colour
		//output.col = input.texcoord + float4(0.8, 0.5, 0.2, 1.0);

		//Takes 4 values rgba, if all 4 values are z the shader is black , z value is 0
		//output.col = input.texcoord.xyzz;

		//Deviding by 0, to fix but in any value between 0 and 1 for tan
		//output.col = input.texcoord / tan(0.5);

		//Changed with direcional lighting, needs w as an argument for input.tangent
		// output.col = dot(input.normal, input.tangent.wxyz) *
			//input.texcoord;
		//return output;

		//Cant multiply normal by normal, must be a tangent
	//	output.col = dot(cross(input.normal, input.tangent.xyz),
			//input.tangen.wxyz) * input.texcoord;

		//  output.col = float4(cross(input.normal, input.normal), 1.0);

		//output.col = float4(cross(input.normal, 
		//input.vertex.xyz), 1.0);
		// only for a sphere!


		//To find angle facing camera, cant find radians as a function
		//output.col = radians(input.texcoord);
	}//

	float4 frag(vertexOutput input) : COLOR
	{
		return input.col;
	}


		ENDCG
	}
	}
}