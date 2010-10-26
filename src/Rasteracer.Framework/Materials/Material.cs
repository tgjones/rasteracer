using Microsoft.Xna.Framework;

namespace Rasteracer.Framework.Materials
{
	public class Material
	{
		public FloatColour Colour;

		public virtual FloatColour GetColour(Vector3 tIntersection)
		{
			return Colour;
		}
	}
}
