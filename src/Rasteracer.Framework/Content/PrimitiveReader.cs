using System;
using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Materials;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework.Content
{
	public abstract class PrimitiveReader<T> : ContentTypeReader<T>
		where T : Primitive
	{
		protected override T Read(ContentReader input, T existingInstance)
		{
			T output = CreateAndPopulateObject(input);
			output.Reflectivity = input.ReadSingle();
			output.Material = input.ReadObject<Material>();
			output.ContentManager = input.ContentManager;
			return output;
		}

		protected abstract T CreateAndPopulateObject(ContentReader input);
	}

	public class PrimitiveReader : PrimitiveReader<Primitive>
	{
		protected override Primitive CreateAndPopulateObject(ContentReader input)
		{
			throw new NotImplementedException();
		}
	}
}
