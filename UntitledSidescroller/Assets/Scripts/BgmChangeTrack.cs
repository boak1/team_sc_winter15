using UnityEngine;
using System.Collections;

/// <summary>
/// Code by Vincent
/// Generic flag that changes music once flag enters camera view
/// </summary>

public class BgmChangeTrack : MonoBehaviour {

    public string trackName;
    public bool fadeOutPrevTrack;
    public float fadeOutStep = 0.0f;
    public float fadeOutSpeed = 0.0f;

    private BgmPlayer bgmPlayer;
    private bool becameVisibleAndTriggered = false;
    
	// Use this for initialization
	void Start () {
        bgmPlayer = GameObject.Find("BgmPlayer").GetComponent<BgmPlayer>();
	}

    // For some reason, this method seems to be called more than once after flag enters camera view
    void OnBecameVisible ()
    {
        if (!becameVisibleAndTriggered)
        {
            if (fadeOutPrevTrack)
            {
                bgmPlayer.FadeAndSwitchTrack(trackName, fadeOutStep, fadeOutSpeed);
            }
            else
            {
                bgmPlayer.SwitchTrack(trackName);
            }
            becameVisibleAndTriggered = true;
        }
    }

    void OnBecameInvisible ()
    {
        becameVisibleAndTriggered = false;
    }

}
