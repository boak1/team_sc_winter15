using UnityEngine;
using System.Collections;

public class PlatformMappingScript : MonoBehaviour {
    public Queue platformQueue = new Queue();

	// Use this for initialization
	void Start () {
        GameObject GM = GameObject.Find("GameManager");
        GameManager GM_Script = GM.GetComponent<GameManager>();
        if (GM_Script != null)
        {
            foreach (GameObject platform in GM_Script.platform_list)
            {
                if (-6 <= platform.transform.position.x && platform.transform.position.x <= 6){
                    platformQueue.Enqueue(platform);                   
                }
            }
        }         
	}
	
	// Update is called once per frame
	void Update () {        
	}
}
