using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenShotHandler : MonoBehaviour
{
     private static ScreenShotHandler instance;
    private Camera myCamera;
    private bool takeScreenShotOnNextFrame;

    private void Awake(){
        instance = this;
        myCamera = gameObject.GetComponent<Camera>();  
    }
    private IEnumerator onPostRender(){
         yield return new WaitForSeconds(5);
        if(takeScreenShotOnNextFrame){
            takeScreenShotOnNextFrame = false;
            RenderTexture renderTexture = myCamera.targetTexture;
            

            Texture2D renderResult = new Texture2D(renderTexture.width, renderTexture.height, TextureFormat.ARGB32, false);
            Rect rect = new Rect(0, 0, renderTexture.width, renderTexture.height);
            renderResult.ReadPixels(rect, 0, 0);

            byte[] byteArray = renderResult.EncodeToPNG();
            System.IO.File.WriteAllBytes(Application.dataPath + "/CameraScreenShot.png", byteArray);
            Debug.Log("Saved CameraScreenShot.png");

            RenderTexture.ReleaseTemporary(renderTexture);
            myCamera.targetTexture = null;
            


            Debug.Log("Done and go back to scene frontOfPlane");
            
            yield return new WaitForSeconds(5);
            SceneManager.LoadScene("frontOfPlane");

        }
    }
    private void takeScreenShot(int width, int height){
        myCamera.targetTexture = RenderTexture.GetTemporary(width, height, 16);
        takeScreenShotOnNextFrame = true;
        StartCoroutine(onPostRender());

    }
    public static void TakeScreenShot_Static(int width, int height) {
        instance.takeScreenShot(width, height);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           ScreenShotHandler.TakeScreenShot_Static(Screen.width + 500, Screen.height + 400);
           Debug.Log("Screen Height : " + Screen.height + "Width: " + Screen.width);
           Debug.Log("Took CameraScreenShot");
       
       
        
    }
}
