﻿using UnityEngine;

namespace Code.Infrastructure.Services.AssetsManagement
{
  public interface IAssetsProvider : IService
  {
    GameObject Instantiate(string path);
    GameObject Instantiate(string path, Vector3 at);
    GameObject Instantiate(string path, Vector3 at, Transform parent);
  }
}