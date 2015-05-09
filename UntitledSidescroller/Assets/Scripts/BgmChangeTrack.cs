using UnityEngine;
using System.Collections;

/// <summary>
/// Code by Vincent
/// Generic flag that changes music once flag enters camera view
/// </summary>

public class BgmChangeTrack : MonoBehaviour {
    private BgmPlayer bgmPlayer;
    private bool becameVisibleAndTriggered = false;
    public string trackName;
    
	// Use this for initialization
	void Start () {
        bgmPlayer = GameObject.Find("BgmPlayer").GetComponent<BgmPlayer>();
	}

    // For some reason, this method seems to be called more than once after flag enters camera view
    void OnBecameVisible ()
    {
        if (!becameVisibleAndTriggered)
        {
            bgmPlayer.SwitchTrack(trackName);
            becameVisibleAndTriggered = true;
        }
    }

    void OnBecameInvisible ()
    {
        becameVisibleAndTriggered = false;
    }
}
