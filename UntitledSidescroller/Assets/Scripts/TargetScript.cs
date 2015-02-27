using UnityEngine;
using System.Collections;

public class TargetScript : MonoBehaviour {
    /// <summary>
    /// This script should be added to any enemy to house certain attributes.
    /// This script will associate a COLOR to each enemy and link it with the ShootingScript accordingly.
    /// </summary>
    

    ///<summary>
    ///:enum COLOR: Choices of colors - a dropdown menu is added to this script in the inspector
    ///:initColor: The target's initial color
    ///:SS: Import ShootingScript to talk to it - link this target with the appropriate target holder in the ShootingScript
    /// </summary>
    public enum COLOR { BLANK, RED, GREEN, BLUE, INDESTRUCTIBLE };
    public COLOR initColor; 
    ShootingScript SS;
    void Start()
    {
        SS = GameObject.Find("PlayerShooting").GetComponent<ShootingScript>();  //Import ShootingScript
    }
    void OnBecameVisible()
    {
        ///Depending on what color this target is - link it with the appropriate target holder in the ShootingScript so that the ShootingScript
        ///can aim at it.
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
