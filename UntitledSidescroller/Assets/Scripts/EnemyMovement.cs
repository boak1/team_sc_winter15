using UnityEngine;
using System.Collections;
using System;


public class EnemyMovement : MonoBehaviour {

	public bool homing;
	GameObject pm;

    public float speed;
	// Use this for initialization
	void Start () {
		pm = GameObject.Find("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (homing) {
			float movex = pm.transform.position.x - transform.position.x;
			float movey = pm.transform.position.y - transform.position.y;
			if(Math.Abs(movex)==.02f)
				movex = 0f;
			if(Math.Abs(movey)==.02f)
				movey = 0f;

			transform.position = new Vector2 (transform.position.x + (movex/Math.Abs(movex)) * .02f, transform.position.y + (movey/Math.Abs(movey))*.02f);
		}
		else
	        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        //this.GetComponent<Health>().takeDamage(5);
	}

    void OnBecameInvisible()
    {   //are they staying on screen?
        Destroy(this.gameObject);
    }
}
