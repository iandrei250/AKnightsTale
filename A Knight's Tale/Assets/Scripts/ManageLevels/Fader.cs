using UnityEngine;
using System.Collections;

namespace KnightTale.ManageLevels{

  public class Fader : MonoBehaviour {

    CanvasGroup canvasGroup;

    private void Awake() {
      canvasGroup = GetComponent<CanvasGroup>();
    }

    public IEnumerator Fading(){
      yield return FadingOut(3f);
      print("faded out");
      yield return FadingIn(2f);
      print("faded in");
    }

    public IEnumerator FadingOut(float time){
        while(canvasGroup.alpha < 1){
            canvasGroup.alpha += Time.deltaTime / time;
            yield return null;
        }
    }

    public IEnumerator FadingIn(float time){
        while(canvasGroup.alpha > 0 ){
            canvasGroup.alpha -= Time.deltaTime / time;
            yield return null;
        }
    }
  }
}
