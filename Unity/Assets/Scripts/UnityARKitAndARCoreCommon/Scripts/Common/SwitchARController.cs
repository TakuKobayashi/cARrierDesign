namespace ARKitAndARCoreCommon
{
    using UnityEngine;

    public class SwitchARController : MonoBehaviour
    {
        [SerializeField] private GameObject arkitController;
        [SerializeField] private GameObject arcoreController;
        [SerializeField] private ARUICanvas aruiCanvas;

        private void Awake()
        {
#if UNITY_IOS
            ARKitController arkitController = Util.InstantiateTo<ARKitController>(this.gameObject, arkitController);
            aruiCanvas.InputActiveARController(arkitController);
#elif UNITY_ANDROID
            ARCoreController arcoreC = Util.InstantiateTo<ARCoreController>(this.gameObject, arcoreController);
            aruiCanvas.InputActiveARController(arcoreC);
#endif
        }
    }
}