using System;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class StatsManager : MonoBehaviour, IStatsMangerService {
		#region Interface Implementation
		public int Score { get => m_Score; }
		public int HighScore { get => m_HighScore; }
		public int Streak { get => m_Streak; }
		public int Turns { get => m_Turns; }

		/// <summary>
		/// Based on the current streak, update the score after a match
		/// </summary>
		public void UpdateScore() {
			m_Score += Streak + BASE_SCORE;
			OnScoreUpdated?.Invoke();
		}

		/// <summary>
		/// Set High Score
		/// </summary>
		public void NewHighScore() {
			m_HighScore = Score;
			OnHighScoreUpdated?.Invoke();
		}

		public void SetStreak(int streak) {
			m_Streak = streak;
			OnStreakUpdated?.Invoke();
		}

		public void SetTurns(int turns) {
			m_Turns = turns;
			OnTurnUpdated?.Invoke();
		}

		public Action OnScoreUpdated { get; set; }
		public Action OnTurnUpdated { get; set; }
		public Action OnStreakUpdated { get; set; }
		public Action OnHighScoreUpdated { get; set; }
		#endregion Interface Implementation

		#region Variables
		private int m_Score = 0;
		private int m_HighScore = 0;
		private int m_Streak = 0;
		private int m_Turns = 0;

		private const int BASE_SCORE = 10;
		#endregion Variables

		#region Unity Methods
		private void Start() {
			GlobalReferences.Register<IStatsMangerService>(this);
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<IStatsMangerService>();
		}

		public void Reset() {
			m_Score = 0;
			m_Streak = 0;
			m_Turns = 0;
			OnScoreUpdated?.Invoke();
			OnStreakUpdated?.Invoke();
			OnTurnUpdated?.Invoke();
		}
		#endregion Unity Methods
	}
}