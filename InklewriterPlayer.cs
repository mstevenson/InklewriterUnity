using UnityEngine;
using System.Collections;
using Inklewriter;
using Inklewriter.Player;

namespace Inklewriter.Unity
{
	public class InklewriterPlayer : MonoBehaviour
	{
		public string storyName;

		StoryPlayer player;

		void Start ()
		{
			var resource = Resources.Load (storyName) as TextAsset;
			if (!resource) {
				Debug.LogWarning ("Inklewriter story could not be loaded: " + storyName);
				return;
			}

			string storyJson = resource.text;
			StoryModel model = new StoryModel ();
			model.ImportStory (storyJson);

			this.player = new StoryPlayer (model, new UnityMarkupConverter ());
		}

		public void SelectOption (Option option)
		{
			if (option.LinkStitch != null) {
				var chunk = player.GetChunkFromStitch (option.LinkStitch);
				// TODO instantiate a new chunk prefab, set its text, instantiate buttons
			}
		}
	}
}