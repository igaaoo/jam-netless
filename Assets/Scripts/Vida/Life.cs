using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Life : MonoBehaviour
{
    public int life;
    public TMP_Text TextoVida;

    public AudioClip hit;

    AudioSource audioSource;

    public GameObject particleWin;

    bool canUpdate = true;

    public Animator anim;
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;
    public GameObject velocity;

    public GameObject rage;
    public GameObject painelButton;

    float currentTime;
    public int startMinutes;

    public TMP_Text currentTimeText;

    bool timerActive = false;

    public Rigidbody2D rb;

    public GameObject music;

    public GameObject StepAudio;

    public GameObject painelButton2;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        velocity = GameObject.Find("VelocityControll");
        currentTime = startMinutes * 120;
        StartTimer();
    }

    // Update is called once per frame
    void Update()
    {

        UpdateLife();
        Die();

        if (timerActive == true)
        {
            if (currentTime > 0)
            {
                currentTime = currentTime - Time.deltaTime;
                currentTimeText.text = Mathf.RoundToInt(currentTime).ToString();
            }
            else
            {
                TimeOver();
            }

        }


    }

    void TimeOver()
    {
        currentTimeText.text = "TIME IS OVER";
        Desact();
        music.GetComponent<AudioSource>().enabled = false;
        StepAudio.SetActive(true);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);

    }
    void StartTimer()
    {
        timerActive = true;
    }

    void StopTimer()
    {
        timerActive = false;
    }


    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Obstacle")
        {
            audioSource.clip = hit;
            audioSource.Play();
            ReduzLife();
            spriteRenderer.color = new Color(1, 0, 0, 1);
            StartCoroutine(Dano());

        }
    }

    public void ReduzLife()
    {
        life -= 1;
    }

    void UpdateLife()
    {
        if (canUpdate == true)
        {
            TextoVida.text = life.ToString();
        }
        else
        {
            TextoVida.text = "DIED!";

        }
    }

    void Die()
    {
        if (life <= 0)
        {
            velocity.GetComponent<Velocity>().Fim();
            GameObject.Find("P1").GetComponent<loopBackground>().enabled = false;
            GameObject.Find("P2").GetComponent<loopBackground>().enabled = false;
            GameObject.Find("VelocityControll").GetComponent<MultiV>().enabled = false;
            Destroy(rage.gameObject);
            painelButton.SetActive(true);
            particleWin.SetActive(true);
            canUpdate = false;
            StopTimer();
            gameObject.GetComponent<Animator>().enabled = false;
            spriteRenderer.sprite = sprite;
            music.GetComponent<AudioSource>().enabled = false;
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Obstacle");
            foreach (GameObject enemy in enemies)
                GameObject.Destroy(enemy);

        }
    }

    void Desact()
    {
        velocity.GetComponent<Velocity>().Fim();
        GameObject.Find("P1").GetComponent<loopBackground>().enabled = false;
        GameObject.Find("P2").GetComponent<loopBackground>().enabled = false;
        GameObject.Find("VelocityControll").GetComponent<MultiV>().enabled = false;
        Destroy(rage.gameObject);
        painelButton2.SetActive(true);
        gameObject.GetComponent<Animator>().enabled = true;
        anim.SetBool("End", true);
        rb.constraints = RigidbodyConstraints2D.None;
        rb.velocity = new Vector2(3, 0f);

    }

    IEnumerator Dano()
    {
        yield return new WaitForSeconds(0.1f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
    }
}
