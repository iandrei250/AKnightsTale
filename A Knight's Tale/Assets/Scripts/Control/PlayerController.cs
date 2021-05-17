using KnightTale.Combat;
using KnightTale.Core;
using KnightTale.Movement;
using UnityEngine;

namespace KnightTale.Control
{
  public class PlayerController : MonoBehaviour {

    Health health;

    private void Awake() {
      health = GetComponent<Health>();
    }

  private void Update()
    {
      if(health.GetIsDead()) return;
     if(ClickToFight()) return;
     if(ClickToMove()) return;
     print("There is nothing for you here!");
    }

    private bool ClickToFight()
    {
      RaycastHit[] raycastHits = Physics.RaycastAll(GetRay());
      foreach (RaycastHit hit in raycastHits)
      {
        CombatTarget target = hit.transform.GetComponent<CombatTarget>();
        if(target == null) continue;

        GameObject targetGameObject = target.gameObject;
        if(!GetComponent<FightingController>().CanAttack(targetGameObject)) continue;

        if(Input.GetMouseButtonDown(0))
        {
          GetComponent<FightingController>().Attack(targetGameObject);
        }
          return true;
      }
      return false;
    }

     private bool ClickToMove()
    {
      RaycastHit hitInfo;
      bool hasHit = Physics.Raycast(GetRay(), out hitInfo);

      if (hasHit)
      {
        if(Input.GetMouseButtonDown(0))
        {
          GetComponent<MoveController>().StartMoveAction(hitInfo.point);
        }

        return true;
      }

      return false;
    }

    private static Ray GetRay()
    {
      return Camera.main.ScreenPointToRay(Input.mousePosition);
    }
  }//end of class
}