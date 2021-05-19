using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

namespace KnightTale.Cutscenes{
  public class CutsceneTrigger : MonoBehaviour
  {

    bool triggered = false;
    private void OnTriggerEnter(Collider other) {

      if(!triggered && other.gameObject.name == "Player"){
        GetComponent<PlayableDirector>().Play();
        triggered = true;
      } 
    }
  }//end of class
}


