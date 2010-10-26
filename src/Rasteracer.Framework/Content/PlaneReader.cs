using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework.Content
{
	public class PlaneReader : PrimitiveReader<Plane>
	{
		protected override Plane CreateAndPopulateObject(ContentReader input)
		{
			return new Plane { Normal = input.ReadVector3(), Distance = input.ReadSingle() };
		}
	}
}
