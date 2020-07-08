using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ColliderHandler : MonoBehaviour
{

    [SerializeField] GameObject deathFX = null;

    private void Start()
    {
        deathFX.SetActive(false);
    }

    private void OnTriggerEnter(Collider collider)
    {
        InitiateDeathSequence();
    }

    private void InitiateDeathSequence()
    {
        Debug.Log("Hit something, triggered death sequence");
        deathFX.SetActive(true);
        //SendMessage("DisableController");
        //Invoke("ResetGame", 2f);
    }

    void ResetGame()
    {
        SceneManager.LoadScene(2);
    }


}
