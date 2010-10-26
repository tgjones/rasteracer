using System;
using Microsoft.Xna.Framework;

namespace Rasteracer.Framework.Primitives
{
	/// <summary>
	/// Summary description for Cylinder.
	/// </summary>
	public sealed class Cylinder : Primitive
	{
		#region Variables

		public Vector3 Centre;
		public float Radius;
		public Axis Axis;

		#endregion

		#region Methods

		public override bool Intersect(Ray tRay, out float fDistance)
		{
			float fA = 0, fB = 0, fC = 0;
			fDistance = 0;

			switch (Axis)
			{
				case Axis.InfiniteX :
					fA = tRay.Direction.Y * tRay.Direction.Y + tRay.Direction.Z * tRay.Direction.Z;
					fB = 2 * (tRay.Direction.Y * (tRay.Position.Y - Centre.Y) +
						tRay.Direction.Z * (tRay.Position.Z - Centre.Z));
					fC = (tRay.Position.Y - Centre.Y) * (tRay.Position.Y - Centre.Y) +
						(tRay.Position.Z - Centre.Z) * (tRay.Position.Z - Centre.Z) - Radius * Radius;
					break;
				case Axis.InfiniteY :
					fA = tRay.Direction.X * tRay.Direction.X + tRay.Direction.Z * tRay.Direction.Z;
					fB = 2 * (tRay.Direction.X * (tRay.Position.X - Centre.X) +
						tRay.Direction.Z * (tRay.Position.Z - Centre.Z));
					fC = (tRay.Position.X - Centre.X) * (tRay.Position.X - Centre.X) +
						(tRay.Position.Z - Centre.Z) * (tRay.Position.Z - Centre.Z) - Radius * Radius;
					break;
				case Axis.InfiniteZ :
					fA = tRay.Direction.X * tRay.Direction.X + tRay.Direction.Y * tRay.Direction.Y;
					fB = 2 * (tRay.Direction.X * (tRay.Position.X - Centre.X) +
						tRay.Direction.Y * (tRay.Position.Y - Centre.Y));
					fC = (tRay.Position.X - Centre.X) * (tRay.Position.X - Centre.X) +
						(tRay.Position.Y - Centre.Y) * (tRay.Position.Y - Centre.Y) - Radius * Radius;                    
					break;
			}    

			float fDiscriminant = fB * fB - 4 * fA * fC;
			if (fDiscriminant < 0)
			{
				return false;
			}
    
			fDistance = (-fB - (float) Math.Sqrt(fDiscriminant)) / (2 * fA);
			if (fDistance < 0)
			{
				return false;
			}

			return true;
		}

		protected override Vector3 CalculateNormal(Vector3 tIntersection)
		{
			Vector3 tNormal = new Vector3();
			switch (Axis)
			{
				case Axis.InfiniteX :
					tNormal.X = 0;
					tNormal.Y = (tIntersection.Y  - Centre.Y) / Radius;
					tNormal.Z = (tIntersection.Z  - Centre.Z) / Radius;
					break;
				case Axis.InfiniteY :
					tNormal.X = (tIntersection.X  - Centre.X) / Radius;
					tNormal.Y = 0;
					tNormal.Z = (tIntersection.Z  - Centre.Z) / Radius;
					break;
				case Axis.InfiniteZ :
					tNormal.X = (tIntersection.X  - Centre.X) / Radius;
					tNormal.Y = (tIntersection.Y  - Centre.Y) / Radius;
					tNormal.Z = 0;
					break;
			}
			return tNormal;
		}

		#endregion
	}

	#region Axis enum

	public enum Axis
	{
		InfiniteX,
		InfiniteY,
		InfiniteZ
	}

	#endregion
}
