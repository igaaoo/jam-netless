using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiV : MonoBehaviour
{
    public float multip;
    public float temprecarga;

    public GameObject vobj;
    public GameObject velocity;
    public GameObject ray;

    public GameObject rage;

    public GameObject[] ragesPrefab;

    public Transform ragePos;

    public GameObject player;

    AudioSource audSrc;

    public bool ultraRage = false;
    // Start is called before the first frame update
    void Start()
    {
        rage.SetActive(true);
        Instantiate(ragesPrefab[0], ragePos);
        StartCoroutine(Tempo());   
        audSrc = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        vobj = GameObject.Find("VelocityControll");
        velocity = GameObject.Find("VelocityControll");
        ray = GameObject.Find("Player");
        player = GameObject.Find("Player");
        if(ultraRage == true)
        {
            player.GetComponent<DetectRay>().UltraRage();
        }
        
    }

    IEnumerator Tempo()
    {
        yield return new WaitForSeconds(2);
        rage.SetActive(false);

        yield return new WaitForSeconds(10);
        vobj.GetComponent<VObjC>().Multiplicar();
        velocity.GetComponent<Velocity>().Multiplicar();
        ray.GetComponent<DetectRay>().AumentarRay();
        temprecarga -= 0.5f; 
        rage.SetActive(true);
        Instantiate(ragesPrefab[1], ragePos);
        yield return new WaitForSeconds(2);
        rage.SetActive(false);

        yield return new WaitForSeconds(10);
        vobj.GetComponent<VObjC>().Multiplicar();
        velocity.GetComponent<Velocity>().Multiplicar();
        ray.GetComponent<DetectRay>().AumentarRay();
        temprecarga -= 0.5f;
        rage.SetActive(true);
        Instantiate(ragesPrefab[2], ragePos);
        yield return new WaitForSeconds(2);
        rage.SetActive(false);

        yield return new WaitForSeconds(10);
        vobj.GetComponent<VObjC>().Multiplicar();
        velocity.GetComponent<Velocity>().Multiplicar();
        ray.GetComponent<DetectRay>().AumentarRay();
        temprecarga -= 0.5f;
        rage.SetActive(true);
        Instantiate(ragesPrefab[3], ragePos);
        yield return new WaitForSeconds(2);
        rage.SetActive(false);

        yield return new WaitForSeconds(10);
        vobj.GetComponent<VObjC>().Multiplicar();
        velocity.GetComponent<Velocity>().Multiplicar();
        ray.GetComponent<DetectRay>().AumentarRay();
        temprecarga -= 0.5f;
        rage.SetActive(true);
        Instantiate(ragesPrefab[4], ragePos);
        yield return new WaitForSeconds(2);
        rage.SetActive(false);

        yield return new WaitForSeconds(10);
        vobj.GetComponent<VObjC>().Multiplicar();
        velocity.GetComponent<Velocity>().Multiplicar();
        ray.GetComponent<DetectRay>().AumentarRay();
        temprecarga -= 1f;
        rage.SetActive(true);
        Instantiate(ragesPrefab[5], ragePos);
        yield return new WaitForSeconds(2);
        audSrc.enabled = true;
        ultraRage = true;
        rage.SetActive(false);

        
    }

    public void UltraRage()
    {

    }
}
