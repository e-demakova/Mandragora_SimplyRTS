namespace Code.Infrastructure.Services.Factories
{
  public interface IBotsFactory : IService
  {
    void CreateBot();
    void Cleanup();
  }
}