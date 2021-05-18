using System;
using UnityEngine;

namespace KnightTale.Core{

  public class FaderSpawner : MonoBehaviour {
    [SerializeField] GameObject toBeSpawned;

    static bool hasSpawned = false;

    private void Awake() {

      if(hasSpawned) return;

      SpawnObjects();

      hasSpawned = true;

    }

    private void SpawnObjects()
    {
      GameObject spawningObject = Instantiate(toBeSpawned);
      DontDestroyOnLoad(spawningObject);
    }
  }
}
