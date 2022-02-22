using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public bool canjump;

    public int jump;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Swipe();

        if(Input.GetKeyDown(KeyCode.W) && canjump == true)
        {
            canjump = false;
            GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1000), ForceMode2D.Impulse);
            jump += 1;
        }
    }

    public void Swipe()
    {

        if(Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);
            if(t.phase ==  TouchPhase.Moved)
            {
                if(t.deltaPosition.y > 100  && canjump == true)
                {
                    canjump = false;
                    GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 1500), ForceMode2D.Impulse);
                    jump += 1;
                }
            }
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.name == "Chao") 
        {
            canjump = true;
        }
    }
    void OnTriggerExit2D(Collider2D col)
    {
        canjump = false;
    }
}
