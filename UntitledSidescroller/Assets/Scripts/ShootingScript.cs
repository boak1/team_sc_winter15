using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingScript : MonoBehaviour {

    public GameObject redLaser;
    public GameObject greenLaser; 
	public GameObject blueLaser; 	
	
	public GameObject redTarget; 
	public GameObject greenTarget; 
	public GameObject blueTarget; 
	//private GameObject beam;
    private LineRenderer redLine;
    private LineRenderer greenLine;
    private LineRenderer blueLine;
	// we need to draw a line from the players coridnents to the targets 
    void Start()
    {
        redLine = redLaser.GetComponent<LineRenderer>();
        greenLine = greenLaser.GetComponent<LineRenderer>();
        blueLine = blueLaser.GetComponent<LineRenderer>();
    }
	// Update is called once per frame
	void Update () {
               
        if (Input.GetKeyUp(KeyCode.J) && redTarget != null)
        {
            aimAt(redTarget);
            Debug.DrawLine(this.transform.position, redTarget.transform.position, Color.red, 2, false);
        }
        else if (Input.GetKeyUp(KeyCode.K) && greenTarget != null)
        {
            aimAt(greenTarget);
            Debug.DrawLine(this.transform.position, greenTarget.transform.position, Color.green, 2, false);            
        }
        else if (Input.GetKeyUp(KeyCode.L) && blueTarget != null)
        {
            aimAt(blueTarget);
            Debug.DrawLine(this.transform.position, blueTarget.transform.position, Color.blue, 2, false);           
        }
	}

    void FixedUpdate()
    {        
        if (redTarget != null)
        {
            redLine.SetPosition(0, this.transform.position);
            redLine.SetPosition(1, redTarget.transform.position);
        }
        if (greenTarget != null)
        {
            greenLine.SetPosition(0, this.transform.position);
            greenLine.SetPosition(1, greenTarget.transform.position);
        }
        if (blueTarget != null)
        {
            blueLine.SetPosition(0, this.transform.position);
            blueLine.SetPosition(1, blueTarget.transform.position);
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

    /// <summary>
    /// :param:target - parameter for the target to aim at
    /// Shoots in the direction of the target and kills the first enemy it hits.
    /// </summary>    
    void aimAt(GameObject target)
    {        
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, target.transform.position - this.transform.position);
        if (hits.Length > 0)
        {
            if (hits[0].collider.CompareTag("Enemy"))
            {                
                Destroy(hits[0].collider.gameObject);
            }
        }
    }
}



///Unused atm
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