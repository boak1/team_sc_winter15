using UnityEngine;
using System.Collections;

public class CheckpointTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnBecameVisible()
    {
        PlayerPrefs.SetInt("CheckpointCounter", PlayerPrefs.GetInt("CheckpointCounter") + 1);
    }
}
