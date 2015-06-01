using UnityEngine;
using System.Collections;

public class EnemyBecomesPlatformOnDeathBehavior : MonoBehaviour {

    public GameObject platform;
	public EnemyPreferences EP;
	void Start(){
		EP = this.GetComponent<EnemyPreferences>();  //Import ShootingScript

	
	}

    void OnDestroy()
    {
		if(EP.enemyHP <= 0)
        Instantiate(platform, transform.position, Quaternion.identity);
    }
}
