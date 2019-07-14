using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using ARKitAndARCoreCommon;
using Newtonsoft.Json;

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
		if (activeARController == null)
        {
            return;
        }
        //      Texture2D captureImage = activeARController.captureCurrentFrame();
        //		string filePath = GlobalController.Instance.SaveImage(captureImage);
        Vector3 cameraPos = Camera.main.transform.position;
        cameraPos.z = cameraPos.z - 1.0f;
        GameObject anchorObject = activeARController.createAnchor(cameraPos, Quaternion.identity);

        string filePath = Path.Combine(Application.persistentDataPath, "IMG_20190714_100544.jpg");
		Debug.Log(filePath);
		GlobalController.Instance.RecognizeImage(filePath, (string result) =>
		{
			Debug.Log(result);
            RecognizedResult recognizedResult = JsonConvert.DeserializeObject<RecognizedResult>(result);
            GlobalController.Instance.RequestVideoInfo(recognizedResult.result, (string videoInfo) =>
            {
                List<VideoInfo> videoInfos = JsonConvert.DeserializeObject<List<VideoInfo>>(videoInfo);
                GlobalController.Instance.AppearVideo(videoInfos[0].formats[0].url, anchorObject);
            });

        });
	}
}
