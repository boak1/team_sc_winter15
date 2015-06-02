using UnityEngine;
using System.Collections;

public class Targetable : MonoBehaviour {
    //Since not all targetable objects should logically be enemies I created this seperate script 

    public enum COLOR { RED, GREEN, BLUE };
    public COLOR Color;

    ShootingScript shootingScript;

    void Start()
    {
        shootingScript = GameObject.Find("PlayerShooting").GetComponent<ShootingScript>();     
    }

    void OnBecameVisible()
    {
        switch (Color)
        {
            case COLOR.RED:
                shootingScript.setRedTarget(this.gameObject);
                break;
            case COLOR.GREEN:
                shootingScript.setGreenTarget(this.gameObject);
                break;
            case COLOR.BLUE:
                shootingScript.setBlueTarget(this.gameObject);
                break;
        }
    }

    void OnBecameInvisible()
    {
        switch (Color)
        {
            case COLOR.RED:
                shootingScript.setRedTarget(null);
                break;
            case COLOR.GREEN:
                shootingScript.setGreenTarget(null);
                break;
            case COLOR.BLUE:
                shootingScript.setBlueTarget(null);
                break;
        }
    }
}
