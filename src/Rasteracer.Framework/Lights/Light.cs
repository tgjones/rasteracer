using Microsoft.Xna.Framework;

namespace Rasteracer.Framework.Lights
{
	public abstract class Light
	{
		public FloatColour Colour;

		public abstract Vector3 GetDirectionToLight(Vector3 point);
	}
}
