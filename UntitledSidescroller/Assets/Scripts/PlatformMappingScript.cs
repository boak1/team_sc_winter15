using UnityEngine;
using System.Collections;

public class PlatformMappingScript : MonoBehaviour {
    public Queue platformQueue = new Queue();
    GameManager GM;

	// Use this for initialization
	void Start () {       
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        if (GM != null){
            ///Iterates through the entire list of platforms created in the GameManager script at the start of the game
            foreach (GameObject platform in GM.platform_list){
                /// Grabs the first platforms already in the game screen at the start of the game                
                if (-6 <= platform.transform.position.x && platform.transform.position.x <= 6){
                    platformQueue.Enqueue(platform);                   
                }
            }
        }

        //foreach (GameObject platform in platformQueue)
        //{
        //    Debug.Log(platform.transform.position.x);
        //}
	}

    public void Enqueue(GameObject platform)
    {
        if (!platformQueue.Contains(platform))
        {
            platformQueue.Enqueue(platform);
            Debug.Log("Enqueued Something");
        }
    }

    public void Dequeue(GameObject platform)
    {
        if (platformQueue.Contains(platform))
        {
            platformQueue.Dequeue();
            Debug.Log("Dequeued Something");
        }
    }
}
