using System;
using System.Collections;
using System.Collections.Generic;
using KnightTale.Core;
using UnityEngine;
using UnityEngine.UI;

namespace KnightTale.UI{


  public class HPDisplay : MonoBehaviour
  {
     Health health;
      
    private void Awake() {
        health = GameObject.Find("Player").GetComponent<Health>();
    }

    private void Update() {
      GetComponent<Text>().text = String.Format("{0}/{1}", health.GetHealth(), health.GetMaxHealth());
    }
  }//end of class
}

