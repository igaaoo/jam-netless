using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOb : MonoBehaviour
{
    public GameObject particle;
    public BoxCollider2D bc;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.name == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            bc.isTrigger = true;
            StartCoroutine(Tempo());
            particle.SetActive(true);
        }
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(3);
        Destroy(gameObject);
    }
}
