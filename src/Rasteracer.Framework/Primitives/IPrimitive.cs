using Rasteracer.Framework.Materials;

namespace Rasteracer.Framework.Primitives
{
	public interface IPrimitive
	{
		float Reflectivity { get; }
		Material Material { get; }
	}
}
