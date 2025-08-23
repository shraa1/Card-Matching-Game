using Shraa1.CardGame.Models;

namespace Shraa1.CardGame.Core {
	public interface IGameManager : IService {
		GameInfo GameInfo { get; }
	}
}