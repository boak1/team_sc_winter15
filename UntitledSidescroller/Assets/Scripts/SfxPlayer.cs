using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(AudioSource))]
public class SfxPlayer : MonoBehaviour {

    public AudioSource audioSource;

    private Dictionary<string, AudioClip> soundDict = new Dictionary<string, AudioClip>();
    public List<AudioClip> soundEffects = new List<AudioClip>();

	// Use this for initialization
	void Start () {

        // Set up the dictionary from the list of sound effects
        foreach (AudioClip clip in soundEffects)
        {
            soundDict.Add(clip.name, clip);
        }
	}
	
	// Update is called once per frame
	void Update () {

        // Test Code
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlaySfx("chargeup");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            PlaySfx("teleport");
        }
	}

    // When called, loads the specified sound effect into the AudioSource and plays it
    void PlaySfx(string sfxName)
    {
        AudioClip clip = soundDict[sfxName];
        audioSource.PlayOneShot(clip, 0.7f);
    }
}
