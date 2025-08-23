using System.Collections;

namespace Shraa1.CardGame.Core {
	public interface IConfigurable {
		bool Initialized { get; set; }

		IEnumerator Setup();
	}
}