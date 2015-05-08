using UnityEngine;
using System.Collections;

public class PlatformDisappearBehavior : MonoBehaviour {
    //Written By Kevin W.
    public float disappearDelay;
    public bool reappear;
    public float reappearDelay;


	// Use this for initialization
	void Start () 
    {
        Invoke("Disappear", disappearDelay);
	}

    void Disappear()
    {
        gameObject.SetActive(false);
        if (reappear)
            Invoke("Reappear", reappearDelay);
    }

    void Reappear()
    {
        gameObject.SetActive(true);
        Invoke("Disappear", disappearDelay);
    }

}
