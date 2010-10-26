using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework.Lights;
using Rasteracer.Framework.Materials;
using Rasteracer.Framework.Renderers;

namespace Rasteracer.Framework.Primitives
{
	/// <summary>
	/// Summary description for Primitive.
	/// </summary>
	public abstract class Primitive : IPrimitive, IRayTracingDrawable
	{
		#region Variables

		public float Reflectivity { get; set; }
		public Material Material { get; set; }

		[ContentSerializerIgnore]
		public ContentManager ContentManager { get; set; }

		#endregion

		#region Methods

		public FloatColour Shade(Tracer tracer, Ray tRay, float fDistance, int nDepth)
		{
			// declare return colour
			FloatColour tColour = new FloatColour(0, 0, 0);

			// get surface normal at point of intersection
			Vector3 tIntersection = tRay.Position + tRay.Direction * fDistance;
			Vector3 tNormal = CalculateNormal(tIntersection);

			// calculate reflected ray
			Ray tReflectedRay;
			tReflectedRay.Direction = Vector3.Reflect(tRay.Direction, tNormal);
			tReflectedRay.Position = tIntersection;

			// add lighting components
			foreach (Light light in tracer.Scene.Lights)
			{
				// get vector from surface to light
				Vector3 tSurfaceToLight = light.GetDirectionToLight(tIntersection);
				float fDistanceToLight = tSurfaceToLight.Length();
				tSurfaceToLight.X /= fDistanceToLight;
				tSurfaceToLight.Y /= fDistanceToLight;
				tSurfaceToLight.Z /= fDistanceToLight;

				// check whether point is in shadow
				Ray tRayToLight;
				tRayToLight.Position = tIntersection;
				tRayToLight.Direction = tSurfaceToLight;
				float fLightFactor;
				if (tracer.IsShadowed(this, tRayToLight, fDistanceToLight))
				{
					// shadowed - little bit of ambient light
					fLightFactor = 0.1f;
				}
				else
				{
					// get amount of light diffuse at intersection point
					fLightFactor = Vector3.Dot(tSurfaceToLight, tNormal);
					if (fLightFactor < 0) fLightFactor = 0;
				}

				// calculate specular component
				float fSpecular = Vector3.Dot(tRayToLight.Direction, tReflectedRay.Direction);
				if (fSpecular > 0)
				{
					float Shininess = 100.0f;
					float SpecularCoefficient = 1.0f;
					fSpecular = (float) Math.Pow(fSpecular, Shininess) * SpecularCoefficient;
				}
				else
				{
					fSpecular = 0;
				}

				// add light effect to colour
				tColour += (Material.GetColour(tIntersection) * fLightFactor + new FloatColour(fSpecular)) * light.Colour;
			}

			// calculate reflection colour (if needed)
			if (Reflectivity != 0)
			{
				// calculate the reflected colour
				FloatColour tReflectedColour = tracer.TraceRay(this, tReflectedRay, nDepth + 1);

				// calculate total colour components
				tColour += tReflectedColour * Reflectivity;
			}

			if (tColour.R > 255) tColour.R = 255;
			if (tColour.G > 255) tColour.G = 255;
			if (tColour.B > 255) tColour.B = 255;

			return tColour;
		}

		protected abstract Vector3 CalculateNormal(Vector3 tIntersection);
		public abstract bool Intersect(Ray tRay, out float fDistance);

		#endregion
	}
}