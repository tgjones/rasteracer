using System;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using TJ.RayTracing.Framework;
using TJ.RayTracing.Framework.Cameras;
using TJ.RayTracing.Framework.Renderers;

namespace TJ.RayTracing
{
	public class RayTracingControl : GraphicsDeviceControl
	{
		#region Fields

		private ContentManager _contentManager;

		private Scene _scene;
		private RenderMethod _renderMethod;
		private GuiCamera _camera;

		private Renderer[] _renderers;

		private bool _forceXnaRenderer;
		private DateTime _cameraLastMoved;

		#endregion

		#region Properties

		public RenderMethod RenderMethod
		{
			get { return _renderMethod; }
			set
			{
				_renderMethod = value;
				Invalidate();
			}
		}

		public MouseMode MouseMode
		{
			set
			{
				switch (value)
				{
					case MouseMode.Pan :
					case MouseMode.ArcBall :
						_camera.UpdateMode = (GuiCameraUpdateMode) value;
						break;
				}
			}
		}

		#endregion

		#region Methods

		/// <summary>
		/// Initializes the control.
		/// </summary>
		protected override void Initialize()
		{
			_contentManager = new ContentManager(Services, "Content");

			_camera = new GuiCamera(GraphicsDevice, this.Handle, ClientSize.Width, ClientSize.Height);
			_camera.UpdateMode = GuiCameraUpdateMode.Pan;
			_camera.Update();

			_scene = _contentManager.Load<Scene>("Scene1");

			_renderers = new Renderer[]
			{
				new RayTracingRenderer(GraphicsDevice, _scene, _camera, ClientSize.Width, ClientSize.Height),
				new XnaRenderer(_contentManager, GraphicsDevice, _scene, _camera)
			};

			UpdateScene();

			Application.Idle += new EventHandler(Application_Idle);
		}

		private void Application_Idle(object sender, EventArgs e)
		{
			if (_camera.Update())
			{
				// Set the time the camera was last moved; we wait a second
				// after the camera has stopped moving to switch back to
				// RayTracing mode (if the RenderMethod is Automatic).
				_cameraLastMoved = DateTime.Now;
				_forceXnaRenderer = true;
			}
			else
			{
				_forceXnaRenderer = false;
			}

			UpdateScene();
		}

		private void UpdateScene()
		{
			// Check if we're ready to switch back to RayTracing mode.
			if (_cameraLastMoved < DateTime.Now.AddSeconds(-1))
			{
				// Check if we were already in ray tracing mode - if so, no need
				// to re-render.
				if (!_forceXnaRenderer)
					return;

				_forceXnaRenderer = false;
			}

			Invalidate();
		}

		/// <summary>
		/// Disposes the control, unloading the ContentManager.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
				_contentManager.Unload();

			base.Dispose(disposing);
		}

		/// <summary>
		/// Draws the control.
		/// </summary>
		protected override void Draw()
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			Renderer activeRenderer = null;
			switch (RenderMethod)
			{
				case RenderMethod.Automatic :
					if (_forceXnaRenderer)
						activeRenderer = _renderers[1];	
					else
						activeRenderer = _renderers[0];	
					break;
				case RenderMethod.RayTracing :
					activeRenderer = _renderers[0];
					break;
				case RenderMethod.Xna :
					activeRenderer = _renderers[1];
					break;
				default :
					throw new NotImplementedException();
			}
			activeRenderer.Draw();
		}

		#endregion
	}
}