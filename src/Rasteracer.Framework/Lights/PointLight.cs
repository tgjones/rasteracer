using Microsoft.Xna.Framework;

namespace Rasteracer.Framework.Lights
{
	public class PointLight : Light
	{
		public Vector3 Location;

		public override Vector3 GetDirectionToLight(Vector3 point)
		{
			return Location - point;
		}
	}
}
