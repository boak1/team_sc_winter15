using UnityEngine;
using System.Collections;

public class PlatformDisappearBehavior : MonoBehaviour {
    //Written By Kevin W.
    public float disappearDelay;
    public bool reappearEnable;
    public float reappearDelay;
	public float stagger;
    private float timeElapsed = 0; 
    PlatformMapper platMap;
    

	// Use this for initialization
	void Start(){
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMapper>();
		timeElapsed -= stagger;
		}

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
        if (this.gameObject.CompareTag("Platform"))
            platMap.Remove(this.gameObject);
    }

    void Reappear()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        gameObject.SetActive(true);
        if (this.gameObject.CompareTag("Platform"))
            platMap.Add(this.gameObject);
    }

}
