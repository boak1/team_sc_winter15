using UnityEngine;
using System.Collections;

public class CagedPlatformButtonBehavior : MonoBehaviour {

    public GameObject platform;

    public void toggleButton()
    {
        CagedPlatformBehavior platformScript = platform.GetComponent<CagedPlatformBehavior>();

        bool caged = platformScript.isCaged();
        if (caged)
            platformScript.removeCage();
        else
            platformScript.addCage();
    }
}
