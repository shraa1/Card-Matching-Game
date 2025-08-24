using System.Collections.Generic;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using Shraa1.CardGame.Models;
using UnityEngine;
using UnityEngine.UI;

namespace Shraa1.CardGame.Views {
	public class GameView : MonoBehaviour {
		#region Inspector Variables
		[SerializeField] private GridLayoutGroup m_GridLayoutGroup;
		#endregion Inspector Variables

		#region Variables
		//HACK Should be calculated based on a formula, not like this
		private static readonly Dictionary<int, int> CELL_SIZES = new() {
			{ 2, 500 }, { 3, 500 }, { 4, 450 }, { 5, 350 }, { 6, 250 },
		};
		private GameInfo m_GameInfo;
		#endregion Variables

		#region Unity Methods
		private void Awake() {
			GlobalReferences.GameManagerService.SetGameView(this);
		}
		#endregion Unity Methods

		#region Public Helper Methods
		public void Init(int x, int y) {
			//TODO HACK FIXME, Ideal case don't use UI for doing this. What if uneven grid is to be used? GridLayout for this is not ideal.
			m_GridLayoutGroup.constraintCount = y;
			m_GridLayoutGroup.cellSize = new(CELL_SIZES[x], CELL_SIZES[x]);

			for (var i = 0; i < x * y; i++)
				ObjectPool<Card>.Get(m_GridLayoutGroup.transform);
		}
		#endregion Public Helper Methods
	}
}