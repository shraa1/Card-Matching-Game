namespace Shraa1.CardGame.Core {
	public enum ServicesScope {
		GLOBAL = 0,
		LOBBY = 1,
		GAME = 2,
	}

	public class SavedData {
		//Should not be duplicated in stats and save managers. Should be in flyweights or a common model.
		public int HighScore = 0;

		//TODO HACK ideally a json format and then serialize deserialize it
		public void Load(string loadStr) => HighScore = int.Parse(loadStr);

		//TODO HACK ideally a json format and then serialize deserialize it
		public override string ToString() => HighScore.ToString();
	}
}