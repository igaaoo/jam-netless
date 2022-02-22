using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalPanel : MonoBehaviour
{
    public GameObject signalPanel;

    private Animation panelAnimations;

    public GameObject icon;

    public GameObject signalAlert;

    public GameObject effects;

    public AudioClip Hum;

    AudioSource effectsAudio;

    void Start()
    {
        StartCoroutine(PanelActivation());
        panelAnimations = signalPanel.GetComponent<Animation>();
        effectsAudio = effects.GetComponent<AudioSource>();
    }

    private IEnumerator PanelActivation()
    {
        yield return new WaitForSeconds(3);

        panelAnimations.Play("SignalPanel");
        icon.gameObject.SetActive(true);
        signalAlert.SetActive(true);
        yield return new WaitForSeconds(1);

        effectsAudio.clip = Hum;
        effectsAudio.Play();

        yield return new WaitForSeconds(10);

        panelAnimations.Play("SignalPanelClose");
        icon.gameObject.SetActive(false);
    }
}
