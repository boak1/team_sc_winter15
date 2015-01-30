using UnityEngine;
using System.Collections;

public class PlayerMovementScript : MonoBehaviour {
    public int positionQueue = 0;
    GameObject currentPlatform;
    GameManager GM;
    PlatformMappingScript platMap;

    float dbltapCooldown = .155f;
    int keyDCount = 0;
    int keyACount = 0;
	bool dblTapD = false, dblTapA = false;
	float cooldown = -1;
	// Use this for initialization
	void Start () {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();       
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMappingScript>();
        currentPlatform = GM.platformList[positionQueue];
	}
	
	// Update is called once per frame
	void Update () {       

		int newPosition = 0;


		if (cooldown != -1) {
			if (cooldown > 0)
				cooldown -= Time.deltaTime;
			else {
				if (dblTapA)
					newPosition = -1;
				else
					newPosition = 1;

					dblTapD = false;
					dblTapA = false;
					cooldown = -1;
			}
		}


		 if (Input.GetKeyDown (KeyCode.Q)) {
			dblTapA = false;
			dblTapD = false;
			cooldown = -1;
			
			positionQueue = 0;
		}


		else if (Input.GetKeyDown (KeyCode.E)) {
			dblTapA = false;
			dblTapD = false;
			cooldown = -1;

			positionQueue = platMap.platformQueue.Count - 1;
				}



        else if (Input.GetKeyDown(KeyCode.A) && positionQueue != 0){
			dblTapD = false;
			
			if(dblTapA)
			{
				cooldown = -1;
				newPosition = -2;
				dblTapA = false;
			}
			else{
				cooldown = dbltapCooldown;
				dblTapA = true;   
			}
        }

        else if (Input.GetKeyDown(KeyCode.D))
        {
			dblTapA = false;

            if (dblTapD)
            {
				cooldown = -1;
                newPosition = 2;
                dblTapD = false;

            }
            else{
                dblTapD = true;
				cooldown = dbltapCooldown;
			}
        }

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
