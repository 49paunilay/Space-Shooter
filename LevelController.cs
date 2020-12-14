using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    public void backtomainMenu(){
        SceneManager.LoadScene(0);
    }
    public void Game(){
        SceneManager.LoadScene(2);
    }
    public void About(){
        SceneManager.LoadScene(1);
    }

}
