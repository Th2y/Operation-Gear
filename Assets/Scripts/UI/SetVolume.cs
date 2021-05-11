using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SetVolume : MonoBehaviour
{
    public string exposedParam;
    public AudioMixer mixer;

    public void SetLevel(float sliderValue)
    {
        // Muda o valor do exposedParam do mixer para o valor do slider
        mixer.SetFloat(exposedParam, Mathf.Log10(sliderValue) * 20);
    }
}
