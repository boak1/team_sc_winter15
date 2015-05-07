using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Music player for Pirate Mountain
/// 
/// TODO: test EVERYTHING
/// TODO: switching tracks works, but now looping doesn't
/// IN PROGRESS: figure out how to switch track and start playback when in the middle of previous track's clip
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class BgmPlayer : MonoBehaviour {

    public AudioClip[] bgmClips = new AudioClip[2];
    public float bgmTempo;
    public int numBeatsPerSegment;
    public float bgmStartDelayInSeconds = 0.0f;
    public string currentTrack;

    private Dictionary<string, AudioClip[]> trackList = new Dictionary<string, AudioClip[]>(); 
    private int index = 0;
    private int flip = 0;
    private double nextEventTime;
    private AudioSource[] audioSources = new AudioSource[2];
    private float volume = 1.0f;
    private bool running = false;
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

        //initialize nextEvenTime calculation settings to the first track to play
        currentTrack = "village";
        updateTrackSettings(currentTrack);

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

        if (time + 1.0f > nextEventTime)
        {
            audioSources[flip].clip = trackList[currentTrack][index];
            audioSources[flip].PlayScheduled(nextEventTime);

            if (!changeFlagOn)
            {
                updateTrackSettings(currentTrack);
                changeFlagOn = false;
            }

            nextEventTime += 60.0f / bgmTempo * numBeatsPerSegment;
            Debug.Log("Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);

            flip = 1 - flip;
        }
	}

    /* Methods for affecting currently playing Audio */
    
    //Resets audio volume and starts playback of new track immediately
    public void SwitchTrack (string trackName, bool fadeOut = false)
    {
        changeFlagOn = true;
        audioSources[1 - flip].Stop();
        index = -1;
        audioSources[0].volume = 1.0f;
        audioSources[1].volume = 1.0f;
        if (fadeOut)
        {
            //TODO: call FadeOut() somewhere in this class and calculate nextEventTime to account for fadeout time
        }
        
        updateTrackSettings(trackName, true);
        nextEventTime += 60.0f / bgmTempo * numBeatsPerSegment;
        //Debug.Log("delta nextEventTime = " + (60.0f / bgmTempo * numBeatsPerSegment));
        
        audioSources[flip].clip = trackList[trackName][index];
        audioSources[flip].Play();
        flip = 1 - flip;

        Debug.Log("SwitchTrack: Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);
    }

    /* TODO: make a generic BgmTrack class that has public vars for bgmTempo, 
       numBeatsPerSegment, and a public method for GetNextIndex */
    void updateTrackSettings (string trackName, bool playFromStart = false)
    {
        currentTrack = trackName;
        switch (trackName)
        {
            case "village":
                
                bgmTempo = 92.0f;
                numBeatsPerSegment = 32;
                index = GetNextIndexVillage(index);
                break;
            case "cave":
                bgmTempo = 16.0f;
                numBeatsPerSegment = 192;
                index = GetNextIndexCave(index, playFromStart);
                break;
            case "boss":
                bgmTempo = 254.0f;
                numBeatsPerSegment = 32;
                index = GetNextIndexBoss(index, playFromStart);
                break;
        }
    }

    void FadeOut ()
    {
        if (volume > 0.1f)
        {
            volume -= 0.1f * (float)AudioSettings.dspTime;
            audioSources[0].volume = volume;
            audioSources[1].volume = volume;
        }
    }

    /* Methods for controlling the order of clip playback */
    //TODO: turn these into a generic GetNextIndex() method inside a generic BgmTrack class

    //Village track only has 1 clip to loop
    int GetNextIndexVillage (int currentIndex)
    {
        return 0;
    }

    //Ice cave has 2 clips; loops 2nd clip
    int GetNextIndexCave(int currentIndex, bool playFromStart = false)
    {
        if (playFromStart)
        {
            return 0;
        }
        else
        {

        }
        return 1;
    }

    //Boss track has 8 clips; loops back to 2nd clip
    int GetNextIndexBoss(int currentIndex, bool playFromStart = false)
    {
        if (playFromStart)
        {
            return 0;
        }

        if (currentIndex + 1 == 8) 
        {
            return 1;
        } 
        else 
        {
            return currentIndex + 1;
        }
    }
}