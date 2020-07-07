using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHandler : MonoBehaviour
{

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Triggered by " + collider.gameObject.name);

        ParticleSystem explosion = transform.Find("Explosion").GetComponent<ParticleSystem>();
        explosion.Play();
        Debug.Log(explosion.name);
    }


}
