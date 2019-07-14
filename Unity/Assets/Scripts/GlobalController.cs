using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : SingletonBehaviour<GlobalController>
{
    [SerializeField] private VideoController videoController;

    // Start is called before the first frame update
    void Start()
    {
        this.AppearVideo("https://r4---sn-3pm76n7r.googlevideo.com/videoplayback?expire=1563091841&ei=IY8qXd2ZD9KZs8IP2Ka78AQ&ip=153.246.168.76&id=o-AEjWxokTmCb-KplgySS09wjHhPscTReOWDKUKdLNfkM2&itag=22&source=youtube&requiressl=yes&mm=31%2C29&mn=sn-3pm76n7r%2Csn-3pm7sn76&ms=au%2Crdu&mv=m&mvi=3&pl=19&initcwndbps=1402500&mime=video%2Fmp4&ratebypass=yes&dur=140.759&lmt=1556630365107148&mt=1563070183&fvip=5&c=WEB&txp=5535432&sparams=expire%2Cei%2Cip%2Cid%2Citag%2Csource%2Crequiressl%2Cmime%2Cratebypass%2Cdur%2Clmt&sig=ALgxI2wwRAIgDUuqOaTexBsTLxjUre1z9ob4ymhpI45COdxjD2y7YSsCICBeqpvuVNJWka5smPd-OT3lN-QIgsh3JRrGtw2WdABE&lsparams=mm%2Cmn%2Cms%2Cmv%2Cmvi%2Cpl%2Cinitcwndbps&lsig=AHylml4wRQIhANKE6QSjLbvrGFuDy_2FlYVaLPlzyZYjOmisuUM6m3QEAiA0pLrROM-WAOzalsX08RnnqisVR8BPkvhk2Jalttynjw%3D%3D");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AppearVideo(string videoUrl, GameObject appearObject = null)
    {
        videoController.AppearVideoPlane(videoUrl, appearObject);
    }
}
