using System.Collections;
using System.Collections.Generic;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Shraa1.CardGame.Views {
	public class LobbyView : MonoBehaviour {
		#region Inspector Variables
		//HACK? Since it's easier and safer to parse the string "2" directly into an int, doing it with 2 separate dropdowns.
		//Could use one and have text like 2x2 and then discard the x or * and get the 2 values.
		//Choosing it this way so it's better UX for the user if the number of choices are many.

		/// <summary>
		/// Gridsize number of columns dropdown
		/// </summary>
		[SerializeField] private Dropdown m_GridSizeX;

		/// <summary>
		/// Gridsize number of rows dropdown
		/// </summary>
		[SerializeField] private Dropdown m_GridSizeY;

		/// <summary>
		/// Play Button
		/// </summary>
		[SerializeField] private Button m_PlayGameBtn;

		/// <summary>
		/// Lobby Canvas reference to enable disable on switching to game
		/// </summary>
		[SerializeField] private Canvas m_LobbyCanvas;

		/// <summary>
		/// Set High Score's text
		/// </summary>
		[SerializeField] private Text m_HighScoreText;
		#endregion Inspector Variables

		#region Variables & Consts
		private const string GAME_SCENE_NAME = "Game Scene";
		private const string HIGH_SCORE_TEXT = "High Score: {0}";
		#endregion Variables & Consts

		#region Properties
		private IGameManagerService GameManagerService => GlobalReferences.GameManagerService;
		#endregion Properties

		#region Unity Methods
		private void Start() {
			GlobalReferences.StatsManagerService.OnHighScoreUpdated += UpdateHS;
			UpdateHS();
		}
		#endregion Unity Methods

		#region Public Helper Methods
		/// <summary>
		/// Set up things at the beginning
		/// </summary>
		public void Init() {
			var info = GameManagerService.GameInfo;
			var list = new List<string>(info.GridSizeMax.x - info.GridSizeMin.x + 1);
			for (var i = info.GridSizeMin.x; i <= info.GridSizeMax.x; i++)
				list.Add(i.ToString());
			m_GridSizeX.AddOptions(list);

			list.Clear();
			list.Capacity = info.GridSizeMax.y - info.GridSizeMin.y + 1;
			for (var i = info.GridSizeMin.y; i <= info.GridSizeMax.y; i++)
				list.Add(i.ToString());
			m_GridSizeY.AddOptions(list);

			m_PlayGameBtn.onClick.AddListener(PlayGame);
		}

		public void CloseGameScene() {
			SceneManager.UnloadScene(GAME_SCENE_NAME);
			m_LobbyCanvas.enabled = true;
		}
		#endregion Public Helper Methods

		#region Private Helper Methods
		private void UpdateHS() => m_HighScoreText.text = string.Format(HIGH_SCORE_TEXT, GlobalReferences.StatsManagerService.HighScore);

		/// <summary>
		/// Play Game Button Clicked
		/// </summary>
		private void PlayGame() {
			var x = int.Parse(m_GridSizeX.options[m_GridSizeX.value].text);
			var y = int.Parse(m_GridSizeY.options[m_GridSizeY.value].text);

			void SceneLoaded(Scene arg0, LoadSceneMode arg1) {
				SceneManager.sceneLoaded -= SceneLoaded;
				if (arg0.name.StartsWith(GAME_SCENE_NAME)) {
					m_LobbyCanvas.enabled = false;
					GameManagerService.StartGame(x, y);
				}
			}

			SceneManager.sceneLoaded += SceneLoaded;
			SceneManager.LoadScene(GAME_SCENE_NAME, LoadSceneMode.Additive);
		}
		#endregion Private Helper Methods
	}
}