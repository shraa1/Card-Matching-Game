using Shraa1.CardGame.Core;
using UnityEngine;

namespace Shraa1.CardGame.Flyweights {
	public class GlobalReferences : MonoBehaviour {
		#region Properties
		private static IServiceProvider GlobalServiceProvider => ServiceHandler.ServiceProviders[(int)ServicesScope.GLOBAL];

		public static IGameManager GameService => GlobalServiceProvider.Get<IGameManager>();
		#endregion Properties

		#region Publlic Helper Methods
		public static void Register<T>(T service) where T : class, IService => GlobalServiceProvider.Register(service);
		public static void Unregister<T>() where T : class, IService => GlobalServiceProvider.Unregister<T>();
		public static T Get<T>() where T : class, IService => GlobalServiceProvider.Get<T>();
		#endregion Publlic Helper Methods
	}
}