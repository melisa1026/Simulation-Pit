using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cloud : MonoBehaviour
{
    private static int cloudHorizontal = 2; // 1: left, 2: straight, 3: right
    public Slider mySlider;
    public Sprite rudderLeft, rudderRight, rudderNormal, flapUp, flapDown, flapNormal;
    public Image rudderRend, flapRend;

    void Update()
    {
        // horizontal cloud direction
        if(cloudHorizontal == 1)
        {
            transform.Translate(1f, 0, 0);
            if(transform.localPosition.x > 500f)
                transform.localPosition = new Vector3(-500, transform.localPosition.y, transform.localPosition.z);
            if(rudderRend != null)
                rudderRend.sprite = rudderLeft;
        }
        else if(cloudHorizontal == 3)
        {
            transform.Translate(-1f, 0, 0);
            if(transform.localPosition.x < -500f)
                transform.localPosition = new Vector3(500, transform.localPosition.y, transform.localPosition.z);
            if(rudderRend != null)
                rudderRend.sprite = rudderRight;
        }
        else
        {
            if(rudderRend != null)
                rudderRend.sprite = rudderNormal;
        }


        // vertical cloud position
        if(mySlider != null)
        {
            transform.Translate(0, mySlider.value * 3, 0);

            if(mySlider.value > 0.5f && transform.localPosition.y > 110)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, -110,  transform.localPosition.z);
                if(flapRend != null)
                    flapRend.sprite = flapUp;
            }
            else if(mySlider.value < -0.5f && transform.localPosition.y < -110)
            {
                transform.localPosition = new Vector3(transform.localPosition.x, 110, transform.localPosition.z);
                if(flapRend != null)
                    flapRend.sprite = flapDown;
            }
            else if(mySlider.value > -0.5f && mySlider.value < 0.5f)
            {
                if(flapRend != null)
                    flapRend.sprite = flapNormal;
            }
        }
    }

    public static void setCloudHorizontal(int side)
    {
        cloudHorizontal = side;
    }

}
