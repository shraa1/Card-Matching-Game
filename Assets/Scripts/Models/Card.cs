using UnityEngine;

namespace Shraa1.CardGame.Models {
	public class Card : MonoBehaviour {
		#region Inspector Variables
		[SerializeField] private CardInfo m_CardInfo;
		#endregion Inspector Variables

		#region Properties
		public float CardFlipDuration => m_CardInfo.CardFlipDuration;
		#endregion Properties
	}
}