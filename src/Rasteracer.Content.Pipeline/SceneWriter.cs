using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework;
using Rasteracer.Framework.Content;

namespace Rasteracer.Content.Pipeline
{
	[ContentTypeWriter]
	public class SceneWriter : ContentTypeWriter<Scene>
	{
		protected override void Write(ContentWriter output, Scene value)
		{
			output.WriteObject(value.Lights);
			output.WriteObject(value.Primitives);
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(SceneReader).AssemblyQualifiedName;
		}
	}
}
