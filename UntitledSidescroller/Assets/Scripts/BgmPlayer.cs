using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Music player for Pirate Mountain
/// 
/// TODO: create flag gameobjects in the scene to switch tracks at certain places
/// TODO: test EVERYTHING
/// TODO: figure out how to switch track and start playback when in the middle of previous track's clip
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class BgmPlayer : MonoBehaviour {

    public AudioClip[] bgmClips = new AudioClip[2];
    public float bgmTempo;
    public int numBeatsPerSegment;
    public float bgmStartDelayInSeconds = 0.0F;
    public string currentTrack;

    private Dictionary<string, AudioClip[]> trackList = new Dictionary<string, AudioClip[]>(); 
    private int index = 0;
    private int flip = 0;
    private double nextEventTime;
    private AudioSource[] audioSources = new AudioSource[2];
    private float volume = 1.0f;
    private bool running = false;

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("BgmPlayerChild");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent<AudioSource>() as AudioSource;
        }

        currentTrack = "village";
        bgmTempo = 92.0f;
        numBeatsPerSegment = 32;

        //initialize trackList dictionary for Pirate Mountain (is there an easier way to do array slices?)
        trackList.Add("village", new AudioClip[1] {bgmClips[0]});
        trackList.Add("cave", new AudioClip[2] {bgmClips[1], bgmClips[2]});
        trackList.Add("boss", new AudioClip[8] {bgmClips[3], bgmClips[4], bgmClips[5], bgmClips[6], 
                                                bgmClips[7], bgmClips[8], bgmClips[9], bgmClips[10]});
        
        nextEventTime = AudioSettings.dspTime + bgmStartDelayInSeconds;
        running = true;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!running)
        {
            return;
        }

        	double time = AudioSettings.dspTime;

        if (time + 1.0F > nextEventTime)
        {
            audioSources[flip].clip = trackList[currentTrack][index];
            audioSources[flip].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);
            nextEventTime += 60.0F / bgmTempo * numBeatsPerSegment;

            if (currentTrack == "village") {
                bgmTempo = 92.0f;
                numBeatsPerSegment = 32;
                index = GetNextIndexVillage(index);
            } else if (currentTrack == "cave") {
                bgmTempo = 160.0f;
                numBeatsPerSegment = 192;
                index = GetNextIndexCave(index);
            } else if (currentTrack == "boss") {
                bgmTempo = 254.0f;
                numBeatsPerSegment = 32;
                index = GetNextIndexBoss(index);
            }

            flip = 1 - flip;

        }
	}


    /* Methods for affecting currently playing Audio */
    
    //Resets audio volume and changes currentTrack.
    //TODO: reset nextEventTime so that new track playback starts immediately
    public void SwitchTrack (string trackName)
    {
        currentTrack = trackName;
        audioSources[0].volume = 1.0f;
        audioSources[1].volume = 1.0f;
    }

    public void FadeOut()
    {
        if (volume > 0.1f)
        {
            volume -= 0.1f * (float)AudioSettings.dspTime;
            audioSources[0].volume = volume;
            audioSources[1].volume = volume;
        }
    }

    /* Methods for controlling the order of clip playback */

    //Village track only has 1 clip to loop
    int GetNextIndexVillage (int currentIndex)
    {
        return 0;
    }

    //Ice cave has 2 clips; loops 2nd clip
    int GetNextIndexCave(int currentIndex)
    {
        return 1;
    }

    //Boss track has 8 clips; loops back to 2nd clip
    int GetNextIndexBoss(int currentIndex)
    {
        if (currentIndex + 1 == 8) {
            return 1;
        } else {
            return currentIndex + 1;
        }
    }
}