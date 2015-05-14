using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public float timeBetweenShots = 1f;
    private float cooldownTimer = 1f;
    public Transform bulletPrefab;
    private Transform player;
    float angle;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        cooldownTimer -= Time.deltaTime;
        if (cooldownTimer <= 0) //Fire shot
        {
            Vector3 dir = player.transform.position - this.transform.position;
            angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            GameObject projectile = Instantiate(bulletPrefab, this.transform.position + this.transform.forward, 
                Quaternion.AngleAxis(angle, new Vector3(0, 0, 1))) as GameObject;
            cooldownTimer = timeBetweenShots;
        }        
	}
}
