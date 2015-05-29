using UnityEngine;
using System.Collections;

public class ProjectileProperties : MonoBehaviour {

    public int damage = 1;

    void Start()
    {        
        Destroy(this.gameObject, 20);
    }

    public void Init(float speed, int damage, Vector3 direction)
    {
        this.damage = damage;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction.x, speed * direction.y);
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log("Here");
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Platform") || 
            hitInfo.CompareTag("Panel") || hitInfo.CompareTag("Mirror") || hitInfo.CompareTag("Glass"))
        {
            Destroy(this.gameObject);
        }
        else if (hitInfo.tag.Contains("Enemy"))
        {
            return;
        }
    }
}
