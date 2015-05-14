using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SfxPlayer : MonoBehaviour {

    public AudioSource audioSource;

    private Dictionary<string, AudioClip> soundDict = new Dictionary<string, AudioClip>();
    public AudioClip[] soundEffects = new AudioClip[4];

	// Use this for initialization
	void Start () {
        if (soundDict.Count == 0)
        {
            return;
        }
        // Set up the dictionary from the list of sound effects
        foreach (AudioClip clip in soundEffects)
        {
            soundDict.Add(clip.name, clip);
        }
	}

    // When called, loads the specified sound effect into the AudioSource and plays it
    public void PlaySfx(string sfxName)
    {
        AudioClip clip = soundDict[sfxName];
        audioSource.PlayOneShot(clip, 0.7f);
    }
}
