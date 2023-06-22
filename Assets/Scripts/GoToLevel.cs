using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToLevel : MonoBehaviour
{

 
    public void GoToLevelOne(){
        SceneManager.LoadScene("Level01");
    }

    public void ExitGame(){
        Application.Quit();
    }

    public void GoToMainMenu(){
        SceneManager.LoadScene("MainMenu/MainMenu");
    }
}
