using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Rasteracer.Framework.Cameras
{
	public abstract class Camera
	{
		public Matrix Projection
		{
			get;
			protected set;
		}

		public Matrix View
		{
			get;
			protected set;
		}

		protected GraphicsDevice GraphicsDevice
		{
			get;
			set;
		}

		public Camera(GraphicsDevice graphicsDevice)
		{
			GraphicsDevice = graphicsDevice;
		}

		public Ray GetUnprojectedRay(int x, int y)
		{
			Vector3 nearSource = new Vector3(x, y, 0);
			Vector3 farSource = new Vector3(x, y, 1);
			Vector3 nearPoint = GetUnprojectedPosition(nearSource);
			Vector3 farPoint = GetUnprojectedPosition(farSource);
			Vector3 direction = Vector3.Normalize(farPoint - nearPoint);
			return new Ray(nearPoint, direction);
		}

		public Vector3 GetUnprojectedPosition(Vector3 screenSpacePosition)
		{
			return GraphicsDevice.Viewport.Unproject(screenSpacePosition, Projection, View, Matrix.Identity);
		}

		public Vector3 GetProjectedPosition(Vector3 worldSpacePosition)
		{
			return GraphicsDevice.Viewport.Project(worldSpacePosition, Projection, View, Matrix.Identity);
		}
	}
}
