using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectRay : MonoBehaviour
{
    float moveInput;
    [SerializeField] float speed;
    [SerializeField] float jumpForce;
    [SerializeField] float obstacleRayDistance;
    [SerializeField] float obstacleCabecaRayDistance;

    public Rigidbody2D rb;

    public GameObject groundRayObject;
    public GameObject obstacleRayObject;
    public GameObject obstacleCabecaRayObject;

    public bool jumpOn;
    public bool downOn;
    public float characterDirection;
    public LayerMask layerMask;

    public int jumpchance;
    public int jumpchance1;
    public int chancecount;
    public bool cancount;
    public bool cancount1;

    public AudioSource audioData;

    public ParticleSystem particleJump;

    public Animation camAnimation;

    public AudioClip jump;

    public AudioClip falling;

    public AudioClip scream;

    //mudar animacao
    public SpriteRenderer spriteRenderer;
    public Sprite sprite;

    public Animator anim;

    public BoxCollider2D bc;

    public GameObject telaazul;

    public Animation cam;

    public GameObject StepAudio;




    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        characterDirection = 1f;
        jumpOn = false;
        downOn = true;
    }

    public void UltraRage()
    {
        cancount = true;
        cancount1 = true;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hitObstacle = Physics2D.Raycast(obstacleRayObject.transform.position, Vector2.right * new Vector2(characterDirection, 0f), obstacleRayDistance, layerMask);
        RaycastHit2D hitObstacle1 = Physics2D.Raycast(obstacleCabecaRayObject.transform.position, Vector2.right * new Vector2(characterDirection, 0f), obstacleCabecaRayDistance, layerMask);

        //Abaixaer
        if (hitObstacle1.collider != null && downOn == true)
        {

            Debug.DrawRay(obstacleCabecaRayObject.transform.position, Vector2.right * hitObstacle1.distance * new Vector2(characterDirection, 0f), Color.red);


            if (cancount1 == true)
            {
                cancount1 = false;
                jumpchance1 = Random.Range(0, 100);
                Down();

            }

        }
        else
        {
            Debug.DrawRay(obstacleCabecaRayObject.transform.position, Vector2.right * obstacleCabecaRayDistance * new Vector2(characterDirection, 0f), Color.green);
            cancount1 = true;
        }

        //Pulo
        if (hitObstacle.collider != null && jumpOn == true)
        {

            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * hitObstacle.distance * new Vector2(characterDirection, 0f), Color.red);


            if (cancount == true)
            {
                cancount = false;
                Jump();
            }

        }
        else
        {
            Debug.DrawRay(obstacleRayObject.transform.position, Vector2.right * obstacleRayDistance * new Vector2(characterDirection, 0f), Color.green);
            cancount = true;
        }
    }

    public void FixedUpdate()
    {
        RaycastHit2D hitGround = Physics2D.Raycast(groundRayObject.transform.position, -Vector2.up);
        Debug.DrawRay(groundRayObject.transform.position, -Vector2.up * hitGround.distance, Color.red);
        if (hitGround.collider != null)
        {

            if (hitGround.distance <= .2)
            {
                jumpOn = true;

            }
            else
            {
                jumpOn = false;
                cancount = false;
                jumpchance = 100;
            }
        }
        else
        {
            return;
        }
    }

    public void Jump()
    {

        jumpchance = Random.Range(0, 100);
        if (jumpchance < chancecount && jumpOn == true)
        {
            jumpOn = false;
            rb.velocity = Vector2.up * jumpForce;
            audioData.clip = jump;
            audioData.Play();

        }
    }

    public void Down()
    {

        if (jumpchance1 < chancecount && downOn == true)
        {
            downOn = false;
            spriteRenderer.sprite = sprite;
            bc.size = new Vector2(0.1184057F, 0.1F);
            StartCoroutine(Subir());
            gameObject.GetComponent<Animator>().enabled = false;
        }
    }

    IEnumerator Subir()
    {
        yield return new WaitForSeconds(1);
        downOn = true;
        bc.size = new Vector2(0.1184057F, 0.2F);
        gameObject.GetComponent<Animator>().enabled = true;
    }


    public void AumentarRay()
    {
        obstacleRayDistance += 0.4F;
        obstacleCabecaRayDistance += 0.4F;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "EndGame")
        {
            bc.isTrigger = true;
            StartCoroutine(MonsterWin());
            cam.Play("ShakeLoop");
            Destroy(StepAudio.gameObject);
        }
        else if (coll.gameObject.name == "Chao")
        {
            particleJump.Play();
            camAnimation.Play();
            StartCoroutine(ExplosionSound());
        }
    }

    private IEnumerator ExplosionSound()
    {
        audioData.clip = falling;
        audioData.Play();
        yield return new WaitForSeconds(1);
    }

    private IEnumerator MonsterWin()
    {
        audioData.clip = scream;
        audioData.Play();
        yield return new WaitForSeconds(6);
        telaazul.SetActive(true);
    }


}
