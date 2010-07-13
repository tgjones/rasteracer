using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;
using TJ.RayTracing.Framework.Primitives;

namespace TJ.RayTracing.Framework.Content
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
