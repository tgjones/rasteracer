using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;

namespace TJ.RayTracing.Content.Pipeline
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
