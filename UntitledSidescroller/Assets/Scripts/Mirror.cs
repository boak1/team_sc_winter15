using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mirror : MonoBehaviour {
    public void Reflect(Vector3 origin)
    {
        RaycastHit2D[] hits = Physics2D.RaycastAll(this.transform.position, origin - this.transform.position);
        if (hits.Length > 0)
        {
            if (hits[0].collider.CompareTag("Enemy"))
            {
                Destroy(hits[0].collider.gameObject);
            }
        }
    } 
}
