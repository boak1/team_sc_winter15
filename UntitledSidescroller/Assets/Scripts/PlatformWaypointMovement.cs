using UnityEngine;
using System.Collections;

public class PlatformWaypointMovement : MonoBehaviour {
	public Transform[] waypoints;
	public float speed; //how fast the platform moves
	public bool stopAtEnd = false; // if set to true in unity it moves till it gets to the last waypoint then stops
	private bool stop = false;// if true platform stops
	int index = 0;
	
	
	void Update()
	{
		float step = speed * Time.deltaTime;    //how much the platform moves each update

		//v move the platform by one step if its appropriatev
		if(!stop)
		transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, step);

		//if the platform has hit a way point
		if (transform.position - waypoints[index].position == new Vector3(0,0,0) && !stop)
		{
			index++;// go to the next waypoint

			//should the platform stop or go back to the begining?
			if (index > waypoints.Length - 1 && !stopAtEnd)
				index = 0;
			else if(index > waypoints.Length - 1)//if the platform should stop, stop checking its position
				stop = true;
		}            
	}

}
