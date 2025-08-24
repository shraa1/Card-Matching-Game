using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class StatsManager : MonoBehaviour, IStatsMangerService {
		#region Interface Implementation
		public int Score { get => m_Score; }
		public int HighScore { get => m_HighScore; }
		public int Streak { get => m_Streak; }
		public void UpdateScore() { }
		public void NewHighScore() { }
		#endregion Interface Implementation

		#region Variables
		private int m_Score = 0;
		private int m_HighScore = 0;
		private int m_Streak = 0;
		#endregion Variables

		#region Unity Methods
		private void Awake() {
			GlobalReferences.Register<IStatsMangerService>(this);
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<IStatsMangerService>();
		}

		public void Reset() {
			m_Score = 0;
			m_HighScore = 0;
			m_Streak = 0;
		}
		#endregion Unity Methods
	}
}