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
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Enemy")){
            PlayerHealth.hp--;            
            sfxPlayer.PlaySfx("Hit_Hurt_loud");
        }
    }
}
