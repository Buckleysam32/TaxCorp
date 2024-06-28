using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip tapAudio;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void TapAudio()
    {
        print("audio");
        audioSource.Stop();
        audioSource.PlayOneShot(tapAudio);
    }
}
