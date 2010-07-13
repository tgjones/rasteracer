using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Materials;

namespace TJ.RayTracing.Framework.Content
{
	public class CheckerboardMaterialReader : MaterialReader<CheckerboardMaterial>
	{
		protected override CheckerboardMaterial CreateAndPopulateObject(ContentReader input)
		{
			return new CheckerboardMaterial { AlternateColour = input.ReadObject<FloatColour>() };
		}
	}
}
