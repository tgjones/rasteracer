﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using TJ.RayTracing.Framework.Cameras;

namespace TJ.RayTracing.Framework.Renderers
{
	public abstract class Renderer
	{
		protected GraphicsDevice GraphicsDevice
		{
			get;
			private set;
		}

		protected Scene Scene
		{
			get;
			private set;
		}

		protected Camera Camera
		{
			get;
			private set;
		}

		public Renderer(GraphicsDevice graphicsDevice, Scene scene, Camera camera)
		{
			GraphicsDevice = graphicsDevice;
			Scene = scene;
			Camera = camera;
		}

		public abstract void Draw();
	}
}
