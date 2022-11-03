// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "Hand Painted 2D/Flame"
{
	Properties
	{
		[HideInInspector] _AlphaCutoff("Alpha Cutoff ", Range(0, 1)) = 0.5
		[HideInInspector] _EmissionColor("Emission Color", Color) = (1,1,1,1)
		_FlameMap("Flame Map", 2D) = "white" {}
		[Toggle(_FLAMEBOTTOM_ON)] _FlameBottom("Flame Bottom", Float) = 0
		[ASEEnd][KeywordEnum(Orange,Blue)] _FlameColor("Flame Color", Float) = 0

	}

	SubShader
	{
		LOD 0

		

		Tags { "RenderPipeline"="UniversalPipeline" "RenderType"="Transparent" "Queue"="Transparent" "PreviewType"="Plane" }

		Cull Off
		HLSLINCLUDE
		#pragma target 2.0
		
		#pragma prefer_hlslcc gles
		#pragma exclude_renderers d3d11_9x 

		ENDHLSL

		
		Pass
		{
			Name "Unlit"
			

			Blend SrcAlpha OneMinusSrcAlpha, One OneMinusSrcAlpha
			ZTest LEqual
			ZWrite Off
			Offset 0 , 0
			ColorMask RGBA
			

			HLSLPROGRAM
			
			#define ASE_SRP_VERSION 999999

			
			#pragma vertex vert
			#pragma fragment frag

			#pragma multi_compile _ ETC1_EXTERNAL_ALPHA

			#define _SURFACE_TYPE_TRANSPARENT 1
			#define SHADERPASS_SPRITEUNLIT

			#include "Packages/com.unity.render-pipelines.core/ShaderLibrary/Color.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Core.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/Lighting.hlsl"
			#include "Packages/com.unity.render-pipelines.universal/ShaderLibrary/ShaderGraphFunctions.hlsl"

			#include "Packages/com.unity.shadergraph/ShaderGraphLibrary/Functions.hlsl"
			#pragma shader_feature_local _FLAMECOLOR_ORANGE _FLAMECOLOR_BLUE
			#pragma shader_feature_local _FLAMEBOTTOM_ON


			sampler2D _FlameMap;


			struct VertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 uv0 : TEXCOORD0;
				float4 color : COLOR;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};

			struct VertexOutput
			{
				float4 clipPos : SV_POSITION;
				float4 texCoord0 : TEXCOORD0;
				float4 color : TEXCOORD1;
				
				UNITY_VERTEX_INPUT_INSTANCE_ID
				UNITY_VERTEX_OUTPUT_STEREO
			};

			#if ETC1_EXTERNAL_ALPHA
				TEXTURE2D( _AlphaTex ); SAMPLER( sampler_AlphaTex );
				float _EnableAlphaTexture;
			#endif

			float4 _RendererColor;

			
			float4 SampleGradient( Gradient gradient, float time )
			{
				float3 color = gradient.colors[0].rgb;
				UNITY_UNROLL
				for (int c = 1; c < 8; c++)
				{
				float colorPos = saturate((time - gradient.colors[c-1].w) / ( 0.00001 + (gradient.colors[c].w - gradient.colors[c-1].w)) * step(c, gradient.colorsLength-1));
				color = lerp(color, gradient.colors[c].rgb, lerp(colorPos, step(0.01, colorPos), gradient.type));
				}
				#ifndef UNITY_COLORSPACE_GAMMA
				color = SRGBToLinear(color);
				#endif
				float alpha = gradient.alphas[0].x;
				UNITY_UNROLL
				for (int a = 1; a < 8; a++)
				{
				float alphaPos = saturate((time - gradient.alphas[a-1].y) / ( 0.00001 + (gradient.alphas[a].y - gradient.alphas[a-1].y)) * step(a, gradient.alphasLength-1));
				alpha = lerp(alpha, gradient.alphas[a].x, lerp(alphaPos, step(0.01, alphaPos), gradient.type));
				}
				return float4(color, alpha);
			}
			
			float3 mod2D289( float3 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float2 mod2D289( float2 x ) { return x - floor( x * ( 1.0 / 289.0 ) ) * 289.0; }
			float3 permute( float3 x ) { return mod2D289( ( ( x * 34.0 ) + 1.0 ) * x ); }
			float snoise( float2 v )
			{
				const float4 C = float4( 0.211324865405187, 0.366025403784439, -0.577350269189626, 0.024390243902439 );
				float2 i = floor( v + dot( v, C.yy ) );
				float2 x0 = v - i + dot( i, C.xx );
				float2 i1;
				i1 = ( x0.x > x0.y ) ? float2( 1.0, 0.0 ) : float2( 0.0, 1.0 );
				float4 x12 = x0.xyxy + C.xxzz;
				x12.xy -= i1;
				i = mod2D289( i );
				float3 p = permute( permute( i.y + float3( 0.0, i1.y, 1.0 ) ) + i.x + float3( 0.0, i1.x, 1.0 ) );
				float3 m = max( 0.5 - float3( dot( x0, x0 ), dot( x12.xy, x12.xy ), dot( x12.zw, x12.zw ) ), 0.0 );
				m = m * m;
				m = m * m;
				float3 x = 2.0 * frac( p * C.www ) - 1.0;
				float3 h = abs( x ) - 0.5;
				float3 ox = floor( x + 0.5 );
				float3 a0 = x - ox;
				m *= 1.79284291400159 - 0.85373472095314 * ( a0 * a0 + h * h );
				float3 g;
				g.x = a0.x * x0.x + h.x * x0.y;
				g.yz = a0.yz * x12.xz + h.yz * x12.yw;
				return 130.0 * dot( m, g );
			}
			

			VertexOutput vert( VertexInput v  )
			{
				VertexOutput o = (VertexOutput)0;
				UNITY_SETUP_INSTANCE_ID( v );
				UNITY_TRANSFER_INSTANCE_ID( v, o );
				UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO( o );

				
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					float3 defaultVertexValue = v.vertex.xyz;
				#else
					float3 defaultVertexValue = float3( 0, 0, 0 );
				#endif
				float3 vertexValue = defaultVertexValue;
				#ifdef ASE_ABSOLUTE_VERTEX_POS
					v.vertex.xyz = vertexValue;
				#else
					v.vertex.xyz += vertexValue;
				#endif
				v.normal = v.normal;

				VertexPositionInputs vertexInput = GetVertexPositionInputs( v.vertex.xyz );

				o.texCoord0 = v.uv0;
				o.color = v.color;
				o.clipPos = vertexInput.positionCS;

				return o;
			}

			half4 frag( VertexOutput IN  ) : SV_Target
			{
				UNITY_SETUP_INSTANCE_ID( IN );
				UNITY_SETUP_STEREO_EYE_INDEX_POST_VERTEX( IN );

				Gradient gradient30_g22 = NewGradient( 0, 4, 2, float4( 0.9882353, 0.5215687, 0.4235294, 0.1191424 ), float4( 0.9921569, 0.6941177, 0.4627451, 0.2141909 ), float4( 0.9921569, 0.7764706, 0.4941176, 0.8326696 ), float4( 0.9960784, 0.8705882, 0.5019608, 0.9531395 ), 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
				float temp_output_14_0_g22 = ( 1.0 - IN.texCoord0.xy.y );
				Gradient gradient10_g22 = NewGradient( 0, 3, 2, float4( 0, 0, 0, 0 ), float4( 1, 1, 1, 0.5000076 ), float4( 0, 0, 0, 1 ), 0, 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
				float2 break4_g22 = ( IN.texCoord0.xy * float2( 0.1,0.1 ) );
				float mulTime6_g22 = _TimeParameters.x * -0.5;
				float4 transform3_g22 = mul(GetObjectToWorldMatrix(),float4( 0,0,0,1 ));
				float temp_output_5_0_g22 = ( transform3_g22.z * 10.0 );
				float2 appendResult8_g22 = (float2(break4_g22.x , ( break4_g22.y + mulTime6_g22 + transform3_g22.x + transform3_g22.y + temp_output_5_0_g22 )));
				float simplePerlin2D11_g22 = snoise( appendResult8_g22*4.0 );
				simplePerlin2D11_g22 = simplePerlin2D11_g22*0.5 + 0.5;
				float temp_output_13_0_g22 = ( simplePerlin2D11_g22 * 2.0 );
				float temp_output_25_0_g22 = (0.0 + (( ( temp_output_14_0_g22 * SampleGradient( gradient10_g22, IN.texCoord0.xy.x ).r * temp_output_14_0_g22 * temp_output_13_0_g22 ) * temp_output_13_0_g22 ) - 0.0) * (1.0 - 0.0) / (2.0 - 0.0));
				Gradient gradient26_g22 = NewGradient( 0, 4, 2, float4( 0.4156862, 0.9400152, 0.945098, 0.07095445 ), float4( 0.4156863, 0.7019608, 0.945098, 0.2141909 ), float4( 0.4588236, 0.7874286, 0.9764706, 0.9785764 ), float4( 0.7179847, 0.6666667, 1, 1 ), 0, 0, 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
				#if defined(_FLAMECOLOR_ORANGE)
				float4 staticSwitch34_g22 = SampleGradient( gradient30_g22, temp_output_25_0_g22 );
				#elif defined(_FLAMECOLOR_BLUE)
				float4 staticSwitch34_g22 = SampleGradient( gradient26_g22, temp_output_25_0_g22 );
				#else
				float4 staticSwitch34_g22 = SampleGradient( gradient30_g22, temp_output_25_0_g22 );
				#endif
				float4 break37_g22 = staticSwitch34_g22;
				float2 break15_g22 = ( IN.texCoord0.xy * float2( 0.2,0.2 ) );
				float mulTime16_g22 = _TimeParameters.x * -1.0;
				float2 appendResult22_g22 = (float2(break15_g22.x , ( break15_g22.y + mulTime16_g22 + transform3_g22.x + transform3_g22.y + temp_output_5_0_g22 )));
				#ifdef _FLAMEBOTTOM_ON
				float staticSwitch28_g22 = IN.texCoord0.xy.y;
				#else
				float staticSwitch28_g22 = 1.0;
				#endif
				Gradient gradient23_g22 = NewGradient( 0, 6, 2, float4( 0, 0, 0, 0 ), float4( 0.5882353, 0.5882353, 0.5882353, 0.3000076 ), float4( 1, 1, 1, 0.4 ), float4( 1, 1, 1, 0.6 ), float4( 0.5882353, 0.5882353, 0.5882353, 0.7000076 ), float4( 0, 0, 0, 1 ), 0, 0, float2( 1, 0 ), float2( 1, 1 ), 0, 0, 0, 0, 0, 0 );
				float temp_output_35_0_g22 = saturate( ( tex2D( _FlameMap, appendResult22_g22 ).r * tex2D( _FlameMap, appendResult8_g22 ).r * staticSwitch28_g22 * temp_output_14_0_g22 * SampleGradient( gradient23_g22, IN.texCoord0.xy.x ).r * temp_output_13_0_g22 ) );
				float smoothstepResult36_g22 = smoothstep( 0.07 , 0.09 , temp_output_35_0_g22);
				float4 appendResult39_g22 = (float4(break37_g22.r , break37_g22.g , break37_g22.b , smoothstepResult36_g22));
				
				float4 Color = appendResult39_g22;

				#if ETC1_EXTERNAL_ALPHA
					float4 alpha = SAMPLE_TEXTURE2D( _AlphaTex, sampler_AlphaTex, IN.texCoord0.xy );
					Color.a = lerp( Color.a, alpha.r, _EnableAlphaTexture );
				#endif

				Color *= IN.color;

				return Color;
			}

			ENDHLSL
		}
	}
	
	Fallback "Hidden/InternalErrorShader"
	
}
/*ASEBEGIN
Version=18912
124;146;1089;689;-2348.202;-855.1323;1;True;False
Node;AmplifyShaderEditor.FunctionNode;260;2794.462,1199.075;Inherit;False;Flame;0;;22;9fc766ece6f51465e80cc609576ec4dd;0;0;1;FLOAT4;0
Node;AmplifyShaderEditor.TemplateMultiPassMasterNode;187;3006.499,1199.933;Float;False;True;-1;2;;0;13;Hand Painted 2D/Flame;cf964e524c8e69742b1d21fbe2ebcc4a;True;Unlit;0;0;Unlit;3;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;2;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;4;RenderPipeline=UniversalPipeline;RenderType=Transparent=RenderType;Queue=Transparent=Queue=0;PreviewType=Plane;True;0;True;17;d3d9;d3d11;glcore;gles;gles3;metal;vulkan;xbox360;xboxone;xboxseries;ps4;playstation;psp2;n3ds;wiiu;switch;nomrt;0;False;True;2;5;False;-1;10;False;-1;3;1;False;-1;10;False;-1;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;True;True;True;True;0;False;-1;False;False;False;False;False;False;False;True;False;255;False;-1;255;False;-1;255;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;7;False;-1;1;False;-1;1;False;-1;1;False;-1;False;True;2;False;-1;True;3;False;-1;True;True;0;False;-1;0;False;-1;True;0;False;False;0;Hidden/InternalErrorShader;0;0;Standard;1;Vertex Position;1;0;1;True;False;;False;0
WireConnection;187;1;260;0
ASEEND*/
//CHKSM=8045DC800266ABFE0C3354E8D0FD62886A1943B9