using System.Collections.Generic;
using Shraa1.CardGame.Core;
using Shraa1.CardGame.Flyweights;
using Shraa1.CardGame.Models;
using UnityEngine;

namespace Shraa1.CardGame.Controllers {
	public class CardManager : MonoBehaviour, ICardManagerService {
		#region Variables
		private ICard m_CurrentlyOpenCard;
		#endregion Variables

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
				inUse[i].Init(sprites[i]);
		}

		public void OnCardSelected(ICard card) {
			//A first card was already selected, now second is selected. Then 
			if (m_CurrentlyOpenCard != null) {
				GlobalReferences.StatsManagerService.SetTurns(GlobalReferences.StatsManagerService.Turns + 1);
				if (m_CurrentlyOpenCard.FrontFacingCardSprite == card.FrontFacingCardSprite) {
					GlobalReferences.StatsManagerService.UpdateScore();

					if (GlobalReferences.StatsManagerService.Score > GlobalReferences.StatsManagerService.HighScore)
						GlobalReferences.StatsManagerService.NewHighScore();
					GlobalReferences.StatsManagerService.SetStreak(GlobalReferences.StatsManagerService.Streak + 1);
					var c = m_CurrentlyOpenCard as Card;
					StartCoroutine((card as Card).WaitForCardFlipToFinish(() => {
						ObjectPool<Card>.FreeToPool(card as Card);
						ObjectPool<Card>.FreeToPool(c);
						// When grid size is 3x3 or 5x5 or so, there will be 1 extra pending.
						if (ObjectPool<Card>.AllInUseItems.Count == 0 || ObjectPool<Card>.AllInUseItems.Count == 1) {
							//If there's the pending one, release it
							ObjectPool<Card>.AllInUseItems.ForEach(x => ObjectPool<Card>.FreeToPool(x));
							GameManager.GameOver();
						}
					}));
				}
				else {
					GlobalReferences.StatsManagerService.SetStreak(0);
					var c = m_CurrentlyOpenCard as Card;
					StartCoroutine((card as Card).WaitForCardFlipToFinish(() => {
						c.HideCard();
						card.HideCard();
					}));
				}
				m_CurrentlyOpenCard = null;
				return;
			}

			m_CurrentlyOpenCard = card;
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