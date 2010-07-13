using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;
using TJ.RayTracing.Framework.Materials;

namespace TJ.RayTracing.Content.Pipeline
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
