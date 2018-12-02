using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameBtnScript : MonoBehaviour {

    public void StartGame()
    {
        SceneManager.LoadScene(0, LoadSceneMode.Single);
    }
}
