using KnightTale.Core;
using KnightTale.Control;
using KnightTale.Movement;
using UnityEngine;
using System;
using UnityEngine.AI;

namespace KnightTale.Combat{
  public class EnemyAI : MonoBehaviour {
    
    [SerializeField] float chasingDist = 5f;
    [SerializeField] float susTime = 5f;
    [SerializeField] Patrol patrol;
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] float dwellAtWaypoint = 3f;
    GameObject player;
    FightingController enemyCombat;
    Health health;
    MoveController moveBack;
    Vector3 guardLocation;
    float kindaSus = Mathf.Infinity;
    float arrivedAtWayp = Mathf.Infinity;
    int waypointIndex = 0;

    private void Awake() {
       player = GameObject.Find("Player");
       enemyCombat = GetComponent<FightingController>();
       health = GetComponent<Health>();
       moveBack = GetComponent<MoveController>();
       guardLocation = transform.position;
    }

    private void Update()
    { 
      if(health.GetIsDead()) return;

      if(GetDistance() && enemyCombat.CanAttack(player))
      {
        kindaSus = 0;
        GetComponent<NavMeshAgent>().speed = 5f;
        enemyCombat.Attack(player);
        
      } else if(kindaSus < susTime)
      {
        
        Suspicion();
      }
      else
      {
        KeepPatrolling();
      }

      kindaSus += Time.deltaTime;
      arrivedAtWayp += Time.deltaTime;
    }

    private void KeepPatrolling()
    {
      Vector3 nextPosition = guardLocation;

      if(patrol != null){

        if(AtWaypoint()){
          AdvanceToNextWaypoint();
          arrivedAtWayp = 0;
        }
        nextPosition = GetCurrentWaypoint();

      }

      if(arrivedAtWayp > dwellAtWaypoint ){
        moveBack.StartMoveAction(nextPosition);
      }
    }

    private Vector3 GetCurrentWaypoint()
    {
      return patrol.GetWaypoint(waypointIndex);
    }

    private void AdvanceToNextWaypoint()
    {
      waypointIndex = patrol.GetNext(waypointIndex);
    }

    private bool AtWaypoint()
    {
      return Vector3.Distance(transform.position, GetCurrentWaypoint()) < waypointTolerance;
    }

    private void Suspicion()
    {
      GetComponent<NavMeshAgent>().speed = 3f;
      GetComponent<ActionPrio>().CancelCurrentAction();
    }

    public bool GetDistance(){
      return Vector3.Distance(transform.position, player.transform.position) < chasingDist;
    }


    private void OnDrawGizmosSelected() {
      Gizmos.color = Color.red;
      Gizmos.DrawWireSphere(transform.position, chasingDist);
    }
  }//end of class
}
