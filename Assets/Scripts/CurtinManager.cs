using UnityEngine;
using UnityEngine.SceneManagement;

public class CurtinManager : MonoBehaviour
{
 
    public void Restart(){
         Application.LoadLevel(Application.loadedLevel);
    }

    public void Quit(){
        Application.Quit();
        Debug.Log("Quit");
    }

    public void LoadGodzilla(){
        Application.LoadLevel("Giroflex");
    }

    public void LoadKhromge(){
        Application.LoadLevel("Khromge");
    }

    public void LoadMenu(){
        Application.LoadLevel("MenuPos");
    }

}
