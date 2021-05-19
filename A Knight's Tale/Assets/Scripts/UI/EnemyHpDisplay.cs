using System;
using System.Collections;
using System.Collections.Generic;
using KnightTale.Combat;
using KnightTale.Core;
using UnityEngine;
using UnityEngine.UI;

namespace KnightTale.UI{

  public class EnemyHpDisplay : MonoBehaviour
  {
    FightingController player;

    private void Awake() {
      player = GameObject.Find("Player").GetComponent<FightingController>();
    }

    private void Update() {
      if(player.GetTarget() == null)
      {
        GetComponent<Text>().text = "N/A";
        return;
      }

      Health target = player.GetTarget();
      GetComponent<Text>().text = String.Format(String.Format("{0:0}/{1:0}", target.GetHealth(),target.GetMaxHealth()));
    }
  }//end of class
}
