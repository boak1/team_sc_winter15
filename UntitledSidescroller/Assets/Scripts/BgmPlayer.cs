using UnityEngine;
using System.Collections;

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

    private int index = 0;
    private int flip = 0;
    private double nextEventTime;
    private AudioSource[] audioSources = new AudioSource[2];
    private bool running = false;

	// Use this for initialization
	void Start () {
        for (int i = 0; i < 2; i++)
        {
            GameObject child = new GameObject("BgmPlayerChild");
            child.transform.parent = gameObject.transform;
            audioSources[i] = child.AddComponent("AudioSource") as AudioSource;
        }
        
        nextEventTime = AudioSettings.dspTime + bgmStartDelayInSeconds;
        running = true;
	}
	
	// Update is called once per frame
	void Update () {
        if (!running)
        {
            return;
        }

        	double time = AudioSettings.dspTime;

        if (time + 1.0F > nextEventTime)
        {
            audioSources[flip].clip = bgmClips[index];
            audioSources[flip].PlayScheduled(nextEventTime);
            Debug.Log("Scheduled clip " + index + " to AudioSource " + flip + " at start at time " + nextEventTime);
            nextEventTime += 60.0F / bgmTempo * numBeatsPerSegment;
            index = 1;
            flip = 1 - flip;
        }
	}
}
