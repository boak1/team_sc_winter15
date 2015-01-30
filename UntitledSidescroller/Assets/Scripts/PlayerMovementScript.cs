using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {
    public int positionQueue = 0;
    GameObject currentPlatform;
    GameManager GM;
    PlatformMappingScript platMap;

    float dbltapCooldown = 0.5f;
    int keyDCount = 0;
    int keyACount = 0;
    bool dblTap = false;
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();       
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMappingScript>();
        currentPlatform = GM.platformList[positionQueue];
	}
	
	// Update is called once per frame
	void Update () {       
        int newPosition = 0;

        if (Input.GetKeyDown(KeyCode.A) && positionQueue != 0){
            newPosition = -1;            
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            newPosition = 1;
        }


    //    if (Input.GetKeyDown(KeyCode.D)) {
    //        float cooldown = dbltapCooldown;
    //        if (dblTap)
    //        {
    //            newPosition = 2;
    //            dblTap = false;
    //        }
    //        else
    //        {
    //            dblTap = true;
    //            do
    //            {
    //                if (Input.GetKey(KeyCode.D))
    //                {
    //                    newPosition = -1;

    //                    break;
    //                }
    //                cooldown -= Time.deltaTime;
    //            } while (cooldown > 0);
    //            newPosition += 1;

    //        }
    //}

        //if (Input.GetKeyDown(KeyCode.D) && keyDCount == 0)
        //{
        //    //keyDCount += 1;
        //    newPosition = 1;
        //    float cooldown = dbltapCooldown;
        //    do
        //    {
        //        if (Input.GetKey(KeyCode.D))
        //        {
        //            newPosition = 2;
        //            break;
        //        }
        //        cooldown -= Time.deltaTime;
        //    } while (cooldown > 0);           
        //}

        ///////////////////////////////////////
        //if (Input.GetKeyDown(KeyCode.D)){
        //    if (dbltapCooldown > 0 && keyDCount == 1)
        //    {
        //        newPosition = 2;
        //    }
        //    else
        //    {
        //        dbltapCooldown = 0.5f;
        //        keyDCount += 1;
        //        //newPosition = 1;
        //    }
        //}
                          
        //if (dbltapCooldown > 0)
        //{
        //    dbltapCooldown -= Time.deltaTime;
        //}
        //else
        //{
            
        //    keyACount = 0;
        //    keyDCount = 0;
        //}




        /////////////////////////
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    //Debug.Log()
        //    //newPosition += ;
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    newPosition += 2;
        //}

        if (platMap.platformQueue.Contains(GM.platformList[positionQueue + newPosition])){
            positionQueue += newPosition;
        }
	}

    void FixedUpdate(){
        currentPlatform = GM.platformList[positionQueue];
        transform.position = currentPlatform.transform.position + new Vector3(0f, .4f, 0f);
    }
}
