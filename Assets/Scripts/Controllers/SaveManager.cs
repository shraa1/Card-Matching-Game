using System.Collections;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class SaveManager : MonoBehaviour, ISaveManagerService {
		private readonly SavedData SavedData = new();

		#region Interface Implementation
		public void Start() {
			GlobalReferences.Register<ISaveManagerService>(this);
			StartCoroutine(WaitForAFrame());
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<ISaveManagerService>();
		}
		#endregion Interface Implementation

		#region Private Helper Methods
		//TODO FIXME HACK terrible hack fix for now, but this is where IConfigurable should have been used. For all the services set up similarly.
		private IEnumerator WaitForAFrame() {
			yield return new WaitForEndOfFrame();
			GlobalReferences.StatsManagerService.OnHighScoreUpdated += Save;
			Load();
		}

		private void Load() {
			//Save string to a constant
			//TODO add #if UNITY_ANDROID || UNITY_IOS and similar platform wrappers to write to playerprefs or file system, whichever one is more secure.
			if (PlayerPrefs.HasKey("Saved State")) {
				SavedData.Load(PlayerPrefs.GetString("Saved State"));
				//TODO HACK FIXME this issue is caused due to duplication. Like I wrote in SavedData class, it should be in a centralized place or funnel the call there directly.
				GlobalReferences.StatsManagerService.SetHighScore(SavedData.HighScore);
			}
		}

		private void Save() {
			SavedData.HighScore = GlobalReferences.StatsManagerService.HighScore;
			PlayerPrefs.SetString("Saved State", SavedData.ToString());
		}
		#endregion Private Helper Methods
	}
}