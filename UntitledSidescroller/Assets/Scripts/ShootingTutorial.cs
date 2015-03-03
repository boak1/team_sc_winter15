using UnityEngine;
using System.Collections;

public class ShootingTutorial : MonoBehaviour {    
    public GameObject redPractice;
    public GameObject greenPractice;
    public GameObject bluePractice;
    CameraMovement CM;
	// Use this for initialization
	void Start () {
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();
	}
	
	// Update is called once per frame
	void Update () {
        if (redPractice == null && greenPractice == null && bluePractice == null)
            CM.speed = new Vector2(1, 1);
	}
}
