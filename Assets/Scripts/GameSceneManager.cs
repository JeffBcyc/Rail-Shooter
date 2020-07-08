using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Invoke("Menu", 2f);
        }
    }

    private void Menu()
    {
        SceneManager.LoadScene(1);
    }

    public void Game()
    {
        SceneManager.LoadScene(2);
    }


}
