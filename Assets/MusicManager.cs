using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MusicManager : MonoBehaviour
{
    public AudioClip godzilla;
    public AudioClip khromge;
    public AudioClip jamming;

    public int music = 1;

    AudioSource audioSrc;

    public GameObject playButton;

    public Sprite pl, pa;
    public Image status;

    bool paused = false;

    public TMP_Text musicName;
    void Start()
    {

        status = playButton.gameObject.GetComponent<Image>();
        audioSrc = GetComponent<AudioSource>();
        
        if (music == 1)
        {
            musicName.text = "Jamming in Home - Ft. Tad on";
            audioSrc.clip = jamming;
            audioSrc.Play();
        }
        else if (music == 2)
        {
            musicName.text = "Fear the Godzilla - Epic Theme";
            audioSrc.clip = godzilla;
            audioSrc.Play();
        }
        else if (music == 3)
        {
            musicName.text = "Kong was Here - Ft. Joshua Empyre";
            audioSrc.clip = khromge;
            audioSrc.Play();
        }
    }

    public void Next()
    {
        music += 1;
        if (music <= 3 && music >= 1)
        {

            if (music == 2)
            {
                musicName.text = "Fear the Godzilla - Epic Theme";
                audioSrc.clip = godzilla;
                audioSrc.Play();
            }
            else if (music == 3)
            {
                musicName.text = "Kong was Here - Ft. Joshua Empyre";
                audioSrc.clip = khromge;
                audioSrc.Play();
            }
        }
        if (music == 4)
        {
            music = 1;
            if (music == 2)
            {
                musicName.text = "Fear the Godzilla - Epic Theme";
                audioSrc.clip = godzilla;
                audioSrc.Play();
            }
            else if (music == 3)
            {
                musicName.text = "Kong was Here - Ft. Joshua Empyre";
                audioSrc.clip = khromge;
                audioSrc.Play();
            }
            else if (music == 1)
            {
                musicName.text = "Jamming in Home - Ft. Tad on";
                audioSrc.clip = jamming;
                audioSrc.Play();
            }
        }
    }

    public void Prev()
    {
        music -= 1;
        if (music >= 1 && music <= 3)
        {

            if (music == 2)
            {
                musicName.text = "Fear the Godzilla - Epic Theme";
                audioSrc.clip = godzilla;
                audioSrc.Play();
            }
            else if (music == 3)
            {
                musicName.text = "Kong was Here - Ft. Joshua Empyre";
                audioSrc.clip = khromge;
                audioSrc.Play();
            }
            else if (music == 1)
            {
                musicName.text = "Jamming in Home - Ft. Tad on";
                audioSrc.clip = jamming;
                audioSrc.Play();
            }
        }
        if (music == 0)
        {
            music = 3;
            if (music == 2)
            {
                musicName.text = "Fear the Godzilla - Epic Theme";
                audioSrc.clip = godzilla;
                audioSrc.Play();
            }
            else if (music == 3)
            {
                musicName.text = "Kong was Here - Ft. Joshua Empyre";
                audioSrc.clip = khromge;
                audioSrc.Play();
            }
            else if (music == 1)
            {
                musicName.text = "Jamming in Home - Ft. Tad on";
                audioSrc.clip = jamming;
                audioSrc.Play();
            }
        }
    }

    public void PlayPause()
    {
        if (paused == false)
        {
            status.sprite = pa;
            audioSrc.Pause();
            paused = true;
        }
        else
        {
            status.sprite = pl;
            audioSrc.Play();
            paused = false;
        }
    }

}
