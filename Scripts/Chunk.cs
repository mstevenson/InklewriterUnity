using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Inklewriter.Player;

namespace Inklewriter.Unity
{
	public class Chunk : MonoBehaviour
	{
		public TextBlock text;
		public OptionButton option;
		
		public void Set (PlayChunk chunk, InklewriterPlayer player)
		{
			text.gameObject.SetActive (false);
			foreach (var p in chunk.Paragraphs) {
				var obj = Instantiate (text.gameObject) as GameObject;
				obj.SetActive (true);
				obj.transform.SetParent (text.transform.parent);
				obj.GetComponent<TextBlock> ().Set (p);
			}

			option.gameObject.SetActive (false);
			foreach (var o in chunk.Options) {
				if (!o.isVisible) {
					continue;
				}
				var obj = Instantiate (option.gameObject) as GameObject;
				obj.SetActive (true);
				obj.transform.SetParent (option.transform.parent);
				obj.GetComponent<OptionButton> ().Set (o.content, player);
			}
			option.transform.parent.SetAsLastSibling ();
		}
	}
	
}