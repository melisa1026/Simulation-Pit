using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cloud : MonoBehaviour
{
    private static int cloudHorizontal = 2; // 1: left, 2: straight, 3: right
    public Slider mySlider;

    void Update()
    {
        // horizontal cloud direction
        if(cloudHorizontal == 1)
        {
            transform.Translate(1f, 0, 0);
            if(transform.localPosition.x > 500f)
                transform.localPosition = new Vector3(-500, transform.localPosition.y, transform.localPosition.z);
        }
        else if(cloudHorizontal == 3)
        {
            transform.Translate(-1f, 0, 0);
            if(transform.localPosition.x < -500f)
                transform.localPosition = new Vector3(500, transform.localPosition.y, transform.localPosition.z);
        }

        // vertical cloud position
        if(mySlider != null)
        {
            transform.Translate(0, mySlider.value * 3, 0);

            if(mySlider.value > 0 && transform.localPosition.y > 110)
                transform.localPosition = new Vector3(transform.localPosition.x, -110,  transform.localPosition.z);
            if(mySlider.value < 0 && transform.localPosition.y < -110)
                transform.localPosition = new Vector3(transform.localPosition.x, 110, transform.localPosition.z);
        }
    }

    public static void setCloudHorizontal(int side)
    {
        cloudHorizontal = side;
    }

}
