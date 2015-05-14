using UnityEngine;
using System.Collections;

public class PlatformProperties : MonoBehaviour {

    public bool teleportable = true;
	public bool spinning = false;
	public float degreeSpin = 50.0f;
	public float platformTilt = 0.0f;
	public bool tilted = false;

	public bool getTeleportable ()
    {
        return teleportable;
    }

    public void setTeleportable(bool teleportable)
    {
        this.teleportable = teleportable;
    }
	void Update()
	{
		//check platform orientation
		if (spinning)
			transform.Rotate (0,0,degreeSpin * Time.deltaTime);
		if(tilted)
		{
			transform.Rotate(0,0,platformTilt);
			tilted = false;
		}

	}
}
