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

		/// <summary>
		/// Animation Curve for the card Flip
		/// </summary>
		[SerializeField] private AnimationCurve m_CardFlipCurve;
		#endregion Inspector Variables

		#region Properties
		/// <summary>
		/// Time needed to flip the card
		/// </summary>
		public float CardFlipDuration { get => m_CardFlipDuration; }

		/// <summary>
		/// Animation Curve for the card Flip
		/// </summary>
		public AnimationCurve CardFlipCurve => m_CardFlipCurve;
		#endregion Properties
	}
}