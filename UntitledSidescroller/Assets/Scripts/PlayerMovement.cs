using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {
    /// <summary>
    /// :platMap:         Import PlatformMapper as platMap to grab the platformList and the Add() and Remove() methods
    /// :CM:              Import CameraMovement as CM to grab Camera's direction    
    /// :positionIndex:   Index of the platformList that corresponds to the platform the PLAYER is currently on
    /// :currentPlatform: The gameObject representation of the current platform the PLAYER is on
    /// </summary>
    PlatformMapper platMap;
    CameraMovement CM;    
    public int positionIndex = 0;
    GameObject currentPlatform;

    /// <summary>
    //  DOUBLE TAP VARIABLES
    /// :dbltapCooldown:    # of seconds the window for a double tap stays open
    /// :dblTapD & dblTapA: FOR BILLY TO EXPLAIN
    /// :cooldown:          FOR BILLY TO EXPLAIN
    /// </summary>
    float dbltapCooldown = .155f;
    bool dblTapD = false, dblTapA = false;
    float cooldown = -1;

    void Start()
    {
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMapper>();
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();        
        currentPlatform = platMap.platformList[positionIndex];
    }

    void Update()
    {
        int newPosition = 0;
        if (cooldown != -1)
        {
            if (cooldown > 0)
                cooldown -= Time.deltaTime;
            else
            {
                if (dblTapA)
                    newPosition = -1;
                else if(dblTapD)
                    newPosition = 1;

                dblTapD = false;
                dblTapA = false;
                cooldown = -1;
            }
        }


        if (Input.GetKeyDown(KeyCode.Q))
        {
            dblTapA = false;
            dblTapD = false;
            cooldown = -1;

            positionIndex = 0;
        }


        else if (Input.GetKeyDown(KeyCode.E))
        {
            dblTapA = false;
            dblTapD = false;
            cooldown = -1;

            positionIndex = platMap.platformList.Count - 1;
        }


        if (CM.direction == CameraMovement.Direction.Left || CM.direction == CameraMovement.Direction.Right)
        {
            if (Input.GetKeyDown(KeyCode.A) && positionIndex != 0)
            {
                dblTapD = false;

                if (dblTapA && positionIndex > 1)
                {
                    cooldown = -1; newPosition = -2; dblTapA = false;
                }
                else
                {
                    cooldown = dbltapCooldown; dblTapA = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.D) && positionIndex != platMap.platformList.Count - 1)
            {
                dblTapA = false;

                if (dblTapD && positionIndex < platMap.platformList.Count - 2)
                {
                    cooldown = -1; newPosition = 2; dblTapD = false;
                }
                else
                {
                    dblTapD = true; cooldown = dbltapCooldown;
                }
            }        
        }
        else if (CM.direction == CameraMovement.Direction.Up || CM.direction == CameraMovement.Direction.Down)
        {
            if (Input.GetKeyDown(KeyCode.W) && positionIndex != 0)
            {
                dblTapD = false;

                if (dblTapA && positionIndex > 1)
                {
                    cooldown = -1; newPosition = -2; dblTapA = false;
                }
                else
                {
                    cooldown = dbltapCooldown; dblTapA = true;
                }
            }
            else if (Input.GetKeyDown(KeyCode.S) && positionIndex != platMap.platformList.Count - 1)
            {
                dblTapA = false;

                if (dblTapD && positionIndex < platMap.platformList.Count - 2)
                {
                    cooldown = -1; newPosition = 2; dblTapD = false;
                }
                else
                {
                    dblTapD = true; cooldown = dbltapCooldown;
                }
            }   
        }

        positionIndex += newPosition;
        if (positionIndex < 0) { positionIndex = 0; }
        else if (positionIndex > platMap.platformList.Count - 1) { positionIndex = platMap.platformList.Count - 1; }
    }    

    void FixedUpdate()
    {
        currentPlatform = platMap.platformList[positionIndex];
        transform.position = currentPlatform.transform.position + new Vector3(0f, .87f, 0f);
    }

    void OnBecameInvisible()
    {
        GameManager.gameOver();
    }
}



/// Trash below
//    public int positionQueue = 0;
//    GameManager GM;



//    int keyDCount = 0;
//    int keyACount = 0;

//    // Use this for initialization
//    void Start () {
//        GM = GameObject.Find("GameManager").GetComponent<GameManager>();       
//    }

//    // Update is called once per frame
//   

//        //if (Input.GetKeyDown(KeyCode.D) && keyDCount == 0)
//        //{
//        //    //keyDCount += 1;
//        //    newPosition = 1;
//        //    float cooldown = dbltapCooldown;
//        //    do
//        //    {
//        //        if (Input.GetKey(KeyCode.D))
//        //        {
//        //            newPosition = 2;
//        //            break;
//        //        }
//        //        cooldown -= Time.deltaTime;
//        //    } while (cooldown > 0);           
//        //}

//        ///////////////////////////////////////
//        //if (Input.GetKeyDown(KeyCode.D)){
//        //    if (dbltapCooldown > 0 && keyDCount == 1)
//        //    {
//        //        newPosition = 2;
//        //    }
//        //    else
//        //    {
//        //        dbltapCooldown = 0.5f;
//        //        keyDCount += 1;
//        //        //newPosition = 1;
//        //    }
//        //}

//        //if (dbltapCooldown > 0)
//        //{
//        //    dbltapCooldown -= Time.deltaTime;
//        //}
//        //else
//        //{

//        //    keyACount = 0;
//        //    keyDCount = 0;
//        //}




//        /////////////////////////
//        //if (Input.GetKeyDown(KeyCode.W))
//        //{
//        //    //Debug.Log()
//        //    //newPosition += ;
//        //}
//        //if (Input.GetKeyDown(KeyCode.S))
//        //{
//        //    newPosition += 2;
//        //}