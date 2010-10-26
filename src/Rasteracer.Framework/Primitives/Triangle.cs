using Microsoft.Xna.Framework;

namespace Rasteracer.Framework.Primitives
{
	/// <summary>
	/// Summary description for Triangle.
	/// </summary>
	public sealed class Triangle : Primitive
	{
		#region Variables

		public Vector3 V1, V2, V3;

		#endregion

		#region Methods

		public override bool Intersect(Ray tRay, out float fDistance)
		{
			fDistance = 0;

			Vector3 tEdge1 = V2 - V1;
			Vector3 tEdge2 = V3 - V1;
			Vector3 tP = Vector3.Cross(tRay.Direction, tEdge2);
    
			float fDet = Vector3.Dot(tEdge1, tP);
			if (fDet > -0.000001f && fDet < 0.000001f)
			{
				return false;
			}

			float fInvDet = 1 / fDet;

			Vector3 tT = tRay.Position - V1;

			float fU = Vector3.Dot(tT, tP) * fInvDet;
			if (fU < 0 || fU > 1)
			{
				return false;
			}

			Vector3 tQ = Vector3.Cross(tT, tEdge1);

			float fV = Vector3.Dot(tRay.Direction, tQ) * fInvDet;
			if (fV < 0 || (fU + fV) > 1)
			{
				return false;
			}

			fDistance = Vector3.Dot(tEdge2, tQ) * fInvDet;
			if (fDistance < 0)
			{
				return false;
			}
   
			return true;
		}

		protected override Vector3 CalculateNormal(Vector3 tIntersection)
		{
			Vector3 tEdge1 = V2 - V1;
			Vector3 tEdge2 = V3 - V1;
			Vector3 tNormal = Vector3.Cross(tEdge1, tEdge2); 
			tNormal.Normalize();
			return tNormal;
		}

		#endregion
	}
}
