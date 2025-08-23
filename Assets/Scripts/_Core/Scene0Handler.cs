using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shraa1.CardGame.Core {
	public class Scene0Handler : MonoBehaviour {
		#region Inspector Variables
		[SerializeField] private List<MonoBehaviour> m_IConfigurables = new();
		#endregion Inspector Variables

		#region Unity Methods
		private void Awake() {
			_ = StartCoroutine(LoadAllData());
		}
		#endregion Unity Methods

		#region Private Helper Methods
		/// <summary>
		/// Fire Setups for IConfigurables, and perform some custom load operations if needed
		/// </summary>
		private IEnumerator LoadAllData() {
			foreach (var configurable in m_IConfigurables)
				yield return StartCoroutine((configurable as IConfigurable).Setup());
		}
		#endregion Private Helper Methods
	}
}