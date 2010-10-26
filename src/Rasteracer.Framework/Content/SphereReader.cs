using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework.Content
{
	public class SphereReader : PrimitiveReader<Sphere>
	{
		protected override Sphere CreateAndPopulateObject(ContentReader input)
		{
			return new Sphere { Centre = input.ReadVector3(), Radius = input.ReadSingle() };
		}
	}
}
