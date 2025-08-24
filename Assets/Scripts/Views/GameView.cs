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
		[SerializeField] private Text m_ScoreText;
		[SerializeField] private Text m_TurnsText;
		[SerializeField] private Text m_StreakText;
		#endregion Inspector Variables

		#region Variables
		//HACK Should be calculated based on a formula, not like this
		private static readonly Dictionary<int, int> CELL_SIZES = new() {
			{ 2, 500 }, { 3, 500 }, { 4, 450 }, { 5, 350 }, { 6, 250 },
		};

		private GameInfo m_GameInfo;

		private const string SCORE_TEXT_BASE = "Score: {0}";
		private const string TURN_TEXT_BASE = "Turn: {0}";
		private const string STREAK_TEXT_BASE = "Streak: {0}";
		#endregion Variables

		#region Unity Methods
		private void Awake() {
			GlobalReferences.GameManagerService.SetGameView(this);
			GlobalReferences.StatsManagerService.OnScoreUpdated += UpdateScore;
			GlobalReferences.StatsManagerService.OnTurnUpdated += UpdateTurns;
			GlobalReferences.StatsManagerService.OnStreakUpdated += UpdateStreak;
		}

		private void OnDestroy() {
			GlobalReferences.StatsManagerService.OnScoreUpdated -= UpdateScore;
			GlobalReferences.StatsManagerService.OnTurnUpdated -= UpdateTurns;
			GlobalReferences.StatsManagerService.OnStreakUpdated -= UpdateStreak;
		}
		#endregion Unity Methods

		#region Private Helper Methods
		private void UpdateScore() => m_ScoreText.text = string.Format(SCORE_TEXT_BASE, GlobalReferences.StatsManagerService.Score);
		private void UpdateTurns() => m_TurnsText.text = string.Format(TURN_TEXT_BASE, GlobalReferences.StatsManagerService.Turns);
		private void UpdateStreak() => m_StreakText.text = string.Format(STREAK_TEXT_BASE, GlobalReferences.StatsManagerService.Streak);
		#endregion Private Helper Methods

		#region Public Helper Methods
		public void UseLayoutGroup(bool activateLayoutGroup) => m_GridLayoutGroup.enabled = activateLayoutGroup;

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