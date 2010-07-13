using System;
using TJ.RayTracing.Framework.Materials;

namespace TJ.RayTracing.Framework.Primitives
{
	public interface IPrimitive
	{
		float Reflectivity { get; }
		Material Material { get; }
	}
}
