using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

  namespace KnightTale.Movement{
  public class MoveController : MonoBehaviour
  {
    NavMeshAgent navMeshAgent;

    private void Start() {
      navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
      UpdateAnimator();
    }
    public void MoveToPoint(Vector3 destination)
    {
      navMeshAgent.isStopped = false;
      navMeshAgent.destination = destination;
    }
    public void StopMoving()
    {
        navMeshAgent.isStopped = true;
    }
    private void UpdateAnimator()
    {
      //lookup the explanation for this
      Vector3 velocity = navMeshAgent.velocity;
      Vector3 localVelocity = transform.InverseTransformDirection(velocity);
      float speed = localVelocity.z;
      
      GetComponent<Animator>().SetFloat("fwdSpeed", speed);
    }
  }//end of class
}



