using UnityEngine;
using UnityEngine.Playables;
using KnightTale.Core;
using KnightTale.Control;

namespace KnightTale.Cutscenes{
  public class CutsceneMovementDisabler : MonoBehaviour {
  
    GameObject player;

    private void Awake() {
      player = GameObject.Find("Player");
      GetComponent<PlayableDirector>().played += DisableMovement;
      GetComponent<PlayableDirector>().stopped += EnableMovement;
    }

    void DisableMovement(PlayableDirector playableDirector){
        player.GetComponent<ActionPrio>().CancelCurrentAction();
        player.GetComponent<PlayerController>().enabled = false;
    }

    void EnableMovement(PlayableDirector playableDirector){
        player.GetComponent<PlayerController>().enabled = true;
    }

  }
}

