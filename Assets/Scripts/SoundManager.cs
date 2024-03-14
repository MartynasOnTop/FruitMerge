using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static AudioSource source;

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }
    public void playSound(AudioClip clip)
    {
        source.PlayOneShot(clip);
    }
}
