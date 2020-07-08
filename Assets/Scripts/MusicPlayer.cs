using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour
{

   

    private void Awake() {
        int numofMusicPlayer = FindObjectsOfType<MusicPlayer>().Length;

        if (numofMusicPlayer > 1)
        {
            Destroy(this);
        } else {
            DontDestroyOnLoad(this);
        } 
    }

}
