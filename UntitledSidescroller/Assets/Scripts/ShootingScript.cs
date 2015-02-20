using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour {

	public GameObject blueLaser; 
	public GameObject greenLaser; 
	public GameObject redLaser; 
	public GameObject redTarget; 
	public GameObject greenTarget; 
	public GameObject blueTarget; 
	private GameObject beam;
	// we need to draw a line from the players coridnents to the targets 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.J)) 
        //{
        //    if (beam == null){
        //        float xPos = redTarget.transform.position.x ;
        //        float yPos = redTarget.transform.position.y;
        //       beam = (GameObject)Instantiate(blueLaser, transform.position+new Vector3(xPos, yPos, 0), Quaternion.identity);
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.K)) 
        //{
        //    if (beam == null){
        //        float xPos = blueTarget.transform.position.x ;
        //        float yPos = blueTarget.transform.position.y;
        //    beam = (GameObject)Instantiate(greenLaser, transform.position+new Vector3(0, 0, 0), Quaternion.identity);
        //    }
        //}
        //else if (Input.GetKeyDown(KeyCode.L)) 
        //{
        //    if (beam == null){
        //        float xPos = blueTarget.transform.position.x ;
        //        float yPos = blueTarget.transform.position.y;
        //    beam = (GameObject)Instantiate(redLaser, transform.position+new Vector3(0, 0, 0), Quaternion.identity);
        //    }
        //}
        //if (Input.GetKeyUp(KeyCode.J))
        //{
        //    Destroy(beam);
        //}
        //else if (Input.GetKeyUp(KeyCode.K))
        //{
        //    Destroy(beam);
        //}
        //else if (Input.GetKeyUp(KeyCode.L))
        //{
        //    Destroy(beam);
        //}

        
        if (Input.GetKeyUp(KeyCode.J))
        {
            Debug.DrawLine(this.transform.position, redTarget.transform.position, Color.red, 2, false);            
        }
        else if (Input.GetKeyUp(KeyCode.K))
        {
            Debug.DrawLine(this.transform.position, greenTarget.transform.position, Color.green, 2, false);            
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            Debug.DrawLine(this.transform.position, blueTarget.transform.position, Color.blue, 2, false);           
        }
	}

    public void setRedTarget(GameObject target)
    {
        redTarget = target;
    }
    public void setGreenTarget(GameObject target)
    {
        greenTarget = target;
    }
    public void setBlueTarget(GameObject target)
    {
        blueTarget = target;
    }
}
