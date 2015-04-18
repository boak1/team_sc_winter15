using UnityEngine;
using System.Collections;

public class CheckpointTrigger : MonoBehaviour {
    CameraMovement CM;
	PlayerMovement PM;
	public GameObject checkpointPlatform;

	// Use this for initialization
	void Start () {
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();
		PM = GameObject.Find("Player").GetComponent<PlayerMovement>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.name == "Player")
        {
            PlayerPrefs.SetFloat("CheckpointX", this.transform.position.x);
            PlayerPrefs.SetFloat("CheckpointY", this.transform.position.y);
            PlayerPrefs.SetFloat("CheckpointZ", this.transform.position.z);
            PlayerPrefs.SetString("CameraDirection", CM.getCurrentDirection());
            PlayerPrefs.SetFloat("CameraSpeedX", CM.getCurrentSpeed().x);
            PlayerPrefs.SetFloat("CameraSpeedY", CM.getCurrentSpeed().y);
			PM.startPlatform = checkpointPlatform;
        }
    }
}
