using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	//list of platforms
	public static List<GameObject> platform_list;

	// Use this for initialization
	void Start () {
        Screen.SetResolution (800, 600, false);
		platform_list = new List<GameObject> ();
			AddAllPlatforms ();
		Debug.Log (platform_list);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void AddAllPlatforms () {
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Platform");
			foreach (GameObject platform in go)
				AddPlatform (platform.gameObject);
	}

	public void AddPlatform (GameObject platform) {
		platform_list.Add (platform);
	}
}
