using UnityEngine;
using System.Collections;

public class BgmChangeFlag : MonoBehaviour {
    private BgmPlayer bgmPlayer;
    private bool becameVisibleAndTriggered = false;
    public string trackName;
    
	// Use this for initialization
	void Start () {
        bgmPlayer = GameObject.Find("BgmPlayer").GetComponent<BgmPlayer>();
	}

    //for some reason, this method seems to be called more than once after flag enters camera view
    void OnBecameVisible ()
    {
        if (!becameVisibleAndTriggered)
        {
            //Debug.Log("called SwitchTrack()");
            bgmPlayer.SwitchTrack(trackName);
            becameVisibleAndTriggered = true;
        }
    }

    void OnBecameInvisible ()
    {
        becameVisibleAndTriggered = false;
    }
}
