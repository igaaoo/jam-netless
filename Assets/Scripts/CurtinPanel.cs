using System.Collections;
using UnityEngine;

public class CurtinPanel : MonoBehaviour
{

      void Start()
     {
         StartCoroutine(ActivationRoutine());
     }
 
     private IEnumerator ActivationRoutine()
     {        
         yield return new WaitForSeconds(5);
 
         this.gameObject.SetActive(false);
     }

}
