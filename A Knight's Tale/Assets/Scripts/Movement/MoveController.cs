using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


  public class MoveController : MonoBehaviour
  {

    Ray lastRay;
   float fixedRotation = 0;
   


   private void Update() {
     if(Input.GetMouseButtonDown(0)){
       MoveTo();
     }

     UpdateAnimator();
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
  private void UpdateAnimator()
  {
    Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
    Vector3 localVelocity = transform.InverseTransformDirection(velocity);

    float speed = localVelocity.z;
    
    GetComponent<Animator>().SetFloat("fwdSpeed", speed);
  }
}//end of class


