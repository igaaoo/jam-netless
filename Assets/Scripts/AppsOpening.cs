using UnityEngine;


public class AppsOpening : MonoBehaviour
{
    public GameObject App1;
    public GameObject App2;

    private Animation appAnimation1;
    private Animation appAnimation2;
    void Start()
    {
        appAnimation1 = App1.GetComponent<Animation>();
        appAnimation2 = App2.GetComponent<Animation>();
    }

    public void OpenApp1(){
        appAnimation1.Play("Opening");
    }

    public void OpenApp2(){
        appAnimation2.Play("Opening");
    }


}
