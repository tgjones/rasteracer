using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Materials;

namespace Rasteracer.Content.Pipeline
{
	[ContentTypeWriter]
	public class CheckerboardMaterialWriter : MaterialWriter<CheckerboardMaterial>
	{
		protected override void Write(ContentWriter output, CheckerboardMaterial value)
		{
			output.WriteObject(value.AlternateColour);
			base.Write(output, value);
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(CheckerboardMaterialReader).AssemblyQualifiedName;
		}
	}
}
