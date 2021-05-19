using KnightTale.Movement;
using UnityEngine;
using KnightTale.Core;
using UnityEngine.Audio;
using KnightTale.Sound;

namespace KnightTale.Combat{
    public class FightingController : MonoBehaviour,IAction {
    
    [SerializeField] float attackRange = 2f;
    [SerializeField] float timeBetweenAttacks = 1f;
    [SerializeField] float damage = 5f;

    Health target;
    float timeSinceLastAttack = 0;
    

    private void Update()
    {
      timeSinceLastAttack += Time.deltaTime;
      if(target == null ) return;

      if(target.GetIsDead()) return;

      if (!GetIsInRange())
      {
        GetComponent<MoveController>().MoveToPoint(target.transform.position);

      }
      else
      {
        GetComponent<MoveController>().Cancel();
        AttackAction();
      }
    }

    private void AttackAction()
    {  
      transform.LookAt(target.transform);

      if(timeSinceLastAttack > timeBetweenAttacks)
      {
        TriggerAttack();
        timeSinceLastAttack = 0;
      }
    }

    private void TriggerAttack()
    {
      GetComponent<Animator>().ResetTrigger("stopAttack");
      GetComponent<Animator>().SetTrigger("attack");
    }

    void Hit(){
      if(target == null ) return;
      FindObjectOfType<AudioManager>().Play("HitSound");
      target.TakeDamage(damage);
    }

    private bool GetIsInRange()
    {
      return Vector3.Distance(transform.position, target.transform.position) < attackRange;
    }

    public bool CanAttack(GameObject target){

      if(target == null) return false;
      Health targetToTest = target.GetComponent<Health>();
      return targetToTest != null && !targetToTest.GetIsDead();
    }

    public void Attack(GameObject combatTarget)
    {
      GetComponent<ActionPrio>().StartAction(this);
      target = combatTarget.GetComponent<Health>();
    }

     public void Cancel()
    {
      GetComponent<Animator>().SetTrigger("stopAttack");
      target = null;
      GetComponent<MoveController>().Cancel();
    }

    public Health GetTarget(){
      return target;
    }
  }//end of class
}
