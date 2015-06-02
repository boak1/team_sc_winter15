using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public float timeBetweenShots = 3f, projectileSpeed = 3f;
    public int projectileDamage = 1;
    private float cooldownTimer = 3f;    
    public GameObject projectilePrefab;
    private GameObject player;
    private Vector3 playerOriginOffset;
    float angle;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player");        
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0) //Fire shot
        {            
            playerOriginOffset = new Vector3(
                Mathf.Sin((player.transform.eulerAngles.z * Mathf.PI)/180) * -1f, 
                Mathf.Cos((player.transform.eulerAngles.z * Mathf.PI)/180) * 1f, 0f);            
            Vector3 dir = player.transform.position + playerOriginOffset - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject projectile = (GameObject)Instantiate(projectilePrefab.gameObject, this.transform.position + this.transform.forward, 
                Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            Physics2D.IgnoreCollision(projectile.GetComponent<Collider2D>(), this.GetComponent<Collider2D>());
            projectile.GetComponent<ProjectileProperties>().Init(projectileSpeed, projectileDamage, dir.normalized);
            cooldownTimer = timeBetweenShots;
        }        
	}
}
