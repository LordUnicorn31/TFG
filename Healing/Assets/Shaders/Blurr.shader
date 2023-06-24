Shader "Custom/Blurr"
{
    Properties
    {
        _MainTex("Texture", 2D) = "white" {}
        _BlurSize("Blur Size", Range(0, 10)) = 1
    }

        SubShader
        {
            Tags { "RenderType" = "Opaque" }
            LOD 100

            CGPROGRAM
            #pragma surface surf Lambert

            sampler2D _MainTex;
            fixed _BlurSize;

            struct Input
            {
                float2 uv_MainTex;
            };

            void surf(Input IN, inout SurfaceOutput o)
            {
                fixed4 c = fixed4(0, 0, 0, 0);
                float blurSize = _BlurSize * 0.01; // Scale the blur size to a reasonable range

                // Apply a simple Gaussian blur in both x and y directions
                for (int i = -5; i <= 5; i++)
                {
                    for (int j = -5; j <= 5; j++)
                    {
                        float2 offset = float2(i, j) * blurSize;
                        c += tex2D(_MainTex, IN.uv_MainTex + offset);
                    }
                }

                c /= 121.0; // Normalize the accumulated color

                o.Albedo = c.rgb;
                o.Alpha = c.a;
            }
            ENDCG
        }
}

