using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Materials;

namespace Rasteracer.Content.Pipeline
{
	public abstract class MaterialWriter<T> : ContentTypeWriter<T>
		where T : Material
	{
		protected override void Write(ContentWriter output, T value)
		{
			output.WriteObject(value.Colour);
		}
	}

	[ContentTypeWriter]
	public class MaterialWriter : MaterialWriter<Material>
	{
		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(MaterialReader).AssemblyQualifiedName;
		}
	}
}
