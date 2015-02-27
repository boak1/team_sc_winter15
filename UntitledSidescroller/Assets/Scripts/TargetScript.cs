using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
    public enum COLOR { BLANK, RED, GREEN, BLUE, INDESTRUCTIBLE };
    public COLOR initColor; 
    ShootingScript SS;
    void Start()
    {
        SS = GameObject.Find("PlayerShooting").GetComponent<ShootingScript>();
    }
    void OnBecameVisible()
    {
        switch (initColor)
        {
            case COLOR.RED:
                SS.setRedTarget(this.gameObject);
                break;
            case COLOR.GREEN:
                SS.setGreenTarget(this.gameObject);
                break;
            case COLOR.BLUE:
                SS.setBlueTarget(this.gameObject);
                break;
        }
    }
}
