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
		/// <summary>
		/// Front Card Sprites
		/// </summary>
		public Sprite[] FrontCardSprite { get => m_FrontCardSprites; }

		/// <summary>
		/// Back Card Face Sprite
		/// </summary>
		[SerializeField] private Sprite m_BackCardSprite;
		/// <summary>
		/// Back Card Face Sprite
		/// </summary>
		public Sprite BackCardSprite { get => m_BackCardSprite; }

		/// <summary>
		/// Grid Size minimum. If 2x2 is the minimum grid, it should be specified here so the user can select the relevant between GridSizeMin and GridSizeMax
		/// </summary>
		[SerializeField] private Vector2Int m_GridSizeMin;
		/// <summary>
		/// Grid Size minimum. If 2x2 is the minimum grid, it should be specified here so the user can select the relevant between GridSizeMin and GridSizeMax
		/// </summary>
		public Vector2Int GridSizeMin { get => m_GridSizeMin; }

		/// <summary>
		/// Grid Size maximum. If 3x6 is the minimum grid, it should be specified here so the user can select the relevant between GridSizeMin and GridSizeMax
		/// </summary>
		[SerializeField] private Vector2Int m_GridSizeMax;
		/// <summary>
		/// Grid Size maximum. If 3x6 is the minimum grid, it should be specified here so the user can select the relevant between GridSizeMin and GridSizeMax
		/// </summary>
		public Vector2Int GridSizeMax { get => m_GridSizeMax; }
		#endregion Properties
	}
}