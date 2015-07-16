Shader "Toon/Lit Outline+Wallhack" 
{
	Properties
	 {
		_Color ("Main Color", Color) = (0.5,0.5,0.5,1)
		_Color2("Color2", Color) = (1,0,0,0)
		_OutlineColor ("Outline Color", Color) = (0,0,0,1)
		_Outline ("Outline width", Range (.002, 0.03)) = .005
		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Ramp ("Toon Ramp (RGB)", 2D) = "gray" {} 
	}

	Category
	{
		SubShader 
		{
				Tags { "RenderType"="Opaque" }
				Tags { "Queue"="Overlay+1" }
				//UsePass "Toon/Lit/FORWARD"
				UsePass "Toon/Basic Outline/OUTLINE"

			Pass
			 {
			 	ZWrite Off
			 	ZTest Greater
			 	Lighting Off
			 	Color[_Color2]
			 }
			
			Pass
			{
				ZTest Less
				SetTexture [_MainTex] {combine texture}
			}
		}
	}	
	Fallback "Toon/Lit Outline", 1

}
