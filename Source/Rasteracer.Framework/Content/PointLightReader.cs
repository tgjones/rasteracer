using System;
using Microsoft.Xna.Framework.Content;
using TJ.RayTracing.Framework.Lights;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Content
{
	public class PointLightReader : LightReader<PointLight>
	{
		protected override PointLight CreateAndPopulateObject(ContentReader input)
		{
			return new PointLight { Location = input.ReadVector3() };
		}
	}
}
