using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioSource audio;
    public void playAudio()
    {
        // Toca um áudio determinado no editor
        if (!audio.isPlaying) {
            audio.Play();
        }
        else
        {
            audio.Stop();
            audio.Play();
        }
    }
}
