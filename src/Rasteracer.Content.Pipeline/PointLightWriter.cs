using Microsoft.Xna.Framework.Content.Pipeline;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using Rasteracer.Framework.Content;
using Rasteracer.Framework.Lights;

namespace Rasteracer.Content.Pipeline
{
	[ContentTypeWriter]
	public class PointLightWriter : LightWriter<PointLight>
	{
		protected override void Write(ContentWriter output, PointLight value)
		{
			output.Write(value.Location);
			base.Write(output, value);
		}

		public override string GetRuntimeReader(TargetPlatform targetPlatform)
		{
			return typeof(PointLightReader).AssemblyQualifiedName;
		}
	}
}
