using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System;
using System.Linq;
using UnityEngine.SceneManagement;

public class VoiceActivate : MonoBehaviour
{
    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();
    // Start is called before the first frame update
    void Start()
    {
        actions.Add("Insta", Insta);
        actions.Add("Stop", Stop);


        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray());
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();
    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech){
        Debug.Log(speech.text);
        actions[speech.text]();
    }

    private void Insta(){
        StartCoroutine(cameraDown());
    }

    private void Stop(){
        transform.Translate(10, 0, 0);
    }

    public IEnumerator cameraDown()
    {
        for (int i = 0; i < 50; i ++)
        {
            transform.Translate(new Vector3(-0.2f, 0, 0));
            yield return new WaitForSeconds(0.01f);
        }
        SceneManager.LoadScene("CameraView");
        transform.Translate(10, 0, 0);
    }
}
