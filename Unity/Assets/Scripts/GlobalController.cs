using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using System.IO;

public class GlobalController : SingletonBehaviour<GlobalController>
{
    [SerializeField] private VideoController videoController;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.UploadFile());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppearVideo(string videoUrl, GameObject appearObject = null)
    {
        videoController.AppearVideoPlane(videoUrl, appearObject);
    }

    IEnumerator UploadFile()
    {
		string fileName = "IMG_20190714_100544.jpg";
		string filePath = Path.Combine(Application.persistentDataPath , fileName);
        // 画像ファイルをbyte配列に格納
        byte[] img = File.ReadAllBytes(filePath);

        // formにバイナリデータを追加
        WWWForm form = new WWWForm();
        form.AddBinaryData("image", img, fileName, "image/jpeg");
        // HTTPリクエストを送る
        UnityWebRequest request = UnityWebRequest.Post("http://192.168.43.141:5000", form);
        yield return request.Send();

        if (request.isNetworkError)
        {
            // POSTに失敗した場合，エラーログを出力
            Debug.Log(request.error);
        }
        else
        {
            // POSTに成功した場合，レスポンスコードを出力
            Debug.Log(request.responseCode);
			Debug.Log(request.downloadHandler.text);
		}
    }
}
