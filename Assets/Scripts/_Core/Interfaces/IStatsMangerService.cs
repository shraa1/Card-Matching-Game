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
		/// Number of turns already played, update that
		/// </summary>
		int Turns { get; }

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

		/// <summary>
		/// Set the streak's updated value
		/// </summary>
		/// <param name="streak">New streak</param>
		void SetStreak(int streak);

		/// <summary>
		/// Set the turns' updated value
		/// </summary>
		/// <param name="turns">New turns count</param>
		void SetTurns(int turns);
	}
}