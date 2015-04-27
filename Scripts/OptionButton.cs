using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Inklewriter;

namespace Inklewriter.Unity
{
	public class OptionButton : MonoBehaviour
	{
		public Text text;
		public Button button;
		
		Option option;
		InklewriterPlayer player;
		
		public void Set (string text, Option option, InklewriterPlayer player)
		{
			this.text.text = text;
			this.option = option;
			this.player = player;
			
			button.onClick.AddListener (delegate {
				player.SelectOption (option);
			});
		}
	}
	
}