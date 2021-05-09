using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


  public class MoveController : MonoBehaviour
  {
   private void Update() {
     if(Input.GetMouseButtonDown(0)){
       MoveTo();
     }
   }

  private void MoveTo()
  {
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
    RaycastHit hitInfo;
    bool hasHit = Physics.Raycast(ray, out hitInfo);

    if(hasHit){
      GetComponent<NavMeshAgent>().destination = hitInfo.point;
    }
  }
}//end of class


