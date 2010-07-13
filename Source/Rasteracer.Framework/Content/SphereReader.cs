using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;
using TJ.RayTracing.Framework.Primitives;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Content
{
	public class SphereReader : PrimitiveReader<Sphere>
	{
		protected override Sphere CreateAndPopulateObject(ContentReader input)
		{
			return new Sphere { Centre = input.ReadVector3(), Radius = input.ReadSingle() };
		}
	}
}
