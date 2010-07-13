using System;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Materials
{
	public class CheckerboardMaterial : Material
	{
		public FloatColour AlternateColour;

		public override FloatColour GetColour(Vector3 tIntersection)
		{
			return (((int) Math.Floor(tIntersection.X) % 2 == 0 && (int) Math.Floor(tIntersection.Z) % 2 == 0)
				|| ((int) Math.Abs(Math.Floor(tIntersection.X)) % 2 == 1 && (int) Math.Abs(Math.Floor(tIntersection.Z)) % 2 == 1))
				? Colour : AlternateColour;
		}
	}
}
