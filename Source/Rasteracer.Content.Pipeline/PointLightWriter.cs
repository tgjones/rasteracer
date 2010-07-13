using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;

namespace TJ.RayTracing.Content.Pipeline
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
