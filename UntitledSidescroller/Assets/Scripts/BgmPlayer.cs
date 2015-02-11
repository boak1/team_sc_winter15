using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* Generic music player for levels. 
 * Things that aren't implemented yet:
 *  - a way to specify different clip selection index algorithms for different songs; not all tracks may loop the same way.
 *      (For now, clip 0 starts, and then after that clip 1 loops until game is exited)
 *  - responding to "change music" flags sent by other game objects
 *  
 * Bugs:
 *  - second clip isn't getting loaded into the second AudioSource, so music stops after first clip finishes
 */

[RequireComponent(typeof(AudioSource))]
public class BgmPlayer : MonoBehaviour {

    public AudioClip[] bgmClips = new AudioClip[2];
    public float bgmTempo;
    public int numBeatsPerSegment;
    public float bgmStartDelayInSeconds = 0.0F;
    // public List<GameObject> gameObjsWithAudioFlags = new List<GameObject>();

    private int index = 0;
    private double nextEventTime;
    private AudioSource[] audioSources = new AudioSource[2];

	// Use this for initialization
	void Start () {
        for (int i = 0; i < bgmClips.Length; i++)
        {
            GameObject child = new GameObject("BgmPlayerChild");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
        }
         
        nextEventTime = AudioSettings.dspTime;
	}
	
	// Update is called once per frame
	void Update () {

        	double time = AudioSettings.dspTime;
        if (time + 1.0F > nextEventTime)
        {
            audioSources[index].clip = bgmClips[index];
            audioSources[index].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled source " + index + " to start at time " + nextEventTime);
            nextEventTime += 60.0F / bgmTempo * numBeatsPerSegment;
            index = 1;
        }
	}

    
}
