using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;

namespace TJ.RayTracing.Framework.Content
{
	public abstract class LightReader<T> : ContentTypeReader<T>
		where T : Light
	{
		protected override T Read(ContentReader input, T existingInstance)
		{
			T output = CreateAndPopulateObject(input);
			output.Colour = input.ReadObject<FloatColour>();
			return output;
		}

		protected abstract T CreateAndPopulateObject(ContentReader input);
	}

	public class LightReader : LightReader<Light>
	{
		protected override Light CreateAndPopulateObject(ContentReader input)
		{
			throw new NotImplementedException();
		}
	}
}
