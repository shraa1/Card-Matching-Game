using System.Collections;
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
		[SerializeField] private CardInfo m_CardInfo;
		[SerializeField] private Card m_CardPrefabTemplate;
		#endregion Inspector Variables

		#region Variables
		private GameView m_GameView;
		#endregion Variables

		#region Inspector Implementation
		public GameInfo GameInfo { get => m_GameInfo; }
		public CardInfo CardInfo { get => m_CardInfo; }

		public void StartGame(int x, int y) {
			m_GameView.UseLayoutGroup(true);
			m_GameView.Init(x, y);
			StartCoroutine(WaitForGameSceneInitializations(x, y));
		}

		//TODO Create an interface instead of MonoBehaviour
		public void SetGameView(MonoBehaviour gameView) => m_GameView = gameView as GameView;

		public void GameOver() => m_LobbyView.CloseGameScene();
		#endregion Inspector Implementation

		#region Private Methods
		//TODO This should be done using IConfigurable, not like this
		private IEnumerator WaitForGameSceneInitializations(int x, int y) {
			while (GlobalReferences.CardManagerService == null)
				yield return null;
			m_GameView.UseLayoutGroup(false);
			GlobalReferences.CardManagerService.GameStarted(x, y);
		}
		#endregion Private Methods

		#region Unity Methods
		private void Start() {
			GlobalReferences.Register<IGameManagerService>(this);
			ObjectPool<Card>.SetTemplate(m_CardPrefabTemplate);
			m_LobbyView.Init();
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<IGameManagerService>();
		}
		#endregion Unity Methods
	}
}