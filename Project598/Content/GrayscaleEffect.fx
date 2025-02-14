#if OPENGL
    #define VS_SHADERMODEL vs_3_0
    #define PS_SHADERMODEL ps_3_0
#else
    #define VS_SHADERMODEL vs_4_0_level_9_1
    #define PS_SHADERMODEL ps_4_0_level_9_1
#endif

matrix WorldViewProjection;

texture2D Texture : register(t0);
sampler2D TextureSampler : register(s0);

struct VertexShaderInput
{
    float4 Position : POSITION;
    float2 TexCoord : TEXCOORD0;
};

struct VertexShaderOutput
{
    float4 Position : SV_POSITION;
    float2 TexCoord : TEXCOORD0;
};

// Vertex Shader: Pass through
VertexShaderOutput MainVS(VertexShaderInput input)
{
    VertexShaderOutput output = (VertexShaderOutput)0;
    output.Position = mul(input.Position, WorldViewProjection);
    output.TexCoord = input.TexCoord; // Pass texture coordinates to pixel shader
    return output;
}

// Pixel Shader: Convert to a fixed grayscale color (0.5 for middle gray)
float4 MainPS(VertexShaderOutput input) : SV_Target
{
    return float4(1.0, 1.0, 1.0, 1.0); // Output a solid middle-gray color
}

// Technique: Simple grayscale pass
technique Grayscale
{
    pass P0
    {
        VertexShader = compile VS_SHADERMODEL MainVS();
        PixelShader = compile PS_SHADERMODEL MainPS();
    }
}