using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Shraa1.CardGame.Models {
	public class Card : MonoBehaviour {
		#region Custom DataType
		private enum FlipDirection {
			TOFRONT = 0,
			TOBACK = 1,
		}
		#endregion Custom DataType

		#region Inspector Variables
		[SerializeField] private CardInfo m_CardInfo;
		[SerializeField] private Image m_CardImageComponent;
		[SerializeField] private Button m_Button;
		#endregion Inspector Variables

		#region Variables
		/// <summary>
		/// To ensure that the card can't be clicked again while mid-flip
		/// </summary>
		private bool m_IsFlipping = false;

		/// <summary>
		/// By default, the card's front is showing. To be used for managing the state of the flip
		/// </summary>
		private bool m_IsFrontShowing = true;

		/// <summary>
		/// Front Facing Card's Sprite in the card image list, cached, for this round
		/// </summary>
		private Sprite m_FrontFacingCardSprite;

		/// <summary>
		/// Reference of the sprite for back face of the card
		/// </summary>
		private Sprite m_BackSprite;

		private readonly static WaitForSeconds WaitBeforeInitialFlip = new(2);
		#endregion Variables

		#region Properties
		public float CardFlipDuration => m_CardInfo.CardFlipDuration;
		public AnimationCurve CardFlipCurve => m_CardInfo.CardFlipCurve;
		#endregion Properties

		#region Public Helper Methods
		public void Init(Sprite frontFacingCardSprite, Sprite backSprite) {
			m_FrontFacingCardSprite = frontFacingCardSprite;
			m_CardImageComponent.sprite = frontFacingCardSprite;
			m_BackSprite = backSprite;

			//Do initial flip back after initial reveal
			StartCoroutine(DoCardFlip(FlipDirection.TOBACK));
		}
		#endregion Public Helper Methods

		#region Private Methods
		private IEnumerator DoCardFlip(FlipDirection flipDirection) {
			yield return WaitBeforeInitialFlip;
			var multiplier = CardFlipCurve.keys[^1].time / CardFlipDuration;

			var i = 0f;
			var mul = 1;
			var spr = m_BackSprite;
			if (flipDirection == FlipDirection.TOFRONT) {
				i = CardFlipDuration;
				mul = -1;
				spr = m_FrontFacingCardSprite;
			}

			IEnumerator Rotate() {
				var euler = transform.rotation.eulerAngles;
				euler.y = CardFlipCurve.Evaluate(i * multiplier);
				transform.rotation = Quaternion.Euler(euler);
				i += mul * Time.deltaTime;
				yield return null;
			}

			//First part of the flip
			while (flipDirection == FlipDirection.TOBACK ? (i <= CardFlipDuration / 2f) : (i > CardFlipDuration / 2f))
				yield return Rotate();

			m_CardImageComponent.sprite = spr;

			//Second part of the flip
			while (flipDirection == FlipDirection.TOBACK ? (i < CardFlipDuration) : (i > 0))
				yield return Rotate();
		}
		#endregion Private Methods
	}
}