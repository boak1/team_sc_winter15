using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
	
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	public EnemyPreferences[] enemies;		// Array of enemy prefabs.
	private bool NeutralEnemies;
	ShootingScript SS;
	int enemyIndex;

	void Start ()
	{
				// Start calling the Spawn function repeatedly after a delay .
				InvokeRepeating ("Spawn", spawnDelay, spawnTime);

		SS = GameObject.Find("PlayerShooting").GetComponent<ShootingScript>();

				//for (int x = 0; x<enemies.Length; x++) {
				//		if (enemies [x].GetComponent<EnemyPreferences> ().initColor == EnemyPreferences.COLOR.BLANK || enemies [x].GetComponent<EnemyPreferences> ().initColor == EnemyPreferences.COLOR.INDESTRUCTIBLE) {
				//				NeutralEnemies = true;
				//				break;
				//		}
				//		NeutralEnemies = false;
				//}
		}
	void Spawn (){
			//Instantiate a random enemy.
			int check = 50;
			while (check > 0) {
					enemyIndex = Random.Range (0, enemies.Length);
					if (SS.isEnemyNull (enemies [enemyIndex].initColor)) {
							break;
					}
					check--;
			}
		
			if (check > 0)
					Instantiate (enemies [enemyIndex], transform.position, transform.rotation);
	} 
}