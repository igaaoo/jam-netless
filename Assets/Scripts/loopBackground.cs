using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopBackground : MonoBehaviour
{
    public float speed;
    public Renderer backgroudRenderer;
    public float controlle;
    // Start is called before the first frame update
    void Start()
    {
        speed = GameObject.Find("VelocityControll").GetComponent<Velocity>().actualvelocity;
        speed = speed - controlle;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        speed = GameObject.Find("VelocityControll").GetComponent<Velocity>().actualvelocity;
        speed = speed -  controlle;
        backgroudRenderer.material.mainTextureOffset += new Vector2(speed * Time.deltaTime, 0f);
    }
}
