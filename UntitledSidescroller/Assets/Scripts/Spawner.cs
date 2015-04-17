using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public GameObject[] enemies;		// Array of enemy prefabs.
	public GameObject shoot; 
	private bool NeutralEnemies;
	public int check;
	int enemyIndex;
	
	void Start ()
	{
				// Start calling the Spawn function repeatedly after a delay .
				InvokeRepeating ("Spawn", spawnDelay, spawnTime);
				//for (int x = 0; x<enemies.Length; x++) {
				//		if (enemies [x].GetComponent<EnemyPreferences> ().initColor == EnemyPreferences.COLOR.BLANK || enemies [x].GetComponent<EnemyPreferences> ().initColor == EnemyPreferences.COLOR.INDESTRUCTIBLE) {
				//				NeutralEnemies = true;
				//				break;
				//		}
				//		NeutralEnemies = false;
				//}
		}
	void Spawn ()
	{
		//Instantiate a random enemy.
		check = 50;
			while (true) {

								enemyIndex = Random.Range (0, enemies.Length);
								check--;
								if (shoot.GetComponent<ShootingScript> ().isEnemyNull (enemies [enemyIndex].GetComponent<EnemyPreferences> ().initColor)) {
										//	if(enemies[enemyIndex].GetComponent<EnemyPreferences>().initColor = && shoot.getComponent<ShootingScript>().redTarget!= null)
										break;
								}

						}
		if(check>0)
						Instantiate (enemies [enemyIndex], transform.position, transform.rotation);
				} 
}