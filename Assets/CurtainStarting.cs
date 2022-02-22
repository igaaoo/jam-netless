using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurtainStarting : MonoBehaviour
{
    public GameObject loading;

    public GameObject buttonStart;

    public GameObject curtainSound;

    public GameObject effects;

    public AudioClip bocejada;

    AudioSource effectsAudio;
    void Start()
    {
        StartCoroutine(Loading());
        effectsAudio = effects.GetComponent<AudioSource>();
    }

    private IEnumerator Loading()
    {


        yield return new WaitForSeconds(5);

        loading.gameObject.SetActive(false);

        buttonStart.gameObject.SetActive(true);

        curtainSound.gameObject.SetActive(true);

        yield return new WaitForSeconds(2);
        
        effectsAudio.clip = bocejada;
        effectsAudio.Play();

    }
}
