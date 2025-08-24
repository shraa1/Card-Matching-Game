using Shraa1.CardGame.Models;

namespace Shraa1.CardGame.Core {
	public interface ICardManagerService : IService {
		void GameStarted(int x, int y);
		void OnCardSelected(ICard card);
	}
}