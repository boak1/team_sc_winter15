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
                platformQueue.Enqueue(platform); // @@@!!! MUST FIND A WAY TO ENQUEUE ONLY THE PLATFORMS IN THE LIST THAT ARE INSIDE THE CAMERA !!!@@@
            }
            //platformQueue.Enqueue(GM_Script.platform_list[0]);
            //Debug.Log(platformQueue.Dequeue());
        }
        
	}
	
	// Update is called once per frame
	void Update () {        
	}
}
