using OneSignalSDK;
using UnityEngine;

public class OneSignalInitializer : MonoBehaviour
{
    private void Start() => OneSignal.Default.Initialize("8852b064-3043-4c44-a818-93b03df23958");
}
