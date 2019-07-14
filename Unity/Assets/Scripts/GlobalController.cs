using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System;
using System.Text;
using System.IO;

public class GlobalController : SingletonBehaviour<GlobalController>
{
    [SerializeField] private VideoController videoController;
	[SerializeField] private string uploadFileUrl;
	[SerializeField] private string requestYoutubeInfoUrl;

	// Start is called before the first frame update
	void Start()
    {
	}

	// Update is called once per frame
	void Update()
    {
        
    }

    public void AppearVideo(string videoUrl, GameObject appearObject = null)
    {
        videoController.AppearVideoPlane(videoUrl, appearObject);
    }

    public string SaveImage(Texture2D image)
	{
		byte[] jpegData = image.EncodeToJPG();
		string uuid = Guid.NewGuid().ToString();
        string filePath = Path.Combine(Application.persistentDataPath, uuid + ".jpg");
		File.WriteAllBytes(filePath, jpegData);
		return filePath;
	}

    public void RecognizeImage(string imageFilePath, Action<string> OnRecognizedResult)
	{
		StartCoroutine(this.UploadFile(imageFilePath, OnRecognizedResult));
	}

    public void RequestVideoInfo(List<string> words, Action<string> OnRequestRsult)
	{
		StartCoroutine(this.RequestVideo(words, OnRequestRsult));
	}


	private IEnumerator RequestVideo(List<string> words, Action<string> OnRequestRsult)
	{
		WWWForm param = new WWWForm();
		param.AddField("words", string.Join(",", words.ToArray()));
		StringBuilder getUrl = new StringBuilder(requestYoutubeInfoUrl);
		if (param != null)
		{
			getUrl.Append("?");
			getUrl.Append(Encoding.UTF8.GetString(param.data));
		}
		UnityWebRequest request = UnityWebRequest.Get(getUrl.ToString());
		yield return request.Send();

		if (request.isNetworkError)
		{
			// GETに失敗した場合，エラーログを出力
			Debug.Log(request.error);
		}
		else
		{
			Debug.Log(request.downloadHandler.text);
			OnRequestRsult(request.downloadHandler.text);
		}
	}

	private IEnumerator UploadFile(string imageFilePath, Action<string> OnRecognizedResult)
    {
		string fileName = Path.GetFileName(imageFilePath);
		Debug.Log(fileName);
		byte[] img = File.ReadAllBytes(imageFilePath);
        // formにバイナリデータを追加
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", img, fileName, "image/jpeg");
        // HTTPリクエストを送る
        UnityWebRequest request = UnityWebRequest.Post(uploadFileUrl, form);
        yield return request.Send();

        if (request.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(request.error);
        }
        else
        {
			Debug.Log(request.downloadHandler.text);
			OnRecognizedResult(request.downloadHandler.text);
		}
    }
}
