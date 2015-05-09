using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Code by Vincent
/// Generic music player for levels 
/// Uses BgmTrack objects
/// 
/// TODO: make fade out work
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class BgmPlayer : MonoBehaviour {

    public float bgmStartDelayInSeconds = 0.0f;
    public string firstTrack;
    public BgmTrack[] trackList = new BgmTrack[1];  // You can change the size of this list in the Unity editor

    private BgmTrack currentTrack;
    private Dictionary<string, BgmTrack> trackDict = new Dictionary<string, BgmTrack>(); 
    private int index;
    private int flip = 0;
    private double nextEventTime;
    private AudioSource[] audioSources = new AudioSource[2];
    private float volume = 1.0f;
    private bool changeFlagOn = false;      

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("BgmPlayerChild");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>() as AudioSource;
        }

        // Add key-value pairs for each track in trackList to be able to refer to them by name (string)
        foreach (BgmTrack track in trackList) {
            trackDict.Add(track.name, track);
        }

        currentTrack = trackDict[firstTrack];
        index = currentTrack.GetNextClipIndex(index, true); 

        nextEventTime = AudioSettings.dspTime + bgmStartDelayInSeconds;
	}
	
	// Update is called once per frame
	void Update () 
    {
        	double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            audioSources[flip].clip = currentTrack.clipList[index];
            audioSources[flip].PlayScheduled(nextEventTime);

            //prevent Update from interfering while SwitchTrack is executing; possibly redundant
            if (!changeFlagOn)
            {
                index = currentTrack.GetNextClipIndex(index);
            }

            nextEventTime += 60.0f / currentTrack.tempo * currentTrack.numBeatsPerClip;
            // Debug.Log("Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);

            flip = 1 - flip;
        }
	}
    
/* ------------------------------------------------------------------ */

    // Resets audio volume and starts playback of new track immediately
    // Called by BgmChangeTrack objects
    public void SwitchTrack (string trackName)
    {
        changeFlagOn = true;

        audioSources[1 - flip].Stop();

        volume = 1.0f;
        audioSources[0].volume = volume;
        audioSources[1].volume = volume;

        currentTrack = trackDict[trackName];
        // Debug.Log("Changed track to " + currentTrack.name);
        index = currentTrack.GetNextClipIndex(index, true);
        nextEventTime += 60.0f / currentTrack.tempo * currentTrack.numBeatsPerClip;
        
        audioSources[flip].clip = currentTrack.clipList[index];
        audioSources[flip].Play();  //play new track immediately
        flip = 1 - flip;

        Debug.Log("SwitchTrack: Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);
        changeFlagOn = false;
    }

    // Decreases volume of both audioSources by 0.1 every call until volume equals 0.0
    // Called by BgmFadeOutFlag objects
    // TODO: figure out how to integrate this alongside Update() (maybe use concurrency?)
    public void FadeOut (float speed)
    {
        if (volume > 0.0f)
        {
            volume -= 0.1f; // *(float)AudioSettings.dspTime * speed;
            audioSources[0].volume = volume;
            audioSources[1].volume = volume;
        }
    }

}