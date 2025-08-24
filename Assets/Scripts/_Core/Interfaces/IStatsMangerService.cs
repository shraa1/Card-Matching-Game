namespace Shraa1.CardGame.Core {
	public interface IStatsMangerService : IService {
		/// <summary>
		/// Current Game Score
		/// </summary>
		int Score { get; }

		/// <summary>
		/// Overall High Score
		/// </summary>
		int HighScore { get; }

		/// <summary>
		/// Current Streak of current matches
		/// </summary>
		int Streak { get; }

		/// <summary>
		/// Update the score
		/// </summary>
		void UpdateScore();

		/// <summary>
		/// New High Score Reached
		/// </summary>
		void NewHighScore();

		/// <summary>
		/// Reset Stats
		/// </summary>
		void Reset();
	}
}