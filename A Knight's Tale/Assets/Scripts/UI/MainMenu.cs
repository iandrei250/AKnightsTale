using KnightTale.Sound;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace KnightTale.UI{
    public class MainMenu : MonoBehaviour
  {
    private void Start() {
        Sounds[] sounds = FindObjectOfType<AudioManager>().sounds;
        foreach(Sounds sound in sounds){
          if(sound.name == "Theme") sound.source.Play();
        }
        
    }
    public void PlayGame(){
      FindObjectOfType<AudioManager>().Play("Click");
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ExitGame(){
      FindObjectOfType<AudioManager>().Play("Click");
      EditorApplication.isPlaying = false;
    }
  }//end of class
}

