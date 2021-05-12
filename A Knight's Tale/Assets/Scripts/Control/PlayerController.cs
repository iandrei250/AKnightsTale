using KnightTale.Combat;
using KnightTale.Movement;
using UnityEngine;

namespace KnightTale.Control
{
  public class PlayerController : MonoBehaviour {

  private void Update()
    {
     if(ClickToFight()) return;
      if(ClickToMove()) return;
      print("There is nothing for you here!");
    }

    //lookup explanation
    private bool ClickToFight()
    {
      RaycastHit[] raycastHits = Physics.RaycastAll(GetRay());
      foreach (RaycastHit hit in raycastHits)
      {
        CombatTarget target = hit.transform.GetComponent<CombatTarget>();

        if(target == null) continue;

        if(Input.GetMouseButtonDown(0))
        {
          GetComponent<FightingController>().Attack(target);
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
          GetComponent<MoveController>().MoveToPoint(hitInfo.point);
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