using System;
using Microsoft.Xna.Framework;

namespace Rasteracer.Framework
{
	public struct FloatColour
	{
		public float R;
		public float G;
		public float B;

		public FloatColour(float fR, float fG, float fB)
		{
			R = fR;
			G = fG;
			B = fB;
		}

		public FloatColour(float value)
			: this(value, value, value)
		{
			
		}

		public FloatColour(Vector3 value)
			: this(value.X, value.Y, value.Z)
		{

		}

		public FloatColour(Color value)
			: this(value.ToVector3())
		{

		}

		public static FloatColour operator *(FloatColour value, float multiplier)
		{
			FloatColour output = value;
			output.R *= multiplier;
			output.G *= multiplier;
			output.B *= multiplier;
			return output;
		}

		public static FloatColour operator +(FloatColour left, FloatColour right)
		{
			FloatColour output;
			output.R = left.R + right.R;
			output.G = left.G + right.G;
			output.B = left.B + right.B;
			return output;
		}

		public static FloatColour operator *(FloatColour left, FloatColour right)
		{
			FloatColour output;
			output.R = left.R * right.R;
			output.G = left.G * right.G;
			output.B = left.B * right.B;
			return output;
		}

		public Color ToColor()
		{
			return new Color(new Vector3(R, G, B));
		}

		internal static FloatColour Min(FloatColour value1, FloatColour value2)
		{
			FloatColour output;
			output.R = Math.Min(value1.R, value2.R);
			output.G = Math.Min(value1.G, value2.G);
			output.B = Math.Min(value1.B, value2.B);
			return output;
		}

		public override string ToString()
		{
			return string.Format("{0:F2}, {1:F2}, {2:F2}", R, G, B);
		}
	}
}
