/******************************************************
* Begin Defines
******************************************************/

#define NumPointLights 3

/******************************************************
* End Defines
******************************************************/

/******************************************************
* Begin Parameters
******************************************************/

matrix World, ViewProjection;

/******************************************************
* End Parameters
******************************************************/

/******************************************************
* Begin Materials
******************************************************/

struct MaterialType
{
	float3 Colour;
};

struct CheckerboardMaterialType
{
	float3 Colour;
	float3 AlternateColour;
};

float3 Material_GetColour(MaterialType material, float3 point)
{
	return material.Colour;
}

float3 CheckerboardMaterial_GetColour(CheckerboardMaterialType material, float3 point)
{
	return ((floor(point.x) % 2 == 0 && floor(point.z) % 2 == 0)
		|| (abs(floor(point.x)) % 2 == 1 && abs(floor(point.z)) % 2 == 1))
		? material.Colour : material.AlternateColour;
}

MaterialType Material;
CheckerboardMaterialType CheckerboardMaterial;

/******************************************************
* End Materials
******************************************************/

/******************************************************
* Begin Lights
******************************************************/

struct PointLight
{
	float3 Colour;
	float3 Location;
};

float3 PointLight_GetDirectionToLight(PointLight light, float3 point)
{
	return normalize(light.Location - point);
}

PointLight PointLights[NumPointLights];

/******************************************************
* End Lights
******************************************************/

struct VertexShaderInput
{
	float3 Position : POSITION0;
	float3 Normal   : NORMAL0;
	float2 TexCoord : TEXCOORD0;
};

struct VertexShaderOutput
{
	float4 Position : POSITION0;
	float3 Normal   : TEXCOORD0;
	float3 WorldPos : TEXCOORD1;
};

VertexShaderOutput VertexShaderFunction(VertexShaderInput input)
{
	VertexShaderOutput output;
	output.WorldPos = mul(float4(input.Position, 1), World);
	output.Position = mul(float4(output.WorldPos, 1), ViewProjection);
	output.Normal = input.Normal;
	return output;
}

float4 PixelShaderFunction(uniform MaterialType material, VertexShaderOutput input) : COLOR0
{
	// calculate diffuse lighting
	float3 outputColour = float3(0, 0, 0);
	for (int i = 0; i < NumPointLights; i++)
	{
		float3 directionToLight = PointLight_GetDirectionToLight(PointLights[i], input.WorldPos);
		float3 lightFactor = saturate(dot(directionToLight, input.Normal));
		float3 materialColour = Material_GetColour(material, input.WorldPos);
		outputColour += (materialColour * lightFactor) * PointLights[i].Colour;
	}
	outputColour = saturate(outputColour);
	
	return float4(outputColour, 1);
}

float4 PixelShaderFunction(uniform CheckerboardMaterialType material, VertexShaderOutput input) : COLOR0
{
	// calculate diffuse lighting
	float3 outputColour = float3(0, 0, 0);
	for (int i = 0; i < NumPointLights; i++)
	{
		float3 directionToLight = PointLight_GetDirectionToLight(PointLights[i], input.WorldPos);
		float3 lightFactor = saturate(dot(directionToLight, input.Normal));
		float3 materialColour = CheckerboardMaterial_GetColour(material, input.WorldPos);
		outputColour += (materialColour * lightFactor) * PointLights[i].Colour;
	}
	outputColour = saturate(outputColour);
	
	return float4(outputColour, 1);
}

technique TechniqueMaterial
{
	pass
	{
		VertexShader = compile vs_2_0 VertexShaderFunction();
		PixelShader = compile ps_2_0 PixelShaderFunction(Material);
	}
}

technique TechniqueCheckerboardMaterial
{
	pass
	{
		VertexShader = compile vs_2_0 VertexShaderFunction();
		PixelShader = compile ps_2_0 PixelShaderFunction(CheckerboardMaterial);
	}
}