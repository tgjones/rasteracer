using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Content.Pipeline
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
