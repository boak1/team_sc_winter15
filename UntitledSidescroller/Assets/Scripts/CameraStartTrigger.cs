using UnityEngine;
using System.Collections;

public class CameraStartTrigger : MonoBehaviour {
    CameraMovement CM;
    public CameraMovement.Direction newDirection;
    public Vector2 newSpeed = new Vector2(0,0);
	// Use this for initialization
	void Start () {
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name == "Player")
        {            
            CM.direction = newDirection;
            CM.speed = newSpeed;
        }
    }
}
