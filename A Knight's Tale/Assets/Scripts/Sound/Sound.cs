using UnityEngine;
using UnityEngine.Audio;


namespace KnightTale.Sound{
  [System.Serializable]
    public class Sounds {
      public AudioClip clip;
      
      public string name;

      [Range(0f, 1f)]
      public float volume;

      [Range(.1f, 3f)]
      public float pitch; 

      public bool loop;

      [HideInInspector]
      public AudioSource source;
    }//end of class
}

