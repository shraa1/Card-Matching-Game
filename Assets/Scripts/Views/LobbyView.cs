using System.Collections;
using System.Collections.Generic;
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

		[SerializeField] private Button m_PlayGameBtn;
		#endregion Inspector Variables

		#region Public Helper Methods
		/// <summary>
		/// Set up things at the beginning
		/// </summary>
		public void Init() {
			var info = GlobalReferences.GameService.GameInfo;
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
		#endregion Public Helper Methods

		#region Private Helper Methods
		private void PlayGame() {
			SceneManager.LoadScene("Game Scene", LoadSceneMode.Additive);
		}
		#endregion Private Helper Methods
	}
}