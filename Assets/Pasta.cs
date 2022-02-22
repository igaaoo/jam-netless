using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pasta : MonoBehaviour
{
    bool on = false;

    public GameObject pasta;
    public void OpenClose(){
        on = !on;
        if(on == false){
            pasta.SetActive(true);
        }

        

        if(on == true){
            pasta.SetActive(false);
        }
    }
}
