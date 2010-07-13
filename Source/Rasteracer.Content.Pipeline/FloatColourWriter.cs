using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;

namespace TJ.RayTracing.Content.Pipeline
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
