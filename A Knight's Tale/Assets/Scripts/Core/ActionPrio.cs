using UnityEngine;

namespace KnightTale.Core{
  public class ActionPrio : MonoBehaviour{
    
    IAction currentAction;

    public void StartAction(IAction action){

      if(currentAction == action) return;

      if(currentAction != null){
        currentAction.Cancel();
      }
        currentAction = action;
    }
  }

}