using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularMovement : MonoBehaviour
{
    [SerializeField]
    Transform rotationCenter;

    [SerializeField]
    float rotationRadius = 2f, angularSpeed = 2f;

    [SerializeField]
    private float reverseWaitTime = 0.1f;

    private float currentReverseWaitTime = 0f;

    float posX, posY, angle = 0f;

    [SerializeField]
    bool reverse = false;
    // Start is called before the first frame update

    // Update is called once per frame


    void FixedUpdate()
    {
        currentReverseWaitTime -= Time.deltaTime;
        if (Input.GetMouseButton(0) && currentReverseWaitTime <= 0)
        {
            reverse = !reverse;
            currentReverseWaitTime = reverseWaitTime;
        }
        posX = rotationCenter.position.x + Mathf.Cos(angle) * rotationRadius ;
        posY = rotationCenter.position.y + Mathf.Sin(angle) * rotationRadius / 5;
        transform.position = new Vector2(posX, posY);
        if (reverse) {
            angle = angle - Time.deltaTime * angularSpeed;
        }
        else
        {
            angle = angle + Time.deltaTime * angularSpeed;
        }
        if (angle >= 360f)
        {
            angle = 0f;
        }
        else if(angle <= -360)
        {
            angle = 0f;
        }
        
    }
}
