using System;
using TJ.RayTracing.Framework.Primitives;
using TJ.RayTracing.Framework.Lights;

namespace TJ.RayTracing.Framework
{
	public class Scene
	{
		public Light[] Lights;
		public Primitive[] Primitives;
	}
}
