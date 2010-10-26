using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rasteracer.Framework.Cameras;
using Rasteracer.Framework.Primitives;

namespace Rasteracer.Framework
{
	/// <summary>
	/// Summary description for RayTracer.
	/// </summary>
	public sealed class Tracer
	{
		#region Variables

		private int _width, _height;

		private FloatColour[,] m_pImage;

		private Scene m_pScene;
		private Camera _camera;
		private Viewport _viewport;

		#endregion

		#region Properties

		public FloatColour[,] Image
		{
			get {return m_pImage;}
		}

		public Scene Scene
		{
			get { return m_pScene; }
		}

		#endregion

		#region Constructor

		public Tracer(int nWidth, int nHeight, Scene scene, Camera camera)
		{
			_width = nWidth; _height = nHeight;

			m_pImage = new FloatColour[_width, _height];

			m_pScene = scene;
			_camera = camera;

			_viewport = new Viewport();
			_viewport.Width = _width;
			_viewport.Height = _height;
			_viewport.MinDepth = 0;
			_viewport.MaxDepth = 1.0f;
		}

		#endregion

		#region Methods

		#region Intersection methods

		public bool IsShadowed(Primitive currentPrimitive, Ray tRayToLight, float fDistanceToLight)
		{
			// check every other sphere
			foreach (Primitive primitive in m_pScene.Primitives)
			{
				// spheres don't self-shadow
				if (primitive == currentPrimitive)
				{
					continue;
				}

        // check for intersection
				float fDistance;
				if (primitive.Intersect(tRayToLight, out fDistance))
				{
					// check that intersection is not past the light
					if (fDistance < fDistanceToLight)
					{
						return true;
					}
				}
			}

			return false;
		}

		#endregion

		#region Rendering methods

		public bool ProcessFrame()
		{
			// loop through all pixels
			for (int y = 0; y < _height; y++)
			{
				for (int x = 0; x < _width; x++)
				{
					// set direction of ray
					Ray tPrimaryRay = _camera.GetUnprojectedRay(x, y);

					// trace ray (this is recursive)
					FloatColour tColour = TraceRay(null, tPrimaryRay, 0);

					// set colour of pixels in bitmap
					m_pImage[x, y] = tColour;
				}
			}

			return true;
		}

		public FloatColour TraceRay(Primitive pIgnorePrimitive, Ray tRay, int nDepth)
		{
			// check whether we have reached maximum recursion depth
			if (nDepth > 6)
			{
				//return new Colour(0, 0, 0);
				return new FloatColour(1);
			}

			// declare intersection variables
			float fClosestIntersectionDistance = float.MaxValue;
			Primitive closestIntersectedPrimitive = null;

			// loop through all objects in scene
			foreach (Primitive primitive in m_pScene.Primitives)
			{
				// test for intersection
				float fDistance;
				if (primitive.Intersect(tRay, out fDistance))
				{
					// check that we are closer than the last intersection
					if (fDistance < fClosestIntersectionDistance)
					{
						// set closest intersection
						fClosestIntersectionDistance = fDistance;
						closestIntersectedPrimitive = primitive;
					}
				}
			}

			// if nothing was intersected, set to background colour
			FloatColour tColour = new FloatColour(Color.CornflowerBlue);
			if (closestIntersectedPrimitive != null) // test for intersection
			{
				tColour = closestIntersectedPrimitive.Shade(this,
					tRay, fClosestIntersectionDistance, nDepth + 1);
			}

			tColour = FloatColour.Min(tColour, new FloatColour(1));

			// return colour
			return tColour;
		}

		#endregion

		#endregion
	}
}
