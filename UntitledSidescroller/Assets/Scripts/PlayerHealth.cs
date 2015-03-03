using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    private int hp = 3;
    //get the hp sprites
    public Sprite fullHp;
    public Sprite oneHP;
    public Sprite twoHP;
    //used to change sprites
    private SpriteRenderer spriteRendererH;    
    void Start()
    {

        spriteRendererH = GetComponent<SpriteRenderer>(); //  the SpriteRenderer that is attached to the Gameobject
        if (spriteRendererH.sprite == null) // if the sprite  is empty// set the sprite to fullHP
            spriteRendererH.sprite = fullHp;

    }
    
    void Update()
    {
        int hpTest = hp;

        if (hpTest == 2)
        {
            spriteRendererH.sprite = twoHP;//change the sprite to 2 hp
        }
        else if (hpTest == 1)
        {
            spriteRendererH.sprite = oneHP; // change the sprite to 1 hp
        }
        else if (hpTest == 0)
        {
            Application.LoadLevel("Game Over"); //moves to game over screen

        }
    }
}