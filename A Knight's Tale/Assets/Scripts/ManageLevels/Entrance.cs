
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace KnightTale.ManageLevels{

  public class Entrance : MonoBehaviour
  {

    [SerializeField] int sceneToBeLoaded = 0;
    [SerializeField] Transform spawn;

      private void OnTriggerEnter(Collider other) {
      StartCoroutine(LoadingScene());
      }

      private IEnumerator LoadingScene(){

          DontDestroyOnLoad(gameObject);

          Fader fader = FindObjectOfType<Fader>();

          yield return fader.FadingOut(3f);
          
          yield return SceneManager.LoadSceneAsync(sceneToBeLoaded);
          

          Entrance entrance = GetTheOtherEntrance();

          UpdatePlayerPosition(entrance);

          yield return fader.FadingIn(2f);
          Destroy(gameObject);
      }

    private void UpdatePlayerPosition(Entrance entrance)
    {
      GameObject player = GameObject.Find("Player");
      player.transform.position = entrance.spawn.position;
      player.transform.rotation = entrance.spawn.rotation;
    }

    private Entrance GetTheOtherEntrance()
    {
      foreach (Entrance entrance in FindObjectsOfType<Entrance>())
      {
        if(entrance == this) continue;

        return entrance;
      } 

      return null;
    }
  }
}
