using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseControl : MonoBehaviour
{
    //Tracks mouse position
    Vector3 mousePos;
    //Determines whether the player currently has control
    bool hasControl = true;

    private void Start()
    {
        print(Screen.width);
        print(Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        if (hasControl)
        {
            mousePos = Input.mousePosition;
        }
    }

    //Rotates player based on mouse position
    void FixedUpdate()
    {
        if (hasControl)
        {
            //Get the center of the screen
            Vector3 screenCenter;
            screenCenter.x = Screen.width / 2;
            screenCenter.y = Screen.height / 2;

            //Get the relative position
            float adjacent = mousePos.x - screenCenter.x;
            float opposite = mousePos.y - screenCenter.y;

            //Get the rotation
            Quaternion newRot = Quaternion.Euler(0.0f, 0.0f, Mathf.Atan2(opposite, adjacent)*Mathf.Rad2Deg - 90);
            transform.rotation = newRot;
        }
    }

    //Enables player rotation
    void enableControl()
    {
        hasControl = true;
    }

    //Disables player rotation
    void disableControl()
    {
        hasControl = false;
    }
}
