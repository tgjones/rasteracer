using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Content.Pipeline
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

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(PlaneReader).AssemblyQualifiedName;
		}
	}
}
