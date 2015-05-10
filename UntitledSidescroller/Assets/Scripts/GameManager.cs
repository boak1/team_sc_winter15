using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
    CameraMovement CM;
	PlayerMovement PM;
    void Awake()
    {
        Screen.SetResolution(800, 600, false);
    }

    void Start()
    {
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();   
		PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
		PM.currentPlatform = PM.startPlatform;

    }
    public static void gameOver()
    {        
        PlayerPrefs.SetInt("CurrentLevel", Application.loadedLevel);
        if (!GameWin.visible)
            Application.LoadLevel("Game Over");        
    }

    void OnLevelWasLoaded(int level)
    {
        if (level == 0)
        {
            PlayerHealth.hp = 3;
            CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>(); 
            CM.transform.position = new Vector3(PlayerPrefs.GetFloat("CheckpointX"),
                                    PlayerPrefs.GetFloat("CheckpointY"),
                                    PlayerPrefs.GetFloat("CheckpointZ"));
            CM.speed = new Vector2(PlayerPrefs.GetFloat("CameraSpeedX"), PlayerPrefs.GetFloat("CameraSpeedY"));
            CM.direction = CM.stringToDirection(PlayerPrefs.GetString("CameraDirection"));
			PM.currentPlatform = PM.startPlatform;
        }
    }
}







    /// Trash below
    
    //list of platforms
    //public List<GameObject> platformList;
    //platformList = new List<GameObject> ();
    //AddAllPlatforms ();
    //platformList.Sort(CompareByCoordinates);



    //foreach (GameObject p in platform_list)
    //    Debug.Log(p.transform.position.x);
    //Debug.Log (platform_list);
    //gameObject.transform.localPosition.x;

    /// <summary>
    /// Creates the list of platforms by finding all gameobjects in the game at the beginning of the game
    /// with the "Platform" tag
    /// </summary>
    //public void AddAllPlatforms () {
    //    GameObject[] go = GameObject.FindGameObjectsWithTag ("Platform");
    //        foreach (GameObject platform in go)
    //            AddPlatform (platform.gameObject);
    //}

    /// <summary>
    /// Adds a platform
    /// </summary>
    /// <param newTrackName="platform"></param>
    //public void AddPlatform (GameObject platform) {
    //    platformList.Add (platform);
    //}

    /// <summary>
    /// The comparison function used to sort the list
    /// @@@!!! Currently only by x coordinates of platforms and ascending from the left - just add a boolean once we implement vertical !!!@@@
    /// @@@!!! Turns out we have to implement booleans if we want to go right and opposite directions !!!@@@
    /// </summary>
    /// <param newTrackName="object1"></param>
    /// <param newTrackName="object2"></param>
    //private static int CompareByCoordinates(GameObject object1, GameObject object2)
    //{
    //    return object1.transform.position.x.CompareTo(object2.transform.position.x);
    //}
