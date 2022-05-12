using Code.Infrastructure.Services.PlayerInput;
using UnityEngine;
using Zenject;

namespace Code.Logic
{
  public class ClickOnMapVisualizer : MonoBehaviour
  {
    [SerializeField]
    private ParticleSystem WalkableGroundEffect;

    [SerializeField]
    private ParticleSystem NotWalkableGroundEffect;

    private IInputService _input;

    [Inject]
    public void Construct(IInputService input)
    {
      _input = input;
      _input.RightClick += OnRightClick;
    }

    private void OnRightClick()
    {
      if (_input.MouseOnWalkableGround())
        ShowEffect(WalkableGroundEffect);
      else
        ShowEffect(NotWalkableGroundEffect);
    }

    private void ShowEffect(ParticleSystem particles)
    {
      MoveToClickPosition(particles);
      Play(particles);
    }

    private static void Play(ParticleSystem particles)
    {
      if (particles.isPlaying)
        particles.Clear();

      particles.Play();
    }

    private void MoveToClickPosition(ParticleSystem particles)
    {
      Vector3 position = _input.MouseMapPosition;
      position.y = particles.transform.position.y;
      particles.transform.position = position;
    }
  }
}