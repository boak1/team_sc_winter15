using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public float timeBetweenShots = 5f, projectileSpeed = 1f;
    //public int projectileDamage = 1; Don't know how to carry this value over to the instantiated prefab just yet - don't wanna make a 
    //completely new script just to carry that data over.
    private float cooldownTimer = 3f;    
    public GameObject projectilePrefab;
    private GameObject player;
    private Vector3 playerOriginOffset = new Vector3(0, 1f, 0);
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
            Vector3 dir = player.transform.position + playerOriginOffset - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject projectile = (GameObject)Instantiate(projectilePrefab.gameObject, this.transform.position + this.transform.forward, 
                Quaternion.AngleAxis(angle, new Vector3(0, 0, 1)));
            projectile.GetComponent<Rigidbody2D>().velocity = (new Vector2(projectileSpeed * dir.x, projectileSpeed * dir.y));            
            Destroy(projectile, 5);
            cooldownTimer = timeBetweenShots;
        }        
	}
}
