using System;
using System.Collections;
using System.Collections.Generic;
using KnightTale.Combat;
using KnightTale.Core;
using UnityEngine;
using UnityEngine.AI;

  namespace KnightTale.Movement{
  public class MoveController : MonoBehaviour, IAction
  {
    NavMeshAgent navMeshAgent;

    private void Start() {
      navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() {
      UpdateAnimator();
    }

    public void StartMoveAction(Vector3 destination)
    {
      GetComponent<ActionPrio>().StartAction(this);
      MoveToPoint(destination);
    }

    public void MoveToPoint(Vector3 destination)
    {
      navMeshAgent.destination = destination;
      navMeshAgent.isStopped = false;
    }
    public void Cancel()
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



