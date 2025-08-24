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
		public void UpdateScore() { }
		public void NewHighScore() { }
		public void SetStreak(int streak) => m_Streak = streak;
		public void SetTurns(int turns) => m_Turns = turns;
		#endregion Interface Implementation

		#region Variables
		private int m_Score = 0;
		private int m_HighScore = 0;
		private int m_Streak = 0;
		private int m_Turns = 0;
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
			m_HighScore = 0;
			m_Streak = 0;
			m_Turns = 0;
		}
		#endregion Unity Methods
	}
}