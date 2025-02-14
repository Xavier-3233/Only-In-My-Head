#if OPENGL
#define VS_SHADERMODEL vs_3_0
#define PS_SHADERMODEL ps_3_0
#else
#define VS_SHADERMODEL vs_4_0
#define PS_SHADERMODEL ps_4_0
#endif

float4x4 view_projection;
sampler TextureSampler : register(s0);

struct VertexInput {
    float4 Position : POSITION0;
    float4 Color : COLOR0;
    float4 TexCoord : TEXCOORD0;
};

struct PixelInput {
    float4 Position : SV_Position0;
    float4 Color : COLOR0;
    float4 TexCoord : TEXCOORD0;
};

PixelInput SpriteVertexShader(VertexInput v) {
    PixelInput output;

    // Apply the view_projection matrix to transform the vertex position
    output.Position = mul(v.Position, view_projection);
    output.Color = v.Color;
    output.TexCoord = v.TexCoord;
    return output;
}

float4 SpritePixelShader(PixelInput p) : SV_TARGET {
    // Sample the texture color at the given texture coordinates
    float4 diffuse = tex2D(TextureSampler, p.TexCoord.xy);
    
    // Convert to grayscale using the luminance formula
    float gray = dot(diffuse.rgb, float3(0.3, 0.59, 0.11));

    // Create the grayscale color by setting all RGB channels to the computed gray value
    float4 grayColor = float4(gray, gray, gray, diffuse.a);

    // Multiply by the input color to apply any tint or transparency
    return grayColor * p.Color;
}

technique SpriteBatch {
    pass {
        VertexShader = compile VS_SHADERMODEL SpriteVertexShader();
        PixelShader = compile PS_SHADERMODEL SpritePixelShader();
    }
}
