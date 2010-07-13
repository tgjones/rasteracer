using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TJ.RayTracing.Framework.Cameras;
using Microsoft.Xna.Framework;

namespace TJ.RayTracing.Framework.Renderers
{
	public class RayTracingRenderer : Renderer
	{
		private Tracer _tracer;
		private SpriteBatch _spriteBatch;
		private Texture2D _target;

		public RayTracingRenderer(GraphicsDevice graphicsDevice, Scene scene, Camera camera, int windowWidth, int windowHeight)
			: base(graphicsDevice, scene, camera)
		{
			_tracer = new Tracer(windowWidth, windowHeight, scene, camera);
			_spriteBatch = new SpriteBatch(graphicsDevice);
			_target = new Texture2D(graphicsDevice, windowWidth, windowHeight);
		}

		public override void Draw()
		{
			if (_tracer.ProcessFrame())
			{
				FloatColour[,] data = _tracer.Image;
				Color[] outputData = new Color[data.Length];
				int counter = 0;
				for (int y = 0; y < data.GetLength(1); y++)
					for (int x = 0; x < data.GetLength(0); x++)
						outputData[counter++] = data[x, y].ToColor();

				GraphicsDevice.Textures[0] = null;
				_target.SetData(outputData, 0, outputData.Length, SetDataOptions.Discard);
			}

			_spriteBatch.Begin();
			_spriteBatch.Draw(_target, Vector2.Zero, Color.White);
			_spriteBatch.End();
		}
	}
}
