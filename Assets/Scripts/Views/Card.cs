using System.Collections;
using Shraa1.CardGame.Flyweights;
using UnityEngine;
using UnityEngine.UI;

namespace Shraa1.CardGame.Models {
	public class Card : MonoBehaviour, ICard {
		#region Custom DataType
		private enum FlipDirection {
			TOFRONT = 0,
			TOBACK = 1,
		}
		#endregion Custom DataType

		#region Inspector Variables
		[SerializeField] private Image m_CardImageComponent;
		[SerializeField] private Button m_BackButton;
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

		private readonly static WaitForSeconds WaitBeforeInitialFlip = new(2);
		private static bool GAME_STARTED = false;
		#endregion Variables

		#region Properties
		private float CardFlipDuration => GlobalReferences.GameManagerService.CardInfo.CardFlipDuration;
		private AnimationCurve CardFlipCurve => GlobalReferences.GameManagerService.CardInfo.CardFlipCurve;
		public Sprite FrontFacingCardSprite => m_FrontFacingCardSprite;

		/// <summary>
		/// Reference of the sprite for back face of the card
		/// </summary>
		private Sprite BackSprite => GlobalReferences.GameManagerService.GameInfo.BackCardSprite;
		#endregion Properties

		#region Interface Implementation
		public void ShowCard() {

		}

		public void HideCard() {
			StartCoroutine(DoCardFlip(FlipDirection.TOBACK));
		}
		#endregion Interface Implementation

		#region Public Helper Methods
		public void Init(Sprite frontFacingCardSprite) {
			m_FrontFacingCardSprite = frontFacingCardSprite;
			m_CardImageComponent.sprite = frontFacingCardSprite;

			m_BackButton.onClick.RemoveAllListeners();
			m_BackButton.onClick.AddListener(() => {
				if (!GAME_STARTED)
					return;
				if (m_IsFlipping)
					return;
				StartCoroutine(DoCardFlip(FlipDirection.TOFRONT));
				GlobalReferences.CardManagerService.OnCardSelected(this);
			});

			//Do initial flip back after initial reveal
			StartCoroutine(DoFirstTimeCardFlip(FlipDirection.TOBACK));
		}

		public IEnumerator WaitForCardFlipToFinish(System.Action onFlipComplete) {
			while (m_IsFlipping)
				yield return null;

			onFlipComplete?.Invoke();
		}
		#endregion Public Helper Methods

		#region Private Methods
		private IEnumerator DoFirstTimeCardFlip(FlipDirection flipDirection) {
			//Wait for the extra 2 or so seconds so the player can see initially
			yield return WaitBeforeInitialFlip;
			yield return StartCoroutine(DoCardFlip(flipDirection));
			GAME_STARTED = true;
		}

		private IEnumerator DoCardFlip(FlipDirection flipDirection) {
			if (m_IsFlipping)
				yield break;

			m_IsFlipping = true;
			var multiplier = CardFlipCurve.keys[^1].time / CardFlipDuration;

			var i = 0f;
			var mul = 1;
			var spr = BackSprite;
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

			m_IsFlipping = false;
		}
		#endregion Private Methods
	}
}