using Microsoft.Xna.Framework;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework.Renderers
{
	public interface IRayTracingDrawable : IPrimitive
	{
		FloatColour Shade(Tracer tracer, Ray tRay, float fDistance, int nDepth);
		bool Intersect(Ray tRay, out float fDistance);
	}
}
