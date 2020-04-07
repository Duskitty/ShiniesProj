using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioClip mirageSound, playerDamageSound;
    private AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
      mirageSound = Resources.Load<AudioClip>("MirageFade");
      playerDamageSound = Resources.Load<AudioClip>("PlayerDamage");
      audioSrc = GetComponent<AudioSource>();
    }

    public void playSound(string soundName)
    {
      switch (soundName)
      {
        case "mirage":
          audioSrc.PlayOneShot(mirageSound);
          break;
        case "playerDamage":
          audioSrc.PlayOneShot(playerDamageSound);
          break;
      }
    }
}
