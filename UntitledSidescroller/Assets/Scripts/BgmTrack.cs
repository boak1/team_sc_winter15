using UnityEngine;
using System.Collections;

/// <summary>
/// Code by Vincent
/// Generic class for music tracks
/// </summary>

public class BgmTrack : MonoBehaviour {

    public string trackName;
    public float tempo;
    public int numBeatsPerClip;
    public int startOfLoop = 0;                         // Index of the clip to loop back to once the last clip has finished
    public AudioClip[] clipList = new AudioClip[2];     // You can change the size of this list in the Unity editor

    public int GetNextClipIndex(int currentIndex, bool playFromStart = false)
    {
        if (playFromStart)
        {
            return 0;
        }
        else if (currentIndex + 1 == clipList.Length)
        {
            return startOfLoop;
        }
        else
        {
            return currentIndex + 1;
        }
    }

}
