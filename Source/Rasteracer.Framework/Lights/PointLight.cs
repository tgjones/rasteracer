using System;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Lights
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
