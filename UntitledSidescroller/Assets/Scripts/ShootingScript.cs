using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject blueLaser; 
	public GameObject greenLaser; 
	public GameObject redLaser; 
	public GameObject target1; 
	public GameObject target2; 
	public GameObject target3; 
	private GameObject beam;
	// we need to draw a line from the players coridnents to the targets 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.J)) 
		{
			if (beam == null){
				float xPos = target1.transform.position.x ;
				float yPos = target1.transform.position.y;
			   beam = (GameObject)Instantiate(blueLaser, transform.position+new Vector3(xPos, yPos, 0), Quaternion.identity);
			}
		}
		else if (Input.GetKeyDown(KeyCode.K)) 
		{
			if (beam == null){
				float xPos = target3.transform.position.x ;
				float yPos = target3.transform.position.y;
			beam = (GameObject)Instantiate(greenLaser, transform.position+new Vector3(0, 0, 0), Quaternion.identity);
			}
		}
		else if (Input.GetKeyDown(KeyCode.L)) 
		{
			if (beam == null){
				float xPos = target3.transform.position.x ;
				float yPos = target3.transform.position.y;
			beam = (GameObject)Instantiate(redLaser, transform.position+new Vector3(0, 0, 0), Quaternion.identity);
			}
		}
		if (Input.GetKeyUp(KeyCode.J))
		{
			Destroy(beam);
		}
		else if (Input.GetKeyUp(KeyCode.K))
		{
			Destroy(beam);
		}
		else if (Input.GetKeyUp(KeyCode.L))
		{
			Destroy(beam);
		}
	}
}
