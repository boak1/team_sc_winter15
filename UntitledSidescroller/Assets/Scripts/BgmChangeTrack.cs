using UnityEngine;
using System.Collections;

/// <summary>
/// Code by Vincent
/// Generic flag that changes music once flag enters camera view
/// with options for fading out the previous track.
/// </summary>

public class BgmChangeTrack : MonoBehaviour {

    public string newTrackName;
    public bool fadeOutPrevTrack;
    public float fadeOutLength = 0.0f;
    public float fadeOutStep = 0.01f;

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
                bgmPlayer.FadeAndSwitchTrack(newTrackName, fadeOutLength, fadeOutStep);
            }
            else
            {
                bgmPlayer.SwitchTrack(newTrackName);
            }
            becameVisibleAndTriggered = true;
        }
    }

    void OnBecameInvisible ()
    {
        becameVisibleAndTriggered = false;
    }

}
