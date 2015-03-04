﻿using UnityEngine;
using System.Collections;
using System;


public class EnemyHomingMovement : MonoBehaviour {

	private bool homing, visible;
	GameObject pm;
    public Vector2 boundstart = new Vector2(5, 5); 
	public Vector2 boundend = new Vector2(5, 5);    

    private Vector2 startPos;
	// Use this for initialization
	void Start () {
		pm = GameObject.Find("Player");
        startPos = new Vector2(this.transform.position.x, this.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        if (pm.transform.position.x > startPos.x - boundstart.x && pm.transform.position.x < startPos.x + boundend.x &&
            pm.transform.position.y > startPos.y - boundend.y && pm.transform.position.y < startPos.y + boundstart.y)
            homing = true;
        else
            homing = false;

		if (homing && visible) {
			float movex = pm.transform.position.x - transform.position.x;
			float movey = pm.transform.position.y - transform.position.y;

			transform.position = new Vector2 (transform.position.x + (movex/Math.Abs(movex)) * .02f, transform.position.y + (movey/Math.Abs(movey))*.02f);
		}		        
	}

    void OnBecameInvisible()
    {   //are they staying on screen?
        Destroy(this.gameObject);
    }

	void OnBecameVisible()
	{   //is the gameobject on screen?
		visible = true;
	}
}