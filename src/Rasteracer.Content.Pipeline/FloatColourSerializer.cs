using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using System.Xml;
using Microsoft.Xna.Framework.Content;
using Rasteracer.Framework;

namespace Rasteracer.Content.Pipeline
{
	[ContentTypeSerializer]
	internal class FloatColourSerializer : ContentTypeSerializer<FloatColour>
	{
		protected override FloatColour Deserialize(IntermediateReader input, ContentSerializerAttribute format, FloatColour existingInstance)
		{
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			XmlListReader reader = new XmlListReader(input);
			FloatColour local = this.Deserialize(reader);
			if (!reader.AtEnd)
			{
				throw input.CreateInvalidContentException("XML has too many entries in the space-separated list.", new object[0]);
			}
			return local;
		}
 
		protected FloatColour Deserialize(XmlListReader input)
		{
			FloatColour colour;
			if (input == null)
			{
				throw new ArgumentNullException("input");
			}
			colour.R = ReadSingle(input);
			colour.G = ReadSingle(input);
			colour.B = ReadSingle(input);
			return colour;
		}

		protected override void Serialize(IntermediateWriter output, FloatColour value, ContentSerializerAttribute format)
		{
			if (output == null)
			{
				throw new ArgumentNullException("output");
			}
			WritePart(output, value.R);
			WritePart(output, value.G);
			WriteLast(output, value.B);
		}

		protected static float ReadSingle(XmlListReader input)
		{
			return XmlConvert.ToSingle(input.ReadString());
		}

		protected static void WritePart(IntermediateWriter output, float value)
		{
			output.Xml.WriteString(XmlConvert.ToString(value));
			output.Xml.WriteWhitespace(" ");
		}

		protected static void WriteLast(IntermediateWriter output, float value)
		{
			output.Xml.WriteString(XmlConvert.ToString(value));
		}
	}
}
