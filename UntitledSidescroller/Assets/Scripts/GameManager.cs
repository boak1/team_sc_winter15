﻿using UnityEngine;
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

        platform_list.Sort(CompareByCoordinates);

        //foreach (GameObject p in platform_list)
        //    Debug.Log(p.transform.position.x);
        //Debug.Log (platform_list);
        //gameObject.transform.localPosition.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    /// <summary>
    /// Creates the list of platforms by finding all gameobjects in the game at the beginning of the game
    /// with the "Platform" tag
    /// </summary>
	public void AddAllPlatforms () {
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Platform");
			foreach (GameObject platform in go)
				AddPlatform (platform.gameObject);
	}

    /// <summary>
    /// Adds a platform
    /// </summary>
    /// <param name="platform"></param>
	public void AddPlatform (GameObject platform) {
		platform_list.Add (platform);
	}

    /// <summary>
    /// The comparison function used to sort the list
    /// @@@!!!Currently only by x coordinates of platforms - just add a boolean once we implement vertical!!!@@@
    /// </summary>
    /// <param name="object1"></param>
    /// <param name="object2"></param>
    private static int CompareByCoordinates(GameObject object1, GameObject object2)
    {
        return object1.transform.position.x.CompareTo(object2.transform.position.x);
    }
}