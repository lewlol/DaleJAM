Shader "Custom/OutlineShader"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _OutlineColor("Outline Color", Color) = (0, 1, 0, 1)
        _OutlineWidth("Outline Width", Range(0, 0.1)) = 0.02
    }

        SubShader
        {
            Tags { "Queue" = "Transparent" }
            LOD 100

            Pass
            {
                Tags { "LightMode" = "Always" }
                CGPROGRAM
                #pragma vertex vert
                #pragma fragment frag
                #include "UnityCG.cginc"

                struct appdata_t
                {
                    float4 vertex : POSITION;
                    float2 uv : TEXCOORD0;
                };

                struct v2f
                {
                    float4 vertex : SV_POSITION;
                    float2 uv : TEXCOORD0;
                };

                sampler2D _MainTex;
                float _OutlineWidth;
                float4 _OutlineColor;

                v2f vert(appdata_t v)
                {
                    v2f o;
                    o.vertex = UnityObjectToClipPos(v.vertex);
                    o.uv = v.uv;
                    return o;
                }

                fixed4 frag(v2f i) : SV_Target
                {
                    fixed4 col = tex2D(_MainTex, i.uv);
                    fixed4 outlineCol = _OutlineColor;

                    // Calculate the outline
                    fixed2 d = fwidth(i.uv);
                    fixed2 outline = smoothstep(1 - d, 1 + d, i.uv) * _OutlineWidth;

                    // Blend outline color with original color
                    return lerp(outlineCol, col, outline.x);
                }
                ENDCG
            }
        }
}