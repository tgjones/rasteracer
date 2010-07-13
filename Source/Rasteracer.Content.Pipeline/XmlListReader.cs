using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content.Pipeline.Serialization.Intermediate;

namespace TJ.RayTracing.Content.Pipeline
{
	internal class XmlListReader
	{
		// Fields
		private bool atEnd;
		private IEnumerator<string> enumerator;
		private static char[] listSeparators = new char[] { ' ', '\t', '\r', '\n' };
		private IntermediateReader reader;

		// Methods
		public XmlListReader(IntermediateReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			this.reader = reader;
			IEnumerable<string> enumerable = reader.Xml.ReadContentAsString().Split(listSeparators, StringSplitOptions.RemoveEmptyEntries);
			this.enumerator = enumerable.GetEnumerator();
			this.atEnd = !this.enumerator.MoveNext();
		}

		public string ReadString()
		{
			if (this.atEnd)
			{
				throw this.reader.CreateInvalidContentException("XML does not have enough entries in space-separated list.", new object[0]);
			}
			string current = this.enumerator.Current;
			this.atEnd = !this.enumerator.MoveNext();
			return current;
		}

		// Properties
		public bool AtEnd
		{
			get
			{
				return this.atEnd;
			}
		}
	}
}
