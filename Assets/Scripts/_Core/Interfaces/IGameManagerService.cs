using Shraa1.CardGame.Models;
using UnityEngine;

namespace Shraa1.CardGame.Core {
	public interface IGameManagerService : IService {
		/// <summary>
		/// Game Info
		/// </summary>
		GameInfo GameInfo { get; }

		void StartGame(int x, int y);

		void SetGameView(MonoBehaviour gameView);
	}
}