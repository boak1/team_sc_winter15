using UnityEngine;
using System.Collections;

public class PlatformTeleportBehavior : MonoBehaviour {
    //Written By Kevin W.
    public Transform[] waypoints;
    public float delayBetweenTeleport;

    private int i = 0;

	// Update is called once per frame
	void Start () 
    {
        InvokeRepeating("teleportToNextPoint", 0f, delayBetweenTeleport); 
	}

    void teleportToNextPoint()
    {
        //using % operator for circulating an array
        transform.position = waypoints[i%waypoints.Length].position;
        i++;
    }


}
