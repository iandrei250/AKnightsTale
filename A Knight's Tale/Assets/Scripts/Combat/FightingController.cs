using KnightTale.Movement;
using UnityEngine;
using KnightTale.Core;

namespace KnightTale.Combat{
    public class FightingController : MonoBehaviour,IAction {
    
    [SerializeField] float attackRange = 2f;

    Transform target;

    private void Update()
    {
      if(target == null ) return;
      if (!GetIsInRange())
      {
        GetComponent<MoveController>().MoveToPoint(target.position);

      }
      else
      {
        GetComponent<MoveController>().Cancel();
        AttackAction();
      }
    }

    private void AttackAction()
    {
      GetComponent<Animator>().SetTrigger("attack");
    }

    private bool GetIsInRange()
    {
      return Vector3.Distance(transform.position, target.position) < attackRange;
    }

    public void Attack(CombatTarget combatTarget)
    {
      GetComponent<ActionPrio>().StartAction(this);
      target = combatTarget.transform;
    }

     public void Cancel()
    {
      this.target = null;
    }

    //Animation event
    void Hit(){

    }
  }//end of class
}
