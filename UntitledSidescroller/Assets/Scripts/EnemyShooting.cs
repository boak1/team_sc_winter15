using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {

    public float timeBetweenShots = 1f;
    private float cooldownTimer = 0f;
    public Transform bulletPrefab;
    private Transform player;

	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        Vector2 direction = player.transform.position - this.transform.position;
        Transform projectile = (Transform)Instantiate(bulletPrefab, this.transform.position, Quaternion.LookRotation(direction));
        
	}
}
