using UnityEngine;
using System.Collections;

public class PlatformProperties : MonoBehaviour {

    public bool teleportable = true;

    public bool getTeleportable()
    {
        return teleportable;
    }

    public void setTeleportable(bool teleportable)
    {
        this.teleportable = teleportable;
    }
}
