using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Content.Pipeline
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
