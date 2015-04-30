using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using Inklewriter;
using Inklewriter.Player;

namespace Inklewriter.Unity
{
	public class InklewriterPlayer : MonoBehaviour
	{
		public string storyName;
		public RectTransform chunkContainer;
		public Chunk chunk;
		public ScrollRect scroll;

		StoryPlayer player;

		List<Chunk> chunks = new List<Chunk> ();

		void Start ()
		{
			var resource = Resources.Load (storyName) as TextAsset;
			if (!resource) {
				Debug.LogWarning ("Inklewriter story could not be loaded: " + storyName);
				return;
			}

			string storyJson = resource.text;
			StoryModel model = StoryModel.Create (storyJson);

			this.player = new StoryPlayer (model, new UnityMarkupConverter ());

			var firstChunk = player.GetChunkFromStitch (player.InitialStitch);
			InstantiateChunk (firstChunk);
		}

		public void InstantiateChunk (PlayChunk c, Option chosenOption = null)
		{
			chunk.gameObject.SetActive (false);
			var chunkObj = Instantiate (chunk.gameObject) as GameObject;
			chunkObj.SetActive (true);
			chunkObj.transform.SetParent (chunk.transform.parent);
			var chunkComponent = chunkObj.GetComponent<Chunk> ();
			chunkComponent.Set (c, chosenOption, this);
			chunks.Add (chunkComponent);

			Canvas.ForceUpdateCanvases ();

			StartCoroutine (AnimateScroll (scroll.verticalNormalizedPosition, 0, 0.5f));
		}

		IEnumerator AnimateScroll (float from, float to, float duration)
		{
			for (float t = 0; t < duration; t += Time.deltaTime) {
				scroll.verticalNormalizedPosition = Mathf.SmoothStep (from, to, t / duration);
				yield return null;
			}
			scroll.verticalNormalizedPosition = Mathf.SmoothStep (from, to, 1);
		}

		public void SelectOption (Option option)
		{
			if (option.LinkStitch != null) {
				if (chunks.Count > 0) {
					chunks[chunks.Count - 1].Disable ();
				}
				var chunk = player.GetChunkFromStitch (option.LinkStitch);
				InstantiateChunk (chunk, option);
			}
		}

		public void RewindToChunk (Chunk chunk)
		{
			for (int i = chunks.Count - 1; i >= 0; i--)
			{
				if (chunks[i] == chunk) {
					return;
				}
				Destroy (chunks[i]);
			}
		}
	}
}