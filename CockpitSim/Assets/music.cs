using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class music : MonoBehaviour
{

public AudioSource audioSrc;
public AudioClip airplanes, paperPlanes, theNights;
public Slider slide;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        // int current = 2;

        // if(cloud.cloudHorizontal == 1 && current != 1)
        // {
        //     audioSrc.clip = paperPlanes;
        //     audioSrc.Play();
        //     current = 1;
        // }
        // else if(cloud.cloudHorizontal == 2 && current != 2)
        // {
        //     audioSrc.clip = airplanes;
        //     audioSrc.Play();
        //     current = 2;
        // }
        // else if (cloud.cloudHorizontal == 3 && current != 3)
        // {
        //     audioSrc.clip = theNights;
        //     audioSrc.Play();
        //     current = 3;
        // }

        float volume = 1- (slide.value + 1)/2;
         audioSrc.volume = volume;
        
    }

    public void playAirplanes()
    {
            audioSrc.clip = airplanes;
            audioSrc.Play();
    }

    
    public void playPaperPlanes()
    {
            audioSrc.clip = paperPlanes;
            audioSrc.Play();
    }

    
    public void playtheNights()
    {
            audioSrc.clip = theNights;
            audioSrc.Play();
    }
}
