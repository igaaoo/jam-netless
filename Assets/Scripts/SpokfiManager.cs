using UnityEngine;

public class SpokfiManager : MonoBehaviour
{
    bool enable = false;

    public GameObject spokfiPanel;

    private Animation spokfiAnimations;

    void Start(){
        spokfiAnimations = spokfiPanel.GetComponent<Animation>();
    }
    public void SpokfiInteract(){
        if( enable == false){
            enable = true;
            spokfiAnimations.Play("Spokfi");

        } else {
            spokfiAnimations.Play("SpokfiClose");
            enable = false;
        }

    }
}
