using UnityEngine;
using UnityEngine.UI;
using Inklewriter.Player;
using System.IO;

namespace Inklewriter.Unity
{
	public class TextBlock : MonoBehaviour
	{
		public Text text;
		public Image image;

		public void Set (Paragraph p)
		{
			if (!string.IsNullOrEmpty (p.Image)) {
				var imageName = Path.GetFileNameWithoutExtension (p.Image);
				var sprite = Resources.Load<Sprite> (imageName);
				Debug.Log ("have sprite");
				if (sprite) {
					image.sprite = sprite;
					image.SetNativeSize ();
				}
			} else {
			}

			this.text.text = "    " + p.Text;
		}
	}
}