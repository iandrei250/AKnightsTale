using UnityEngine;
using UnityEngine.Audio;
using System;

namespace KnightTale.Sound{
  
  public class AudioManager : MonoBehaviour
  {
      public Sounds[] sounds;

      private void Awake() {
        foreach(Sounds sound in sounds){

            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;

            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
      }

      public void Play(string name){

        Sounds soundToPlay = Array.Find(sounds, sound => sound.name == name);
        soundToPlay.source.Play();

      }
  }// end of clas
}

