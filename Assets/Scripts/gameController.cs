using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class gameController : MonoBehaviour
{
    public int jump;
    public string jumpcount;
    public int metros;
    public string metrosstring;
    public TMP_Text metrostext;
    public TMP_Text jumptext;
    public TMP_Text diveTime;
    public float timeValue = 0;
    public GameObject chegadaP;
    public GameObject chegadaP1;
    public bool canspawn = true;
    public bool endgame = false;

    public float velocitylock;

    public GameObject endscene;
    public bool cancount = true;

    public float reducemetro;
    

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ExampleCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        DiveTimer();
        DisplayTime();
        
        velocitylock = GameObject.Find("VelocityControll").GetComponent<Velocity>().actualvelocity;
        string metrosstring = metros.ToString();
        metrostext.text = string.Format("Metros: {0}", metrosstring);
        jump = GameObject.Find("Cube").GetComponent<Cube>().jump;
        string jumpcount = jump.ToString(); 
        jumptext.text = string.Format("Jump: {0}", jumpcount);

        if(jump >= 3 && canspawn == true && metros >= 100 && velocitylock > 0)
        {
            Instantiate(chegadaP, new Vector3(GameObject.Find("SpawnChegada").transform.position.x, GameObject.Find("SpawnChegada").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnChegada").transform);
            canspawn = false;
            endgame = true;
        }

        if(jump >= 3 && canspawn == true && metros >= 100 && velocitylock < 0)
        {
            Instantiate(chegadaP1, new Vector3(GameObject.Find("SpawnChegada1").transform.position.x, GameObject.Find("SpawnChegada1").transform.position.y -0, 0), Quaternion.identity, GameObject.Find("SpawnChegada1").transform);
            canspawn = false;
            endgame = true;
        }
        
    }

    IEnumerator ExampleCoroutine()
    {
        yield return new WaitForSeconds(reducemetro);
        metros += 1;
        StartCoroutine(ExampleCoroutine());
    }

    void DiveTimer()
    {
        
        timeValue += Time.deltaTime;
    }

    void DisplayTime()
    {

        float minutes = Mathf.FloorToInt(timeValue / 60);
        float seconds = Mathf.FloorToInt(timeValue - minutes * 60);

        diveTime.text = string.Format("TIME: {0:00}:{1:00}", minutes, seconds);

    }

    public void Reset() 
    {
        endscene.SetActive(true);
        Time.timeScale = 0;
        cancount = false;
    }
}
