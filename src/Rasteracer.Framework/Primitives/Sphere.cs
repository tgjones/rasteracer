using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Rasteracer.Framework.Renderers;

namespace Rasteracer.Framework.Primitives
{
	/// <summary>
	/// Summary description for Sphere.
	/// </summary>
	public sealed class Sphere : Primitive, IXnaDrawable
	{
		#region Variables

		public Vector3 Centre;
		public float Radius;

		#endregion

		#region Methods

		public override bool Intersect(Ray tRay, out float fDistance)
		{
			// calculate the vector from the ray origin to centre of sphere
			Vector3 tOriginToCentre = Centre - tRay.Position;

			// get the closest approach of the ray to the sphere
			float fClosestApproach = Vector3.Dot(tOriginToCentre, tRay.Direction);

			// if this is less than 0, the sphere is behind the ray origin
			if (fClosestApproach < 0)
			{
				fDistance = 0.0f;
				return false;
			}
			else
			{
				// calculate the distance from the centre of the sphere to
				// the closest approach
				float fLengthSq = tOriginToCentre.LengthSquared();
				float fHalfCordSq = (Radius * Radius) - fLengthSq + (fClosestApproach * fClosestApproach);

				// ray misses the sphere
				if (fHalfCordSq < 0)
				{
					fDistance = 0.0f;
					return false;
				}
				else
				{
					fDistance = fClosestApproach - (float) Math.Sqrt(fHalfCordSq);
					return true;
				}
			}
		}

		protected override Vector3 CalculateNormal(Vector3 tIntersection)
		{
			return (tIntersection - Centre) / Radius;
		}

		#endregion

		#region IXnaDrawable Members

		private Model _model;

		Model IXnaDrawable.Model
		{
			get
			{
				if (_model == null)
					_model = ContentManager.Load<Model>(@"Models\Sphere");
				return _model;
			}
		}

		Matrix IXnaDrawable.World
		{
			get { return Matrix.CreateScale(Radius) * Matrix.CreateTranslation(Centre); }
		}

		#endregion
	}
}