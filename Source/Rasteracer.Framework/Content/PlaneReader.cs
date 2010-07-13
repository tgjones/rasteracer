using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;
using TJ.RayTracing.Framework.Primitives;

namespace TJ.RayTracing.Framework.Content
{
	public class PlaneReader : PrimitiveReader<Plane>
	{
		protected override Plane CreateAndPopulateObject(ContentReader input)
		{
			return new Plane { Normal = input.ReadVector3(), Distance = input.ReadSingle() };
		}
	}
}
