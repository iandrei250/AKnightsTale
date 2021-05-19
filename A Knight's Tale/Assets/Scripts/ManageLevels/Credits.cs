using KnightTale.Control;
using KnightTale.Core;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    Health health;
    float timeSinceDeath = 3f;
    float timeToWait = 0;

    private void Awake() {
      health = GetComponent<Health>();
    }
    private void Update() {
      
      LoadCredits();

    }
      private void LoadCredits(){

        if(health.GetHealth() == 0)
        {
          GameObject.Find("Player").GetComponent<PlayerController>().enabled = false;
         if(timeToWait > timeSinceDeath) SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
         else timeToWait += Time.deltaTime;
        }
      }//end of class
}
