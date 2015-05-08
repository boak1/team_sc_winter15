using UnityEngine;
using System.Collections;

public class PlatformFallingBehavior : MonoBehaviour {
    //Written By: Kevin W
    public Transform origin;
    public Transform bottom;
	public float fallSpeed;
    public float returnSpeed;

	void Update()
	{
        //beautiful code...
        if (playerIsOnThisPlatform())
            moveSelfTo(bottom.position, fallSpeed);
        else 
            moveSelfTo(origin.position, returnSpeed);
	}

    //private helper functions
    private void moveSelfTo(Vector3 destination, float speed)
    {
        float step = speed * Time.deltaTime;
        if (transform.position != destination)
            transform.position = Vector3.MoveTowards(transform.position, destination, step);
    }

    private bool playerIsOnThisPlatform()
    {
        return this.gameObject == GameObject.Find("Player").GetComponent<PlayerMovement>().currentPlatform;
    }
}
