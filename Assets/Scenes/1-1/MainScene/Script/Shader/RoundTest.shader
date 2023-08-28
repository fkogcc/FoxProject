Shader "Custom/RoundTest"
{
    Properties
    {
        _BaseTex("BaseTexture(RGBA)", 2D) = "white"{}
        _MainTex("MainTexture(RGBA)", 2D) = "white"{}
    }
    SubShader
    {
        Tags { "Queue"="Transparent" "IgnoreProject" = "True" "RenderType" = "Transparent"}
        LOD 100

        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #pragma multi_compile_fog

            #include "UnityCG.cginc"
            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _BaseTex;
            sampler2D _MainTex;
            float4 _MainTex_ST;

            v2f vert(appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o, o.vertex);
                return o;
            }

            fixed4 frag(v2f i) : SV_Target
            {
                fixed4 baseColor = tex2D(_BaseTex, i.uv);
                fixed4 mainColor = tex2D(_MainTex, i.uv);
                fixed4 color = baseColor * mainColor;

                UNITY_APPLY_FOG(i.fogCoord, color);
                return color;
            }
            ENDCG
        }
    }
}
