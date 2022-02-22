using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Velocity : MonoBehaviour
{
   public float actualvelocity;
   public float multicount;

   void Start()
   {

   }

   public void Update()
   {
      multicount = GameObject.Find("VelocityControll").GetComponent<MultiV>().multip;
      
   }

   public void Multiplicar()
   {
      actualvelocity = actualvelocity * multicount;
   }
   public void Fim()
   {
      actualvelocity = 0;
   }
}
