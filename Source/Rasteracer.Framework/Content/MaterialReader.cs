﻿using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;
using TJ.RayTracing.Framework.Materials;

namespace TJ.RayTracing.Framework.Content
{
	public abstract class MaterialReader<T> : ContentTypeReader<T>
		where T : Material
	{
		protected override T Read(ContentReader input, T existingInstance)
		{
			T output = CreateAndPopulateObject(input);
			output.Colour = input.ReadObject<FloatColour>();
			return output;
		}

		protected abstract T CreateAndPopulateObject(ContentReader input);
	}

	public class MaterialReader : MaterialReader<Material>
	{
		protected override Material CreateAndPopulateObject(ContentReader input)
		{
			return new Material();
		}
	}
}
