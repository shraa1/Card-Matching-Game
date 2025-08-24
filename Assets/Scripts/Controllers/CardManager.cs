using System.Collections.Generic;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using Shraa1.CardGame.Models;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class CardManager : MonoBehaviour, ICardManagerService {
		#region Properties
		private IGameManagerService GameManager => GlobalReferences.GameManagerService;
		#endregion Properties

		#region Inspector Implementation
		public void GameStarted(int x, int y) {
			var cards = GameManager.GameInfo.FrontCardSprites;
			var len = cards.Length;
			var count = x * y;
			var inUse = ObjectPool<Card>.AllInUseItems;
			var sprites = new List<Sprite>();

			for (var i = 0; i < count; i += 2) {
				var rand = cards[Random.Range(0, len)];
				//Add twice to create the matching pair
				sprites.Add(rand);
				sprites.Add(rand);
			}
			sprites.Shuffle();

			for (var i = 0; i < count; i++)
				inUse[i].Init(sprites[i], GameManager.GameInfo.BackCardSprite);
		}
		#endregion Inspector Implementation

		#region Unity Methods
		private void Start() {
			GlobalReferences.Register<ICardManagerService>(this);
		}

		private void OnDestroy() {
			GlobalReferences.Unregister<ICardManagerService>();
		}
		#endregion Unity Methods
	}
}