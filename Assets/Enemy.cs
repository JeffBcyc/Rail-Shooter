using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] GameObject enemyDeathFX;

    void Start()
    {
        addNonTriggerBoxCollider();
        

    }

    private void addNonTriggerBoxCollider()
    {
        Collider enemyBoxCollider = gameObject.AddComponent<BoxCollider>() ;
        enemyBoxCollider.isTrigger = false;
    }

    void OnParticleCollision(GameObject other)
    {
        print("Enemy Ship hit");
        Instantiate(enemyDeathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

}
