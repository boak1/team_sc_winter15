using UnityEngine;
using System.Collections;
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
    private bool fadeOutFlagOn = false;
    private bool waitActive = false;

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

            // Prevent Update from interfering while SwitchTrack is executing; possibly redundant
            if (!changeFlagOn)
            {
                index = currentTrack.GetNextClipIndex(index);
            }

            nextEventTime += 60.0f / currentTrack.tempo * currentTrack.numBeatsPerClip;

            flip = 1 - flip;
        }
	}
    
    /* ------------------------------------------------------------------ */

    // Resets audio volume to full and starts playback of new track immediately
    // Called by BgmChangeTrack objects
    public void SwitchTrack (string trackName)
    {
        changeFlagOn = true;

        audioSources[1 - flip].Stop();

        SetVolume(1.0f);

        currentTrack = trackDict[trackName];
        index = currentTrack.GetNextClipIndex(index, true);
        nextEventTime += 60.0f / currentTrack.tempo * currentTrack.numBeatsPerClip;
        
        audioSources[flip].clip = currentTrack.clipList[index];
        audioSources[flip].Play();  
        flip = 1 - flip;

        // Debug.Log("SwitchTrack: Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);
        changeFlagOn = false;
    }

    // Fades the currently playing track out and then plays trackName
    public void FadeAndSwitchTrack(string trackName, float fadeOutStep, float fadeOutSpeed)
    {
        FadeOut(fadeOutStep, fadeOutSpeed);
        SwitchTrack(trackName);
    }

    // Decreases volume of both audioSources by -step every speed seconds until volume == 0.0f
    // TODO: figure out why fading out only happens when Debug.Log is called
    // TODO: when Debug.Log is called, game freezes while fadeout is happening. May have to use coroutines
    public void FadeOut (float step, float speed)
    {
        fadeOutFlagOn = true;
        float timeElapsed = 0.0f;
        fadeOutFlagOn = true;
        while (volume > 0.0f)
        {
            timeElapsed += Time.deltaTime;
            // Debug.Log(timeElapsed);
            if (timeElapsed >= speed)
            {
                ChangeVolume(-step);
                timeElapsed = 0.0f;
            }
        }
        fadeOutFlagOn = false;
    }

    // Changes volume of both AudioSources by amount
    // Can be positive or negative
    private void ChangeVolume(float amount)
    {
        volume += amount;
        audioSources[0].volume = volume;
        audioSources[1].volume = volume;
    }

    // Sets volume of both AudioSources to level
    // Range is from 0.0f to 1.0f inclusive
    private void SetVolume(float level)
    {
        volume = level;
        audioSources[0].volume = level;
        audioSources[1].volume = level;
    }

    private IEnumerator Wait(float seconds)
    {
        waitActive = true;
        yield return new WaitForSeconds(seconds);
        waitActive = false;
    }

}