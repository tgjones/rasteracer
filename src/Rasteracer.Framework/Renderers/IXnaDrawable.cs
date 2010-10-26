using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework.Renderers
{
	public interface IXnaDrawable : IPrimitive
	{
		Model Model { get; }
		Matrix World { get; }
	}
}
