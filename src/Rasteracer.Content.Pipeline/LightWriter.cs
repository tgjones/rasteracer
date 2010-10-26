using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Lights;

namespace Rasteracer.Content.Pipeline
{
	public abstract class LightWriter<T> : ContentTypeWriter<T>
		where T : Light
	{
		protected override void Write(ContentWriter output, T value)
		{
			output.WriteObject(value.Colour);
		}
	}

	[ContentTypeWriter]
	public class LightWriter : LightWriter<Light>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(LightReader).AssemblyQualifiedName;
		}
	}
}
