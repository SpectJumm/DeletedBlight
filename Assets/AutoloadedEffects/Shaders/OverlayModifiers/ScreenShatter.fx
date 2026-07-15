sampler2D uImage0 : register(s0);

float3 uColor;       // Often used for custom vector data passed from C#
float uOpacity;     // General progress/intensity slider (0.0 to 1.0)
float2 uTargetPosition; // World position of the effect trigger (e.g., player position)
float uTime;         // Automatically incrementing time variable

struct PSInput
{
    float4 Pos : POSITION0;
    float2 UV  : TEXCOORD0;
};

float4 ScreenShatter(PSInput input) : COLOR0
{
    float2 uv = input.UV; // get the base screen coordinate


    // TODO: make the "glass shards" drift out from where they're made




    float4 color = tex2D(uImage0, uv); // sample the original image

    uv += frac(sin(dot(uv * 12.9898 + uTime * 0.1, float2(78.233, 43758.5453))) * 2.0 - 1.0) * 0.01; // add some random noise to the UVs for a glitch effect

    return color;
}

technique Technique1
{
    pass ScreenShatter
    {
        PixelShader = compile ps_3_0 ScreenShatter();
    }
}