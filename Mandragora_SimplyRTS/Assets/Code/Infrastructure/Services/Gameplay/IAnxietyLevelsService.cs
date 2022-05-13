namespace Code.Infrastructure.Services.Gameplay
{
  public interface IAnxietyLevelsService : IService
  {
    void DeclareAnxiety();
    void StopAnxiety();
  }
}