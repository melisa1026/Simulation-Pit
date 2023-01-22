using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;

public class VoiceActivate : MonoBehaviour
{

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Hello", Hello);
        actions.Add("Stop", Stop);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text]();
    }

    private void Hello(){
        Vector3 rotationPoint = transform.position + new Vector3(0, 0, 1); // top point of the object
        transform.RotateAround(rotationPoint, new Vector3(0, 0, 1), 45); // rotate 45 degrees around the right axis
    }

    private void Stop(){
        transform.Translate(-1, 0, 0);
    }
}
