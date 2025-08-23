using Shraa1.CardGame.Core;
using UnityEngine;

namespace Shraa1.CardGame.Flyweights {
	public class LobbyReferences : MonoBehaviour {
		#region Properties
		private static IServiceProvider LobbyServiceProvider => ServiceHandler.ServiceProviders[(int)ServicesScope.LOBBY];
		#endregion Properties

		#region Publlic Helper Methods
		public static void Register<T>(T service) where T : class, IService => LobbyServiceProvider.Register(service);
		public static void Unregister<T>() where T : class, IService => LobbyServiceProvider.Unregister<T>();
		public static T Get<T>() where T : class, IService => LobbyServiceProvider.Get<T>();
		#endregion Publlic Helper Methods
	}
}