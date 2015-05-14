using UnityEngine;
using System.Collections;

public class EnemyBulletScript : MonoBehaviour {
    public float speed = 1f;

	// Use this for initialization
	void Start () {
        Debug.Log(this.transform.rotation.w);
        Destroy(gameObject, 20);
	}

    void FixedUpdate()
    {

    }
}
