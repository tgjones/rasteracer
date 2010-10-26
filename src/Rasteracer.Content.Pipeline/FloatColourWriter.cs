using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework;
using Rasteracer.Framework.Content;

namespace Rasteracer.Content.Pipeline
{
	[ContentTypeWriter]
	public class FloatColourWriter : ContentTypeWriter<FloatColour>
	{
		protected override void Write(ContentWriter output, FloatColour value)
		{
			output.Write(value.R);
			output.Write(value.G);
			output.Write(value.B);
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(FloatColourReader).AssemblyQualifiedName;
		}
	}
}
