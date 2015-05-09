using UnityEngine;
using System.Collections;

public class EnemyBecomesPlatformOnDeathBehavior : MonoBehaviour {

    public GameObject platform;

    void OnDestroy()
    {
        Instantiate(platform, transform.position, Quaternion.identity);
    }
}
