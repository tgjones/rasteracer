using System;
using Microsoft.Xna.Framework;
using TJ.RayTracing.Framework.Renderers;
using Microsoft.Xna.Framework.Graphics;

namespace TJ.RayTracing.Framework.Primitives
{
	/// <summary>
	/// Summary description for Plane.
	/// </summary>
	public sealed class Plane : Primitive, IXnaDrawable
	{
		#region Variables

		public Vector3 Normal;
		public float Distance;

		#endregion

		#region Methods

		public override bool Intersect(Ray tRay, out float fDistance)
		{
			fDistance = -(Vector3.Dot(Normal, tRay.Position) + Distance) / (Vector3.Dot(Normal, tRay.Direction));
			return (fDistance >= 0);
		}

		protected override Vector3 CalculateNormal(Vector3 tIntersection)
		{
			return Normal;
		}

		#endregion

		#region IXnaDrawable Members

		private Model _model;

		Model IXnaDrawable.Model
		{
			get
			{
				if (_model == null)
					_model = ContentManager.Load<Model>(@"Models\Plane");
				return _model;
			}
		}

		Matrix IXnaDrawable.World
		{
			get { return Matrix.CreateRotationX(-MathHelper.PiOver2) * Matrix.CreateScale(1000, 0, 1000) * Matrix.CreateTranslation(0, Distance, 0); }
		}

		#endregion
	}
}
