using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using Shraa1.CardGame.Models;
using Shraa1.CardGame.Views;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class GameManager : MonoBehaviour, IGameManager {
		#region Inspector Variables
		[SerializeField] private LobbyView m_LobbyView;
		#endregion Inspector Variables

		#region Properties
		[SerializeField] private GameInfo m_GameInfo;
		public GameInfo GameInfo { get => m_GameInfo; }
		#endregion Properties

		#region Unity Methods
		private void Start() {
			GlobalReferences.Register<IGameManager>(this);
			m_LobbyView.Init();
        }
		#endregion Unity Methods
	}
}