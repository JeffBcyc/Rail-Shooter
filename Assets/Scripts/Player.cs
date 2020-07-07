using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;


public class Player : MonoBehaviour
{

    [Tooltip("at what speed the ship is moving on the x axis: unit in ms^-1")] [SerializeField] float speed = 30f;
    [Tooltip("in m")] [SerializeField] float xrange = 18f;
    [Tooltip("in m")] [SerializeField] float yrange = 11f;

    [SerializeField] float positionPitchFactor = -1f;
    [SerializeField] float controlPitchFactor = 20f;

    [SerializeField] float positionYawFactor = 1.5f;
    [SerializeField] float rowControlFactor = -20f;

    float xThrow, yThrow;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch, yaw, row;

        float pitchDueToPosition = positionPitchFactor * transform.localPosition.y;
        float pitchDueToControl = controlPitchFactor * yThrow;
        pitch = pitchDueToControl + pitchDueToPosition;

        float yawDueToPosition = positionYawFactor * transform.localPosition.x;
        float rowDueToControl = rowControlFactor * xThrow;

        yaw = yawDueToPosition;
        row = rowDueToControl;
        transform.localRotation = Quaternion.Euler(pitch, yaw, row);
    }

    private void ProcessTranslation()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        // xThrow is the throw vector (with acceleration), xSpeed is the desired movement speed
        // xOffset is the movement of the ship on screen independent of the framerate (by multiplying Time.deltatime)
        float xOffset = xThrow * speed * Time.deltaTime;
        float yOffset = yThrow * speed * Time.deltaTime;
        float clampedXPos = Mathf.Clamp(transform.localPosition.x + xOffset, -xrange, xrange);
        float clampedYPos = Mathf.Clamp(transform.localPosition.y + yOffset, -yrange, yrange);

        transform.localPosition = new Vector3(clampedXPos, transform.localPosition.y, transform.localPosition.z);
        transform.localPosition = new Vector3(transform.localPosition.x, clampedYPos, transform.localPosition.z);
    }

    private void OnTriggerEnter(Collider collider)
    {
        Debug.Log("Triggered by " + collider.gameObject.name);

        ParticleSystem explosion = transform.Find("Explosion").GetComponent<ParticleSystem>();
        explosion.Play();
        Debug.Log(explosion.name);
    }


}
