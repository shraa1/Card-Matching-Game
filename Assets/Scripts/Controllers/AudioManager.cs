using System;
using System.Collections.Generic;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class AudioManager : MonoBehaviour, IAudioManagerService {
		#region Custom DataTypes
		[Serializable]
		public class NamedAudioClip {
			//TODO FIXME Use enum or int, ideally it should not be a string
			public string ClipName;
			public AudioClip AudioClip;
		}
		#endregion Custom DataTypes

		#region Inspector Variables
		[SerializeField] private List<NamedAudioClip> m_SFX = new();
		#endregion Inspector Variables

		#region Variables
		//TODO FIXME there should not be dependence on 1 audiosource, they should be able to play parallely
		private AudioSource m_AudioSource;
		#endregion Variables

		#region Unity Methods
		private void Start() {
			GlobalReferences.Register<IAudioManagerService>(this);
			m_AudioSource = gameObject.AddComponent<AudioSource>();
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<IAudioManagerService>();
		}
		#endregion Unity Methods

		#region Interface Implementation
		public void Play(string sfxName) {
			m_AudioSource.clip = m_SFX.Find(x => x.ClipName == sfxName).AudioClip;
			m_AudioSource.Play();
		}
		#endregion Interface Implementation
	}
}