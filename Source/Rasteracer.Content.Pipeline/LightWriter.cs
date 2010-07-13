using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;

namespace TJ.RayTracing.Content.Pipeline
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
