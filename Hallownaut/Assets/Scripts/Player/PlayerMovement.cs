using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Determines the movement speed
    public float moveSpeed = 1f;

    //Determines whether the player currently has control
    bool hasControl = true;
    //USed to change position
    float newX = 0f;
    float newY = 0f;
    Rigidbody2D rb;

    //Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    //Update is called once per frame
    void Update()
    {
        //If has control, record indicated movement
        if (hasControl)
        {
            newX = Input.GetAxis("Horizontal");
            newY = Input.GetAxis("Vertical");
        }
    }

    //Updates physics component
    void FixedUpdate()
    {
        Vector2 new_position = rb.position;
        new_position.x += newX * Time.fixedDeltaTime * moveSpeed;
        new_position.y += newY * Time.fixedDeltaTime * moveSpeed;
        rb.position = new_position;
        newX = newY = 0f;
    }

    //Enables player movement
    void enableMovement()
    {
        hasControl = true;
    }

    //Disables player movement
    void disableMovement()
    {
        hasControl = false;
    }
}
