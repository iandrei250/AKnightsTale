using UnityEngine;


namespace KnightTale.Control{
  public class Patrol : MonoBehaviour {

    float radius = 0.5f;
    private void OnDrawGizmos() {
      for(int i = 0; i < transform.childCount; i++)
      {
        int j = GetNext(i);

        Gizmos.DrawSphere(GetWaypoint(i), radius);
        Gizmos.DrawLine(GetWaypoint(i), GetWaypoint(j));
      }
    }

    public int GetNext(int i)
    {
      if((i + 1) == transform.childCount){
          return 0;
      }
       return  i + 1;
    }

    public Vector3 GetWaypoint(int i)
    {
      return transform.GetChild(i).position;
    }
  }
}