using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SummonPanel : MonoBehaviour
{
    public GameObject thepanel;
    

    public void EnablePanel() {
        thepanel.SetActive(true);
    }
    public void DisablePanel() {
        thepanel.SetActive(false);
    }

    public void ChangeScene(string sceneName) {// declares string so we can type in the name of the scene later on
        SceneManager.LoadScene(sceneName); //changes scene to the string we typed
    }

}
