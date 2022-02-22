using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VObjC : MonoBehaviour
{
    public float speedObj;
    public float multicount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        multicount = GameObject.Find("VelocityControll").GetComponent<MultiV>().multip;
        
    }

    public void Multiplicar()
    {
        speedObj = speedObj * multicount;
    }

    
}
