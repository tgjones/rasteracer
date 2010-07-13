﻿using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Compiler;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Content;
using TJ.RayTracing.Framework.Materials;

namespace TJ.RayTracing.Content.Pipeline
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