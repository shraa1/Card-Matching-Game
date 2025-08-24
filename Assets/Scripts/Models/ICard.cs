using UnityEngine;

namespace Shraa1.CardGame.Models {
	public interface ICard {
		Sprite FrontFacingCardSprite { get; }
		void ShowCard();
		void HideCard();
	}
}