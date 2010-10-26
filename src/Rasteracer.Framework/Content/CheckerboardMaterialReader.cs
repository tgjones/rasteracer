using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Materials;

namespace Rasteracer.Framework.Content
{
	public class CheckerboardMaterialReader : MaterialReader<CheckerboardMaterial>
	{
		protected override CheckerboardMaterial CreateAndPopulateObject(ContentReader input)
		{
			return new CheckerboardMaterial { AlternateColour = input.ReadObject<FloatColour>() };
		}
	}
}
