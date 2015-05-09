using UnityEngine;
using System.Collections;

public class CagedPlatformButtonBehavior : MonoBehaviour {

    public GameObject platform;

    void OnDestroy()
    {
        Debug.Log("test");
        platform.GetComponent<CagedPlatformBehavior>().addCage();
    }
}
