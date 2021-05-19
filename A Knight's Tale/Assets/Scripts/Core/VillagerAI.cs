using KnightTale.Control;
using KnightTale.Movement;
using UnityEngine;
namespace KnightTale.Core{
  public class VillagerAI : MonoBehaviour {
    [SerializeField] Patrol patrol;
    [SerializeField] float waypointTolerance = 1f;
    [SerializeField] float dwellAtWaypoint = 3f;
    float arrivedAtWayp = Mathf.Infinity;
    Vector3 initialPos;
    int waypointIndex = 0;
    MoveController move;

    private void Awake() {
       move = GetComponent<MoveController>();
      initialPos = transform.position;
    }

     private void Update() {
       Walk();
       arrivedAtWayp += Time.deltaTime;
     }

        private void Walk()
    {
      Vector3 nextPosition = initialPos;

      if(patrol != null){

        if(AtWaypoint()){
          AdvanceToNextWaypoint();
          arrivedAtWayp = 0;
        }
        nextPosition = GetCurrentWaypoint();

      }

      if(arrivedAtWayp > dwellAtWaypoint ){
        move.StartMoveAction(nextPosition);
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
  }//end of class

}