using Shraa1.CardGame.Core;
using UnityEngine;

namespace Shraa1.CardGame.Flyweights {
	public class GlobalReferences : MonoBehaviour {
		#region Properties
		//HACK Ideally, don't modify this class as more managers are created obviously, but for now, it's just a quick
		//easy way to return instead of doing GlobalReferences.GlobalServiceProvider.Get<IGameManager>() where this is called
		private static IServiceProvider GlobalServiceProvider => ServiceHandler.ServiceProviders[(int)ServicesScope.GLOBAL];

		/// <summary>
		/// Get the Game Manager
		/// </summary>
		public static IGameManagerService GameManagerService => GlobalServiceProvider.Get<IGameManagerService>();
		/// <summary>
		/// Get the Stats Manager
		/// </summary>
		public static IStatsMangerService StatsManagerService => GlobalServiceProvider.Get<IStatsMangerService>();
		/// <summary>
		/// Card Manager
		/// </summary>
		public static ICardManagerService CardManagerService => GlobalServiceProvider.Get<ICardManagerService>();
		/// <summary>
		/// Audio Manager
		/// </summary>
		public static IAudioManagerService AudioManagerService => GlobalServiceProvider.Get<IAudioManagerService>();
		/// <summary>
		/// Save and Load Data Manager Service
		/// </summary>
		public static ISaveManagerService SaveManagerService => GlobalServiceProvider.Get<ISaveManagerService>();
		#endregion Properties

		#region Publlic Helper Methods
		/// <summary>
		/// Register a service so that it can be accessed using the interface type
		/// </summary>
		/// <typeparam name="T">Type of IService to be registered</typeparam>
		/// <param name="service">Class that implements the IService that is supposed to be registered against the current service</param>
		public static void Register<T>(T service) where T : class, IService => GlobalServiceProvider.Register(service);

		/// <summary>
		/// Unregister an IService (ideally when context changes, or the service is no longer needed)
		/// </summary>
		/// <typeparam name="T">Type of IService to be unregistered</typeparam>
		public static void Unregister<T>() where T : class, IService => GlobalServiceProvider.Unregister<T>();

		/// <summary>
		/// Get the registered IService of type
		/// </summary>
		/// <typeparam name="T">Type of IService to unregister</typeparam>
		/// <returns>Return the service</returns>
		public static T Get<T>() where T : class, IService => GlobalServiceProvider.Get<T>();
		#endregion Publlic Helper Methods
	}
}