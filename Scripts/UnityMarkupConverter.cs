using UnityEngine;
using Inklewriter.MarkupConverters;

namespace Inklewriter.Unity
{
	public class UnityMarkupConverter : IMarkupConverter
	{
		public string ReplaceLinkUrlMarkup (string url, string label)
		{
			// Links are not supported by UI Text component.
			return label;
		}
		
		public string ReplaceImageUrlMarkup (string url)
		{
			//		var name = Path.GetFileNameWithoutExtension (url);
			//		var image = Resources.Load (name) as Texture2D;
			//		// TODO modify the text's material to include the image as a separate material
			//		if (image) {
			//			return string.Format ("<quad material=1 size={0} x=0 y=0 width=0.5 height=0.5 />", image.height);
			//		}
			return "";
		}
		
		public string ReplaceBoldStyleMarkup (string text)
		{
			return string.Format ("<b>{0}</b>", text);
		}
		
		public string ReplaceItalicStyleMarkup (string text)
		{
			return string.Format ("<i>{0}</i>", text);
		}
	}
	
}