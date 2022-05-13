using System;

namespace Code.Infrastructure.Services.Gameplay
{
  public interface IAnxietyService : IService
  {
    event Action Declared;
    event Action Stopped;

    void DeclareAnxiety();
    void StopAnxiety();
  }
}