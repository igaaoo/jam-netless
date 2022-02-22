using UnityEngine;

public class VObj : MonoBehaviour
{
    public Rigidbody2D rb;
    public float speed;

    public GameObject groundRayObject;

    private AudioSource audioHouse;

    public ParticleSystem particle;

    // Update is called once per frame
    void Start(){
        audioHouse = this.GetComponent<AudioSource>();
    }
    public void FixedUpdate()
    {
        RaycastHit2D hitGround = Physics2D.Raycast (groundRayObject.transform.position, -Vector2.up);
        Debug.DrawRay (groundRayObject.transform.position, -Vector2.up * hitGround.distance, Color.red);
        if (hitGround.collider != null) {

            if (hitGround.distance <= .2) {
                //jumpOn = true;
                
                speed = GameObject.Find("VelocityControll").GetComponent<VObjC>().speedObj;
                rb.velocity = new Vector2(speed, -10f);

            } else {
                //jumpOn = false;
                //cancount = false;
                //jumpchance = 100;
            }
        } else {
            return;
        }
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "DestroyHouse")
        {
            Destroy(gameObject);
        } else if (coll.gameObject.name == "Chao"){
            audioHouse.Play();
            particle.Play();

        }
    }
}
