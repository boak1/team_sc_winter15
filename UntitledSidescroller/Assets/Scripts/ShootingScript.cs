using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject blueLaser; 
	private GameObject beam;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.J)) 
		{
			beam = (GameObject)Instantiate(blueLaser, transform.position+new Vector3(0, 0, 0), Quaternion.identity);
		}
		else if (Input.GetKeyDown(KeyCode.K)) 
		{

		}
		else if (Input.GetKeyDown(KeyCode.L)) 
		{
			
		}

	}
}
