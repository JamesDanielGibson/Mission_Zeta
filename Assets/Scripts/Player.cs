using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("In ms^-1")][SerializeField] float xSpeed = 10f;
    [Tooltip("In ms^-1")] [SerializeField] float ySpeed = 410;
    [Tooltip("In m")] [SerializeField] float xRange = 5;
    [Tooltip("In m")] [SerializeField] float yRange = 2;

    [SerializeField] float pitchfactor = 1;
    [SerializeField] float pitchControlFactor = -10;
    [SerializeField] float yawfactor = 1;
    [SerializeField] float yawControlFactor = 20;
    [SerializeField] float rollControlFactor = 25;
    [SerializeField] float distanceFromCamera = 5;
    float xThrow, yThrow;

    Vector3 startPos ;// this fixes a bug where the defualt for the rocket is in the top right corner.
    // Start is called before the first frame update
    void Start()
    {
       startPos = new Vector3(transform.localPosition.x, transform.localPosition.y, distanceFromCamera);
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    void OnCollision(Collision collision)
    {
        print("I hath collided");
    }
    void OnTrigger(Collider other)
    {
        print("I Hath Triggered");
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y*pitchfactor+yThrow*pitchControlFactor;// this piece of code takes the position of the craft and adds an extra amount that the craft should rotate beyong the normal movement to give extra shooting range.
        float yaw = transform.localPosition.y*yawfactor + xThrow*yawControlFactor;// this piece of code takes the position of the craft and adds an extra amount that the craft should rotate beyong the normal movement to give extra shooting range.
        float roll = transform.localPosition.x + xThrow * rollControlFactor;
        transform.localRotation = Quaternion.Euler(pitch,yaw,roll);//some wizardry-\(*_*)/-
    }

    private void ProcessTranslation()
    {
        MoveX();
        MoveY();
    }

    private void MoveX()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawNextXPos = transform.localPosition.x + xOffset;
        float xPos = Mathf.Clamp(rawNextXPos, -1 * (xRange ), (xRange ));// the strange offsets are for the bug that makes the rocket go to the right corner.
        transform.localPosition = new Vector3(xPos, transform.localPosition.y, startPos.z);
    }

    private void MoveY()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawNextYPos = transform.localPosition.y + yOffset;
        float yPos = Mathf.Clamp(rawNextYPos, -1 * (yRange), yRange);// the strange offsets are for the bug that makes the rocket go to the right corner.
        transform.localPosition = new Vector3(transform.localPosition.x, yPos, startPos.z);
    }
}
