using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Inklewriter.Unity
{
	public class Chunk : MonoBehaviour
	{
		public Text text;
		public OptionButton option;
		
		public void Set (string text, List<Option> options)
		{
			this.text.text = text;
			foreach (var o in options) {
				// Instantiate option button
			}
		}
	}
	
}