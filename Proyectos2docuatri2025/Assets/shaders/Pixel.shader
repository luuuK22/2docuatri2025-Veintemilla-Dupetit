Shader"Hidden/PixelateEffect"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _PixelSize ("Pixel Size", Float) = 0.01
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
Cull Off
ZWrite Off
ZTest Always
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
#include "UnityCG.cginc"

sampler2D _MainTex;
float4 _MainTex_TexelSize;
float _PixelSize;

struct v2f
{
    float4 pos : SV_POSITION;
    float2 uv : TEXCOORD0;
};

v2f vert(appdata_img v)
{
    v2f o;
    o.pos = UnityObjectToClipPos(v.vertex);
    o.uv = v.texcoord;
    return o;
}

fixed4 frag(v2f i) : SV_Target
{
                // Calcula el tamaño del pixel en UV
    float2 pixelUV = floor(i.uv / _PixelSize) * _PixelSize;
    return tex2D(_MainTex, pixelUV);
}
            ENDCG
        }
    }
}