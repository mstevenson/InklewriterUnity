using UnityEngine;
using System.Collections;
using Inklewriter;
using Inklewriter.Player;

namespace Inklewriter.Unity
{
	public class InklewriterPlayer : MonoBehaviour
	{
		public string storyName;
		public Chunk chunk;

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

			var firstChunk = player.GetChunkFromStitch (player.InitialStitch);
			InstantiateChunk (firstChunk);
		}

		public void InstantiateChunk (PlayChunk c)
		{
			chunk.gameObject.SetActive (false);
			var obj = Instantiate (chunk.gameObject) as GameObject;
			obj.SetActive (true);
			obj.transform.SetParent (chunk.transform.parent);
			obj.GetComponent<Chunk> ().Set (c, this);
		}

		public void SelectOption (Option option)
		{
			if (option.LinkStitch != null) {
				var chunk = player.GetChunkFromStitch (option.LinkStitch);
				InstantiateChunk (chunk);
			}
		}
	}
}