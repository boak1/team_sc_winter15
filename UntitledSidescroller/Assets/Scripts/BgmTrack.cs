using UnityEngine;
using System.Collections;

public class BgmTrack : MonoBehaviour {

    public string name;
    public float tempo;
    public int numBeatsPerClip;
    public int startOfLoop;                             //Index of the clip to loop back to
    public AudioClip[] clipList = new AudioClip[2];     // You can change the size of the list in the Unity editor

    public int GetNextClipIndex(int currentIndex, bool playFromStart)
    {
        if (playFromStart)
        {
            return 0;
        }
        else if (currentIndex + 1 >= clipList.Length)
        {
            return startOfLoop;
        }
        else
        {
            return currentIndex + 1;
        }
    }
}
