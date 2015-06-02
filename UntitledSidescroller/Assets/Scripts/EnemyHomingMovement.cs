using UnityEngine;
using System.Collections;
using System;


public class EnemyHomingMovement : MonoBehaviour {

	private bool homing, visible;
	GameObject player;
	public float speed = .02f;
    public Vector2 boundstart = new Vector2(5, 5); 
	public Vector2 boundend = new Vector2(5, 5);    

    private Vector2 startPos;
    private Vector3 playerOriginOffset;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("Player");
        startPos = new Vector2(this.transform.position.x, this.transform.position.y);
	}
	
	// Update is called once per frame
	void Update () {
        playerOriginOffset = new Vector3(
                Mathf.Sin((player.transform.eulerAngles.z * Mathf.PI) / 180) * -1f,
                Mathf.Cos((player.transform.eulerAngles.z * Mathf.PI) / 180) * 1f, 0f);
        Vector3 playerPosition = player.transform.position + playerOriginOffset;
        if (playerPosition.x > startPos.x - boundstart.x && playerPosition.x < startPos.x + boundend.x &&
            playerPosition.y > startPos.y - boundend.y && playerPosition.y < startPos.y + boundstart.y)
            homing = true;
        else
            homing = false;			        
	}

    void FixedUpdate()
    {
        playerOriginOffset = new Vector3(
                Mathf.Sin((player.transform.eulerAngles.z * Mathf.PI) / 180) * -1f,
                Mathf.Cos((player.transform.eulerAngles.z * Mathf.PI) / 180) * 1f, 0f);
        Vector3 playerPosition = player.transform.position + playerOriginOffset;
        if (homing && visible)
        {
            float movex = playerPosition.x - transform.position.x;
            float movey = playerPosition.y - transform.position.y;

            transform.position = new Vector2(transform.position.x + (movex / Math.Abs(movex)) * speed, transform.position.y + (movey / Math.Abs(movey)) * speed);
        }	
    }

	void OnBecameVisible()
	{   //is the gameobject on screen?
		visible = true;
	}
}
