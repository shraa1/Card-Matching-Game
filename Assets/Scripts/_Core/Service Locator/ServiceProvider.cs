using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shraa1.CardGame.Core {
	public class ServiceProvider : IServiceProvider {
		#region Variables
		private readonly Dictionary<Type, IService> m_Services = new();
		#endregion Variables

		#region Methods
		public T Get<T>() where T : class, IService => m_Services.TryGetValue(typeof(T), out var service) ? (T)service : null;
		public void Register<T>(T service) where T : class, IService => m_Services[typeof(T)] = service;
		public void Unregister<T>() where T : class, IService => m_Services.Remove(typeof(T));
		#endregion Methods
	}
}