using UnityEngine;
using System.Collections;

public class PlatformWaypointMovement : MonoBehaviour {
	public Transform[] waypoints;
	public float speed;
	int index = 0;
	
	
	void Update()
	{
		float step = speed * Time.deltaTime;        
		transform.position = Vector3.MoveTowards(transform.position, waypoints[index].position, step);
		if (transform.position - waypoints[index].position == new Vector3(0,0,0))
		{
			index++;
			if (index > waypoints.Length - 1)
				index = 0;
		}            
	}
	
	//void OnCollisionEnter2D(Collision2D hit)
	//{
	//    if (hit.gameObject.name.Contains("Waypoint"))            
	//    {
	//        Debug.Log("Hello");
	//        index++;
	//        if (index > waypoints.Length - 1)
	//        {
	//            index = 0;
	//        }
	//    }
	//}
}
