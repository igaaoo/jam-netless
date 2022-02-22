using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Botoes : MonoBehaviour
{
    //casa
    public GameObject casa1;
    public GameObject casa2;
    public GameObject casa3;

    public bool canspawncasa;
    public Button bcasa;

    public int chancecasa;

    //predio
    public GameObject predio1;
    public GameObject predio2;
    public GameObject predio3;

    public bool canspawnpredio;
    public Button bpredio;

    public int chancepredio;


    //Foguete
    public GameObject foguete;
    public bool canspawnfoguete;
    public Button bfoguete;

    public float tempoderecarga;

    
    // Start is called before the first frame update
    void Start()
    {
        canspawncasa = true;
        canspawnpredio = true;
        canspawnfoguete = true;
    }

    // Update is called once per frame
    void Update()
    {
        tempoderecarga = GameObject.Find("VelocityControll").GetComponent<MultiV>().temprecarga;
    }

    public void Casa()
    {
        
        StartCoroutine(CountCasa());
        if(canspawncasa == true)
        {
            chancecasa = Random.Range(0,3);
            if(chancecasa == 0)
            {
                Instantiate(casa1, new Vector3(GameObject.Find("SpawnCasa").transform.position.x, GameObject.Find("SpawnCasa").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnCasa").transform);
            }
            if(chancecasa == 1)
            {
                Instantiate(casa2, new Vector3(GameObject.Find("SpawnCasa").transform.position.x, GameObject.Find("SpawnCasa").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnCasa").transform);
            }
            if(chancecasa == 2)
            {
                Instantiate(casa3, new Vector3(GameObject.Find("SpawnCasa").transform.position.x, GameObject.Find("SpawnCasa").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnCasa").transform);
            }
            
            bcasa.interactable = false;
            bpredio.interactable = false;
            bfoguete.interactable = false;
            canspawncasa = false;
            
        }
        
    }

    IEnumerator CountCasa()
    {
        yield return new WaitForSeconds(tempoderecarga);
        bcasa.interactable = true;
        bpredio.interactable = true;
        bfoguete.interactable = true;
        canspawncasa = true;
    }

    public void Predio()
    {
        
        StartCoroutine(CountPredio());
        if(canspawnpredio == true)
        {
            chancepredio = Random.Range(0,3);
            if(chancepredio == 0)
            {
                Instantiate(predio1, new Vector3(GameObject.Find("SpawnCasa").transform.position.x, GameObject.Find("SpawnCasa").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnCasa").transform);
            }
            if(chancepredio == 1)
            {
                Instantiate(predio2, new Vector3(GameObject.Find("SpawnCasa").transform.position.x, GameObject.Find("SpawnCasa").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnCasa").transform);
            }
            if(chancepredio == 2)
            {
                Instantiate(predio3, new Vector3(GameObject.Find("SpawnCasa").transform.position.x, GameObject.Find("SpawnCasa").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnCasa").transform);
            }
            
            bcasa.interactable = false;
            bpredio.interactable = false;
            bfoguete.interactable = false;
            canspawnpredio = false;
            
        }
        
    }

    IEnumerator CountPredio()
    {
        yield return new WaitForSeconds(tempoderecarga);
        bcasa.interactable = true;
        bpredio.interactable = true;
        bfoguete.interactable = true;
        canspawnpredio = true;
    }


    public void Foguete()
    {
        
        StartCoroutine(CountFoguete());
        if(canspawnfoguete == true)
        {
            Instantiate(foguete, new Vector3(GameObject.Find("SpawnFoguete").transform.position.x, GameObject.Find("SpawnFoguete").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnFoguete").transform);
            
            bcasa.interactable = false;
            bpredio.interactable = false;
            bfoguete.interactable = false;
            canspawnfoguete = false;
            
        }
        
    }

    IEnumerator CountFoguete()
    {
        yield return new WaitForSeconds(tempoderecarga);
        bcasa.interactable = true;
        bpredio.interactable = true;
        bfoguete.interactable = true;
        canspawnfoguete = true;
    }
    
}
