namespace Shraa1.CardGame.Core {
	public interface IServiceProvider {
		T Get<T>() where T : class, IService;
		void Register<T>(T service) where T : class, IService;
		void Unregister<T>() where T : class, IService;
	}
}