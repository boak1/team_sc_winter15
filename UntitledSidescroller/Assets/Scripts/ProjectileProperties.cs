using UnityEngine;
using System.Collections;

public class ProjectileProperties : MonoBehaviour {

    public int damage = 1;

    void Start()
    {
        Destroy(this.gameObject, 5);
    }

    public void Init(float speed, int damage, Vector3 direction)
    {
        this.damage = damage;
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(speed * direction.x, speed * direction.y);
    }
    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    if (hitInfo.CompareTag("Enemy"))
    //    {
    //        return;
    //    }
    //    else
    //        Destroy(this.gameObject);
    //}
}
