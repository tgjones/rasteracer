using System;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;
using Microsoft.Xna.Framework.Content.Pipeline;
using System.Xml;
using System.Globalization;

namespace Rasteracer.Content.Pipeline
{
	internal static class ExtensionMethods
	{
		internal static Exception CreateInvalidContentException(this IntermediateReader reader, string message, params object[] messageArgs)
		{
			ContentIdentity contentIdentity = new ContentIdentity();
			contentIdentity.SourceFilename = reader.Xml.BaseURI;
			IXmlLineInfo xml = reader.Xml as IXmlLineInfo;
			if (xml != null)
			{
				contentIdentity.FragmentIdentifier = string.Format(CultureInfo.InvariantCulture, "{0},{1}", new object[] { xml.LineNumber, xml.LinePosition });
			}
			return new InvalidContentException(string.Format(CultureInfo.CurrentCulture, message, messageArgs), contentIdentity);
		}
	}
}
