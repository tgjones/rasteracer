using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Lights;

namespace Rasteracer.Framework.Content
{
	public class PointLightReader : LightReader<PointLight>
	{
		protected override PointLight CreateAndPopulateObject(ContentReader input)
		{
			return new PointLight { Location = input.ReadVector3() };
		}
	}
}
