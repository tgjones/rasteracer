using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Lights;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework.Content
{
	public class SceneReader : ContentTypeReader<Scene>
	{
		protected override Scene Read(ContentReader input, Scene existingInstance)
		{
			Scene output = new Scene();
			output.Lights = input.ReadObject<Light[]>();
			output.Primitives = input.ReadObject<Primitive[]>();
			return output;
		}
	}
}
