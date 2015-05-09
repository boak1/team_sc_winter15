using UnityEngine;
using System.Collections.Generic;

/// <summary>
/// Music player for Pirate Mountain
/// 
/// TODO: test EVERYTHING
/// TODO: make fade out work
/// TODO: refactor this so that it doesn't require hardcoded track information
/// </summary>

[RequireComponent(typeof(AudioSource))]
public class BgmPlayerModular : MonoBehaviour {

    public AudioClip[] bgmClips = new AudioClip[2];
    public float bgmStartDelayInSeconds = 0.0f;
    public string firstTrack;

    private float bgmTempo;
    private int numBeatsPerSegment;
    private string currentTrack;     
    private Dictionary<string, AudioClip[]> trackList = new Dictionary<string, AudioClip[]>(); 
    private int index = 0;
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

        //initialize nextEvenTime calculation params to firstTrack's
        currentTrack = firstTrack;
        UpdateTrackSettings(currentTrack, true);

        //initialize trackList dictionary for Pirate Mountain (is there an easier way to do array slices?)
        //this is where generic BgmTrack objects would be instantiated and initialized
        trackList.Add("village", new AudioClip[1] {bgmClips[0]});
        trackList.Add("cave", new AudioClip[2] {bgmClips[1], bgmClips[2]});
        trackList.Add("boss", new AudioClip[8] {bgmClips[3], bgmClips[4], bgmClips[5], bgmClips[6], 
                                                bgmClips[7], bgmClips[8], bgmClips[9], bgmClips[10]});
        
        nextEventTime = AudioSettings.dspTime + bgmStartDelayInSeconds;
	}
	
	// Update is called once per frame
	void Update () 
    {
        	double time = AudioSettings.dspTime;

        if (time + 1.0f > nextEventTime)
        {
            audioSources[flip].clip = trackList[currentTrack][index];
            audioSources[flip].PlayScheduled(nextEventTime);

            //prevent Update() from interfering while SwitchTrack() is executing; might be redundant
            if (!changeFlagOn)
            {
                UpdateTrackSettings(currentTrack);
            }



            nextEventTime += 60.0f / bgmTempo * numBeatsPerSegment;
            Debug.Log("Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);

            flip = 1 - flip;
        }
	}
    
    /*-----------------------------------------------*/
    /* Methods for affecting currently playing Audio */
    

    //Resets audio volume and starts playback of new track immediately
    public void SwitchTrack (string trackName)
    {
        changeFlagOn = true;

        audioSources[1 - flip].Stop();

        volume = 1.0f;
        audioSources[0].volume = volume;
        audioSources[1].volume = volume;
        
        UpdateTrackSettings(trackName, true);
        nextEventTime += 60.0f / bgmTempo * numBeatsPerSegment;
        
        audioSources[flip].clip = trackList[trackName][index];
        audioSources[flip].Play();  //play new track immediately
        flip = 1 - flip;

        Debug.Log("SwitchTrack: Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);
        changeFlagOn = false;
    }


    /* TODO: make a generic BgmTrack class that has public vars for bgmTempo, 
       numBeatsPerSegment, and a public method for GetNextIndex, and possibly an array of clips */
    void UpdateTrackSettings (string trackName, bool playFromStart = false)
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
                bgmTempo = 160.0f;
                numBeatsPerSegment = 192;
                index = GetNextIndexCave(index, playFromStart);
                break;
            case "boss":
                bgmTempo = 170.3f;    
                numBeatsPerSegment = 32;
                index = GetNextIndexBoss(index, playFromStart);
                break;
        }
    }

    //Decreases volume of both audioSources by 0.1 every call until volume equals 0.1
    //Returns true if the volume was decreased and false if the volume is already 0.1
    public bool FadeOut ()
    {
        if (volume > 0.1f)
        {
            volume -= 0.1f * (float)AudioSettings.dspTime;
            audioSources[0].volume = volume;
            audioSources[1].volume = volume;
            return true;
        }
        return false;
    }

    /*----------------------------------------------------*/
    /* Methods for controlling the order of clip playback */
    //TODO: turn these methods into a generic GetNextIndex() method inside generic BgmTrack class


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
        return 1 - currentIndex;
    }


    //Boss track has 8 clips; loops back to 2nd clip
    int GetNextIndexBoss(int currentIndex, bool playFromStart = false)
    {
        if (playFromStart)
        {
            return 0;
        }

        if (currentIndex + 1 > 7) 
        {
            return 1;
        } 
        else 
        {
            return currentIndex + 1;
        }
    }
}