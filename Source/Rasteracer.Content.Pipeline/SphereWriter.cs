using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;
using TJ.RayTracing.Framework.Primitives;

namespace TJ.RayTracing.Content.Pipeline
{
	[ContentTypeWriter]
	public class SphereWriter : PrimitiveWriter<Sphere>
	{
		protected override void Write(ContentWriter output, Sphere value)
		{
			output.Write(value.Centre);
			output.Write(value.Radius);
			base.Write(output, value);
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(SphereReader).AssemblyQualifiedName;
		}
	}
}
