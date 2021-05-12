using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

  namespace KnightTale.Movement{
      public class MoveController : MonoBehaviour
      {
        Ray lastRay;

      private void Update() {
        UpdateAnimator();
      }

      public void MoveToPoint(Vector3 destination)
      {
        GetComponent<NavMeshAgent>().destination = destination;
      }

      private void UpdateAnimator()
      {
        //lookup the explanation for this
        Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(velocity);

        float speed = localVelocity.z;
        
        GetComponent<Animator>().SetFloat("fwdSpeed", speed);
      }
    }//end of class
  }



