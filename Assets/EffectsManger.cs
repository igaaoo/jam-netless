using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EffectsManger : MonoBehaviour
{
    public AudioClip Bocejo;
    public AudioClip Choro;
    public AudioClip Hum;
    public AudioClip Raiva;
    public AudioClip RizadaMaléfica;

    public GameObject[] button;

    AudioSource audioSource;

    void Start(){
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayDub(){
        StartCoroutine(Triste());
    }

    IEnumerator Triste(){
        yield return new WaitForSeconds(2);
        audioSource.clip = Choro;
        audioSource.Play();

        yield return new WaitForSeconds(2);
        button[0].SetActive(true);
        button[1].SetActive(true);

        yield return new WaitForSeconds(1);
        audioSource.clip = Hum;
        audioSource.Play();
    }
}
