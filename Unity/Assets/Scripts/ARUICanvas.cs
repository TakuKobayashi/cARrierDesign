using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ARKitAndARCoreCommon;

public class ARUICanvas : MonoBehaviour
{
    private ARControllerBase activeARController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InputActiveARController(ARControllerBase arController)
    {
        activeARController = arController;
    }

    public void OnCaptureImage()
    {
		Debug.Log("capture");
		Debug.Log(activeARController);
		if (activeARController == null)
        {
            return;
        }
        Texture2D captureImage = activeARController.captureCurrentFrame();
		Debug.Log("captureImage");
		Debug.Log(captureImage);
		string filePath = GlobalController.Instance.SaveImage(captureImage);
		Debug.Log(filePath);
		GlobalController.Instance.RecognizeImage(filePath, (string result) =>
		{
			Debug.Log(result);
		});
	}
}
