using System.Collections.Generic;
using UnityEngine;

namespace Shraa1.CardGame.Core {
	public static class Exxtensions_List {
		public static void Shuffle<T> (this List<T> list) {
			var count = list.Count;
			var last = count - 1;

			for(var i = 0; i < last; i++) {
				var r = Random.Range(i, count);
				(list[r], list[i]) = (list[i], list[r]);
			}
		}
	}
}