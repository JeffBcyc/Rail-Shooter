﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject enemyDeathFX = null;
    [SerializeField] Transform parent = null;
    [SerializeField] int scorePerHit = 100;
    [SerializeField] int enemyShipHP = 13;


    ScoreBoard scoreBoard = null;

    void Start()
    {
        addNonTriggerBoxCollider();
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    private void addNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>() ;
        enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        print("Enemy Ship hit");
        enemyShipHP--;

        if (enemyShipHP <= 0)
        {
            GameObject fx = Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
            fx.transform.parent = parent;
            scoreBoard.ScoreHit(scorePerHit);
            Destroy(gameObject);
        } 
        
    }

}
