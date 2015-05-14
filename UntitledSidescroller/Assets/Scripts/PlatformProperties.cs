using UnityEngine;
using System.Collections;

public class PlatformProperties : MonoBehaviour {

    public bool teleportable = true;
	public bool spinning = false;
	public float degreeSpin = 50.0f;
	public bool vertical = false;
	public bool upsideDown = false;

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
		if(vertical)
		{
			transform.Rotate(0,0,90);
			vertical = false;
		}
		if (upsideDown) 
		{
			transform.Rotate(0,0,180);
			upsideDown = false;
		}
	}
}
