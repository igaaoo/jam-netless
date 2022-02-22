using UnityEngine;
using UnityEngine.Audio;

public class MusicVolume : MonoBehaviour
{
    public AudioMixer mixer;



public void SetLevel(float sliderValue) => mixer.SetFloat("Macaco", Mathf.Log10(sliderValue) * 20);
}
