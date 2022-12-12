using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platformMovement : MonoBehaviour
{
    public int heightdiff = 16;
    public float travelSpeed = 2f;
    private bool isMoving = false;
    private int moveDirection;
    private float currentPosition;
    public bool isUp = false;
    public bool isDown = true;
    
    

    void Update()
    {
        if (Input.GetKeyDown("v") && !isMoving)
        {
            move(1);
        }
        else if (Input.GetKeyDown("c") && !isMoving)
        {
            move(-1);
        }

        if (isMoving)
        {           
            if (moveDirection > 0)
            {
                if (transform.position.y < currentPosition + heightdiff && isDown)
                {
                    // transform.position = new Vector3(transform.position.x, transform.position.y + travelSpeed, transform.position.z);
                    transform.Translate(Vector3.up * travelSpeed * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                    isDown = false;
                    isUp = true;
                }
            }
            else
            {
                if (transform.position.y > currentPosition - heightdiff && isUp)
                {
                    transform.Translate(Vector3.up * (-travelSpeed) * Time.deltaTime);
                }
                else
                {
                    isMoving = false;
                    isDown = true;
                    isUp = false;
                }
            }            
        }
    }

    public void move(int direction)
    {
        currentPosition = transform.position.y;
        isMoving = true;
        moveDirection = direction;
    }
}
