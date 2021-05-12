using KnightTale.Movement;
using UnityEngine;

namespace KnightTale.Control{
  public class PlayerController : MonoBehaviour {

  private void Update() {
      if(Input.GetMouseButtonDown(0)){
       MoveToCursorPosition();
     }
  }

    private void MoveToCursorPosition()
    {
      Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
      RaycastHit hitInfo;
      bool hasHit = Physics.Raycast(ray, out hitInfo);

      if(hasHit)
      {
        GetComponent<MoveController>().MoveToPoint(hitInfo.point);
      }
    }

  }//end of class
}