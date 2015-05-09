using UnityEngine;
using System.Collections;

public class PlatformDisappearBehavior : MonoBehaviour {
    //Written By Kevin W.
    public float disappearDelay;
    public bool reappearEnable;
    public float reappearDelay;

    private float timeElapsed = 0;

	// Use this for initialization
	void Update () 
    {
        fadeOut();
	}

    void fadeOut()
    {
        timeElapsed += Time.deltaTime;
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f - timeElapsed / disappearDelay);

        if (timeElapsed >= disappearDelay)
            Disappear();
    }

    void Disappear()
    {
        timeElapsed = 0;
        if (reappearEnable)
            Invoke("Reappear", reappearDelay);
        gameObject.SetActive(false);
    }

    void Reappear()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        gameObject.SetActive(true);
    }

}
