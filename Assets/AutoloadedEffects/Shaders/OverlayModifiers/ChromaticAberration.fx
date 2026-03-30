sampler baseTexture : register(s0);
sampler colorTexture : register(s1);
sampler uImage2 : register(s2);
sampler uImage3 : register(s3);
float3 uColor;
float3 uSecondaryColor;
float2 uScreenResolution;
float2 uScreenPosition;
float2 uTargetPosition;
float2 uDirection;
float uOpacity;
float uTime;
float uIntensity;
float uProgress;
float2 uImageSize1;
float2 uImageSize2;
float2 uImageSize3;
float2 uImageOffset;
float uSaturation;
float4 uSourceRect;
float2 uZoom;
float4 uShaderSpecificData;

// Creates a chromatic aberration effect by offsetting the red and blue channels to the left and right, respectively, while keeping the green channel centered (I hope).
// Lucille Karma is my goddess and savior.
float4 ChromaticAberration(float4 sampleColor : COLOR0, float2 coords : TEXCOORD0) : COLOR
{
    float4 color = tex2D(baseTexture, coords);

    float splitDistance = sin(tan(uTime)) / 50; // TODO: make the splitDistance essentially random (from certain values ofc) to make the effect look more "glitchy"
    color.r = tex2D(baseTexture, coords + float2(-splitDistance, 0)).r; // Shift red channel left
    color.b = tex2D(baseTexture, coords + float2(splitDistance, 0)).b; // Shift blue channel right
    color.g = tex2D(baseTexture, coords).g; // Keep green channel centered

    return color;
}

technique Technique1
{
    pass ChromaticAberration
    {
        PixelShader = compile ps_2_0 ChromaticAberration();
    }
}