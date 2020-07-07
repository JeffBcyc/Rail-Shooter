using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("LoadMenuScene", 2f);
    }

    private void LoadMenuScene()
    {
        SceneManager.LoadScene(0);
    }

}
