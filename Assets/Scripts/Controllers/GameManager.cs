using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using Shraa1.CardGame.Models;
using Shraa1.CardGame.Views;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class GameManager : MonoBehaviour, IGameManagerService {
		#region Inspector Variables
		//HACK? Use LobbyReferences later, currently using it for ease of use. Ideally don't have this as a MonoBehaviour.
		//Use the static constructor to register the service, and unregister it in the destroyer. Or maybe even in scene0handler
		//Same for other managers in this folder
		[SerializeField] private LobbyView m_LobbyView;

		[SerializeField] private GameInfo m_GameInfo;
		#endregion Inspector Variables

		#region Inspector Implementation
		public GameInfo GameInfo { get => m_GameInfo; }

		public void StartGame(int x, int y) {
		}
		#endregion Inspector Implementation

		#region Unity Methods
		private void Start() {
			GlobalReferences.Register<IGameManagerService>(this);
			m_LobbyView.Init();
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<IGameManagerService>();
		}
		#endregion Unity Methods
	}
}