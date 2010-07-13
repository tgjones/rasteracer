using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Primitives;

namespace TJ.RayTracing.Framework.Renderers
{
	public interface IXnaDrawable : IPrimitive
	{
		Model Model { get; }
		Matrix World { get; }
	}
}
