using UnityEngine;
using System.Collections;

public class PlatformProperties : MonoBehaviour {

    public bool teleportable = true;
	public bool spinning = false;
	public float degreeSpin = 50.0f;
    public bool getTeleportable()
    {
        return teleportable;
    }

    public void setTeleportable(bool teleportable)
    {
        this.teleportable = teleportable;
    }
	void Update()
	{
		if (spinning)
		transform.Rotate (0,0,degreeSpin * Time.deltaTime);
	}
}
