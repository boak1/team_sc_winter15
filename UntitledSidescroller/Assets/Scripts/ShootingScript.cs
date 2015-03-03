﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ShootingScript : MonoBehaviour {
    ///Holders for the LineRenderer GameObjects
    private LineRenderer redLaserLine;
    private LineRenderer greenLaserLine;
    private LineRenderer blueLaserLine;
    ///Holders for the actual LineRender components of each
    private LineRenderer redPredictionLine;
    private LineRenderer greenPredictionLine;
    private LineRenderer bluePredictionLine;	
	
    ///Holders for the red, green, blue enemies/objects that are on the screen.  These get assigned through the public setter methods below
	public GameObject redTarget; 
	public GameObject greenTarget; 
	public GameObject blueTarget;
    
    void Start()
    {
        ///Link the components of each lineRender for easier use.
        redPredictionLine = GameObject.Find("Player/PlayerShooting/RedPredictionLineRenderer").GetComponent<LineRenderer>();
        greenPredictionLine = GameObject.Find("Player/PlayerShooting/GreenPredictionLineRenderer").GetComponent<LineRenderer>();
        bluePredictionLine = GameObject.Find("Player/PlayerShooting/BluePredictionLineRenderer").GetComponent<LineRenderer>();

        redLaserLine = GameObject.Find("Player/PlayerShooting/RedLaserLineRenderer").GetComponent<LineRenderer>();
        greenLaserLine = GameObject.Find("Player/PlayerShooting/GreenLaserLineRenderer").GetComponent<LineRenderer>();
        blueLaserLine = GameObject.Find("Player/PlayerShooting/BlueLaserLineRenderer").GetComponent<LineRenderer>();
    }
	
	void Update () {
        ///If player shoots, aim and shoot at that target.  Will stop after the first collider it hits.
        if (Input.GetKeyDown(KeyCode.J) && redTarget != null)
        {
            shootAt(redTarget);           
        }
        else if (Input.GetKeyDown(KeyCode.K) && greenTarget != null)
        {
            shootAt(greenTarget);            
        }
        else if (Input.GetKeyDown(KeyCode.L) && blueTarget != null)
        {
            shootAt(blueTarget);            
        }
	}

    void FixedUpdate()
    {
        drawPredictionLines();
        redLaserLine.SetPosition(0, this.transform.position);
        redLaserLine.SetPosition(1, this.transform.position);
        greenLaserLine.SetPosition(0, this.transform.position);
        greenLaserLine.SetPosition(1, this.transform.position);
        blueLaserLine.SetPosition(0, this.transform.position);
        blueLaserLine.SetPosition(1, this.transform.position);
    }

    /// <summary>
    /// :param:target: parameter for the target to aim at
    /// Shoots in the direction of the target and kills the first enemy it hits.
    /// </summary>    
    void shootAt(GameObject target)
    {
        Dictionary<GameObject, LineRenderer> lineDict = new Dictionary<GameObject, LineRenderer>();
        if (redTarget!=null) lineDict.Add(redTarget, redLaserLine);
        if (greenTarget!=null) lineDict.Add(greenTarget, greenLaserLine);
        if (blueTarget!=null) lineDict.Add(blueTarget, blueLaserLine);       
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, target.transform.position - this.transform.position);
        if (hits.Length > 0)
        {
            lineDict[target].SetPosition(0, this.transform.position);
            lineDict[target].SetPosition(1, hits[0].transform.position);
            if (hits[0].collider.CompareTag("Enemy"))
            {
                Destroy(hits[0].collider.gameObject);
            }
        }
    }

    /// <summary>
    /// Function which draws all three prediction lines
    /// </summary>
    void drawPredictionLines()
    {
        ///Draws a prediction line to the redTarget holder if there is one.  Else: sets the beginning vertex and end vertex to both the
        ///Front of the player's gun.
        if (redTarget != null)
        {
            redPredictionLine.SetPosition(0, this.transform.position);
            redPredictionLine.SetPosition(1, redTarget.transform.position);
        }
        else
        {
            redPredictionLine.SetPosition(0, this.transform.position);
            redPredictionLine.SetPosition(1, this.transform.position);
        }

        ///Draws the prediction line for the greenTarget if there is one.  Else: sets the beginning vertex and end vertex to both the
        ///Front of the player's gun.
        if (greenTarget != null)
        {
            greenPredictionLine.SetPosition(0, this.transform.position);
            greenPredictionLine.SetPosition(1, greenTarget.transform.position);
        }
        else
        {
            greenPredictionLine.SetPosition(0, this.transform.position);
            greenPredictionLine.SetPosition(1, this.transform.position);
        }

        ///Draws the prediction line for the redTarget if there is one.  Else: sets the beginning vertex and end vertex to both the
        ///Front of the player's gun.
        if (blueTarget != null)
        {
            bluePredictionLine.SetPosition(0, this.transform.position);
            bluePredictionLine.SetPosition(1, blueTarget.transform.position);
        }
        else
        {
            bluePredictionLine.SetPosition(0, this.transform.position);
            bluePredictionLine.SetPosition(1, this.transform.position);
        }
    }






    /// <summary>
    /// :setRedTarget & setGreenTarget & setBlueTarget: Setters will be called by the targetScript (that is attached to every enemy)
    ///                                                 when they enter the screen, to link themselves with this scripts target holders
    /// </summary>    
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



///Unused atm
//private GameObject beam;
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