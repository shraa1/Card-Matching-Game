using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shraa1.CardGame.Models {
	[CreateAssetMenu(fileName = "CardInfo", menuName = "ScriptableObjects/CardInfo")]
	public class CardInfo : ScriptableObject {
		#region Inspector Variables
		/// <summary>
		/// Time needed to flip the card
		/// </summary>
		[SerializeField] private float m_CardFlipDuration;
		#endregion Inspector Variables

		#region Properties
		/// <summary>
		/// Time needed to flip the card
		/// </summary>
		public float CardFlipDuration { get => m_CardFlipDuration; }
		#endregion Properties
	}
}