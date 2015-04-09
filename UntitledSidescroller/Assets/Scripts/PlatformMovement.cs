using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour
{
    /// <summary>
    /// :platMap:  Import PlatformMapper as platMap to grab the platformList and the Add() and Remove() methods
    /// </summary>
    PlatformMapper platMap;

    void Start()
    {
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMapper>();
    }


    /// <summary>
    /// :Visible & Invisible:  ADDs or REMOVEs the platform to the platformList when this platform ENTERS or EXITS the Camera view
    ///                        -  !!!CAUTION!!!  THIS WILL NOT WORK IN THE EDITOR IF THE SCENE VIEW HAS EYES ON THE PLATFORM
    /// </summary>
    void OnBecameVisible()
    {
        platMap.Add(this.gameObject);
    }
    void OnBecameInvisible()
    {
        this.GetComponent<PlatformProperties>().setTeleportable(false);
    }
}

//public class PlatformMovement : MonoBehaviour {
//    /// <summary>
//    /// :platMap:  Import PlatformMapper as platMap to grab the platformList and the Add() and Remove() methods
//    /// </summary>
//    PlatformMapper platMap;

//    void Start()
//    {
//        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMapper>();
//    }


//    /// <summary>
//    /// :Visible & Invisible:  ADDs or REMOVEs the platform to the platformList when this platform ENTERS or EXITS the Camera view
//    ///                        -  !!!CAUTION!!!  THIS WILL NOT WORK IN THE EDITOR IF THE SCENE VIEW HAS EYES ON THE PLATFORM
//    /// </summary>
//    void OnBecameVisible()
//    {
//        platMap.Add(this.gameObject);        
//    }
//    void OnBecameInvisible()
//    {
//        platMap.Remove(this.gameObject);
//    }
//}