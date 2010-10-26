using Microsoft.Xna.Framework.Content;

namespace Rasteracer.Framework.Content
{
	public class FloatColourReader : ContentTypeReader<FloatColour>
	{
		protected override FloatColour Read(ContentReader input, FloatColour existingInstance)
		{
			FloatColour output = new FloatColour();
			output.R = input.ReadSingle();
			output.G = input.ReadSingle();
			output.B = input.ReadSingle();
			return output;
		}
	}
}
