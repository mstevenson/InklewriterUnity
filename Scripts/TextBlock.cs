using UnityEngine;
using UnityEngine.UI;
using Inklewriter.Player;
using System.Text.RegularExpressions;

namespace Inklewriter.Unity
{
	public class TextBlock : MonoBehaviour
	{
		public Text text;
		public Image image;

		public void Set (Paragraph p)
		{
			if (!string.IsNullOrEmpty (p.Image)) {
				// Get file name without extension
				var imageName = FileNameWithoutExtension (p.Image);
				var sprite = Resources.Load<Sprite> (imageName);
				if (sprite) {
					image.sprite = sprite;
					image.SetNativeSize ();
				}
			} else {
			}

			this.text.text = "    " + p.Text;
		}

		string FileNameWithoutExtension (string path)
		{
			var pattern = @"[^/]*(?=\.[^.]+($|\?))";
			var match = Regex.Match (path, pattern);
			return match.Groups[0].Value;
		}
	}
}