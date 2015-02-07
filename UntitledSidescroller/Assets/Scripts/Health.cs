using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;
    public enum COLOR { BLANK, RED, GREEN, BLUE };
    public COLOR color; 

    public Sprite spriteBlank;
    public Sprite spriteRed;
    public Sprite spriteGreen;
    public Sprite spriteBlue;

    

	// Use this for initialization
	void Start () {
        setColor(color);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void setColor(COLOR newColor)
    {
        switch (newColor)
        {
            case COLOR.RED:
                this.GetComponent<SpriteRenderer>().sprite = spriteRed;
                return;
            case COLOR.GREEN:
                this.GetComponent<SpriteRenderer>().sprite = spriteGreen;
                return;
            case COLOR.BLUE:
                this.GetComponent<SpriteRenderer>().sprite = spriteBlue;
                return;
            default:
                return;
                
        }
    }
}
