using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {
    private SfxPlayer sfxPlayer;

    void Start()
    {
        sfxPlayer = GameObject.Find("SfxPlayer").GetComponent<SfxPlayer>();
    }
    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        if (hitInfo.collider.CompareTag("Enemy"))
        {
            PlayerHealth.hp -= hitInfo.gameObject.GetComponent<EnemyPreferences>().contactDamage;
            if (hitInfo.gameObject.GetComponent<EnemyPreferences>().diesOnContact)
                Destroy(hitInfo.gameObject);
            sfxPlayer.PlaySfx("Hit_Hurt_loud");
        }            
        //if (hitInfo.collider.CompareTag("Enemy Laser")){
        //    PlayerHealth.hp -= hitInfo.gameObject.GetComponent<ProjectileProperties>().damage;           
        //    sfxPlayer.PlaySfx("Hit_Hurt_loud");
        //}
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy Laser"))
        {
            PlayerHealth.hp -= hitInfo.gameObject.GetComponent<ProjectileProperties>().damage;
            sfxPlayer.PlaySfx("Hit_Hurt_loud");
        }
    }
}
