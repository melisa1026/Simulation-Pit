using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveAroundWithMouse : MonoBehaviour
{
private Vector3 cameraRotation;

    void Update()
    {
        cameraRotation = transform.eulerAngles;

        //turn left
        if(Input.mousePosition.x <= Screen.width *0.05)
        {
            transform.Rotate(0, -0.1f, 0, Space.Self);
        }
        // turn right
        else if(Input.mousePosition.x >= Screen.width * 0.95)
        {
            transform.Rotate(0, 0.1f, 0, Space.Self);
        }
        //turn down
        if(Input.mousePosition.y <= Screen.height *0.05)
        {
            transform.Rotate(0.1f, 0, 0, Space.Self);
        }
        // turn up
        else if(Input.mousePosition.y >= Screen.height * 0.95)
        {
            transform.Rotate(-0.1f, 0, 0, Space.Self);
        }
    }
}
