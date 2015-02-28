using UnityEngine;
using System.Collections;



public class EnemyMovement : MonoBehaviour {

	public bool homing;
	public GameObject pm;

    public float speed;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(homing)
			transform.position = new Vector2(transform.position.x + ((pm.transform.position.x + transform.position.x)%.05f), transform.position.y - ((transform.position.y - pm.transform.position.y)%.05f) );
		else
	        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
        //this.GetComponent<Health>().takeDamage(5);
	}

    void OnBecameInvisible()
    {   //are they staying on screen?
        Destroy(this.gameObject);
    }
}
