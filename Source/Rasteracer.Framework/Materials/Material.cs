using System;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Materials
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
