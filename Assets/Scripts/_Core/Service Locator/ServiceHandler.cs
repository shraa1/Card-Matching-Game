using System;
using System.Collections.Generic;

namespace Shraa1.CardGame.Core {
	public static class ServiceHandler {
		/// <summary>
		/// Use a game client side enum to register services for context based service providers.
		/// Keys are int so that new contexts can be easily implemented without having to modifying the ServicesScope enum. Sadly, enums can't be extended :(
		/// </summary>
		public static Dictionary<int, IServiceProvider> ServiceProviders = new();

		/// <summary>
		/// Initialize a service provider based on the context, like lobby, game, etc.
		/// </summary>
		/// <param name="contextIndex">What context is the service registered for?</param>
		public static void Init(int contextIndex) {
			if (ServiceProviders.ContainsKey(contextIndex))
				ServiceProviders[contextIndex] = new ServiceProvider();
			else
				ServiceProviders.Add(contextIndex, new ServiceProvider());
		}
	}
}