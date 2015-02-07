using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

    public int health;

    public enum COLOR { BLANK, RED, GREEN, BLUE };
    public COLOR initColor; 

    public Sprite spriteBlank;
    public Sprite spriteRed;
    public Sprite spriteGreen;
    public Sprite spriteBlue;

    

	// Use this for initialization
	void Start () {
        setColor(initColor);
	}
	
	// Update is called once per frame
    void Update()
    {
        //setColor(COLOR.GREEN);
        Debug.Log(health);
        if (health <= 0) //constantly check if self should be dead
        {
            //setColor(COLOR.BLUE);
            Destroy(this.gameObject);
        }
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

    public void takeDamage(int dmg)
    {
        health -= dmg;
    }
}
