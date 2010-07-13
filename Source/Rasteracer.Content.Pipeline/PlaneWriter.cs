using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using TJ.RayTracing.Framework.Content;
using TJ.RayTracing.Framework.Primitives;

namespace TJ.RayTracing.Content.Pipeline
{
	[ContentTypeWriter]
	public class PlaneWriter : PrimitiveWriter<Plane>
	{
		protected override void Write(ContentWriter output, Plane value)
		{
			output.Write(value.Normal);
			output.Write(value.Distance);
			base.Write(output, value);
		}

		public override string GetRuntimeReader(Microsoft.Xna.Framework.TargetPlatform targetPlatform)
		{
			return typeof(PlaneReader).AssemblyQualifiedName;
		}
	}
}
