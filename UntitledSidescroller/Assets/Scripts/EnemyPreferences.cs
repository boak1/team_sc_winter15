using UnityEngine;
using System.Collections;

public class EnemyPreferences : MonoBehaviour {
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
	public bool killOffScreen = true;
	public bool givesHp, diesOnContact = true, shoots = false;
	public int contactDamage = 1, hp4Kill = 1, enemyHP = 1;
	private int initEnemyHP;
	
	private SfxPlayer sfxPlayer;
	ShootingScript SS;  

    void Start()
    {
        SS = GameObject.Find("PlayerShooting").GetComponent<ShootingScript>();  //Import ShootingScript
		sfxPlayer = GameObject.Find("SfxPlayer").GetComponent<SfxPlayer>();
			
			initEnemyHP = enemyHP;
			
			if (this.GetComponent<EnemyShooting>() != null)
				this.GetComponent<EnemyShooting>().enabled = false;
			
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

        ///Start shooting only when the player can see the enemy.
        if (this.GetComponent<EnemyShooting>() != null)
            this.GetComponent<EnemyShooting>().enabled = shoots;
    }

	public void tookDamage(){
		if(initColor != COLOR.INDESTRUCTIBLE){
		enemyHP -= SS.laserDamage;

			gameObject.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, (.35f + (((float)enemyHP / (float)initEnemyHP)*.65f)));

		if (enemyHP <= 0)
				Destroy (this.gameObject);
		}
	}
	
	void OnBecameInvisible()
	{
        ///Stop shooting when the player can't see the enemy
        shoots = false;
        if (this.GetComponent<EnemyShooting>() != null)
            this.GetComponent<EnemyShooting>().enabled = shoots;
		if(killOffScreen)
		    Destroy (this.gameObject);
	}


	void OnDestroy()
	{
		if(givesHp)
		{
			//Debug.Log("U HAVE HP!!!");
			if( PlayerHealth.hp < PlayerHealth.maxHp)
			{
				//Debug.Log("gimme hp");
				PlayerHealth.hp += hp4Kill;
			}
		}
	}

    //void OnCollisionEnter2D(Collision2D hit)
    //{
    //        if (hit.gameObject.name == "Player") {
    //            PlayerHealth.hp -= contactDamage;
    //            if (diesOnContact)
    //                    Destroy (this.gameObject);
    //            sfxPlayer.PlaySfx("Hit_Hurt_loud");
    //        }

    //        if(enemyHP <= 0){
    //            Destroy(this.gameObject);
    //        }    
    //}
}
