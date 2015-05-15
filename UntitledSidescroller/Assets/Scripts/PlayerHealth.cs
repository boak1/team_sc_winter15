using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public static int maxHp = 3;
	public static int hp;
    //get the hp sprites
    public Sprite fullHp;
    public Sprite oneHP;
    public Sprite twoHP;
    //used to change sprites
    private SpriteRenderer spriteRendererH;    
    void Start()
    {
		hp = maxHp;
        spriteRendererH = GetComponent<SpriteRenderer>(); //  the SpriteRenderer that is attached to the Gameobject
        if (spriteRendererH.sprite == null) // if the sprite  is empty// set the sprite to fullHP
            spriteRendererH.sprite = fullHp;

    }
    
    void Update()
    {
        int hpTest = hp;
		if (hpTest == maxHp) 
		{
			spriteRendererH.sprite = fullHp;
		}
        else if (hpTest == 2)
        {
            spriteRendererH.sprite = twoHP;//change the sprite to 2 hp
        }
        else if (hpTest == 1)
        {
            spriteRendererH.sprite = oneHP; // change the sprite to 1 hp
        }
        else if (hpTest <= 0)
        {
            GameManager.gameOver();
        }
    }
}