using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;
    public int color; 
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setColor(int newColor)
    {
        switch (newColor)
        {
            case 1:
                return;
            case 2:
                return;
            case 3:
                return;
            default:
                return;
                
        }
    }
}
