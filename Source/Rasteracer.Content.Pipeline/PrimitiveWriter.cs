using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;
using TJ.RayTracing.Framework.Primitives;

namespace TJ.RayTracing.Content.Pipeline
{
	public abstract class PrimitiveWriter<T> : ContentTypeWriter<T>
		where T : Primitive
	{
		protected override void Write(ContentWriter output, T value)
		{
			output.Write(value.Reflectivity);
			output.WriteObject(value.Material);
		}
	}

	[ContentTypeWriter]
	public class PrimitiveWriter : PrimitiveWriter<Primitive>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(PrimitiveReader).AssemblyQualifiedName;
		}
	}
}
