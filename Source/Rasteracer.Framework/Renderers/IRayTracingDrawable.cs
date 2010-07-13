using System;
using TJ.RayTracing.Framework.Primitives;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Renderers
{
	public interface IRayTracingDrawable : IPrimitive
	{
		FloatColour Shade(Tracer tracer, Ray tRay, float fDistance, int nDepth);
		bool Intersect(Ray tRay, out float fDistance);
	}
}
