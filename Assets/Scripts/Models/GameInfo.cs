using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shraa1.CardGame.Models {
	/// <summary>
	/// Most related and relevant Game data clubbed together. Have unrelated data in other ScriptableObjects
	/// </summary>
	[CreateAssetMenu(fileName = "GameInfo", menuName = "ScriptableObjects/GameInfo")]
	public class GameInfo : ScriptableObject {
		#region Properties
		/// <summary>
		/// Front Card Sprites
		/// </summary>
		[SerializeField] private Sprite[] m_FrontCardSprites;
		public Sprite[] FrontCardSprite { get => m_FrontCardSprites; }
		#endregion Properties
	}
}