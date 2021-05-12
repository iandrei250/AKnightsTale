using KnightTale.Movement;
using UnityEngine;


namespace KnightTale.Combat{
    public class FightingController : MonoBehaviour {
    
    [SerializeField] float attackRange = 2f;
    Transform target;

    private void Update() {
      bool isInRange = Vector3.Distance(transform.position, target.position) < attackRange;
      if(target != null && !isInRange)
      {
        GetComponent<MoveController>().MoveToPoint(target.position);
      } 
      else 
      {
          GetComponent<MoveController>().StopMoving();
      }
    }
    public void Attack(CombatTarget combatTarget)
    {
      target = combatTarget.transform;
    }
  }
}
