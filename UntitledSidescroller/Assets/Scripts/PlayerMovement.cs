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
	public enum MOVE{FORWARD, BACK, FARF, FARB, NONE};
	private MOVE moveIt = MOVE.NONE;

	public GameObject currentPlatform;
	private float old_x;
    private Vector3 player_scale;    


	/// <summary>
	/// Sfx player and stuff
	/// </summary>
	public SfxPlayer sfxPlayer;

    void Start()
    {
        player_scale = this.transform.localScale;
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMapper>();
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();        
        transform.position = (currentPlatform).transform.position + new Vector3(0f, .87f, 0f);


		//sfxPlayer = GameObject.Find("Player").GetComponent<SfxPlayer>();
		//sfxPlayer = GetComponentInParent<SfxPlayer> ();
    }

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.Q)){
            moveIt = MOVE.FARB;
        }
        else if (Input.GetKeyDown(KeyCode.E)){
			moveIt = MOVE.FARF;
		}
		else if (CM.direction == CameraMovement.Direction.Left || CM.direction == CameraMovement.Direction.Right ||
            CM.direction == CameraMovement.Direction.UpLeft || CM.direction == CameraMovement.Direction.UpRight ||
            CM.direction == CameraMovement.Direction.DownLeft || CM.direction == CameraMovement.Direction.DownRight){
            if (Input.GetKeyDown(KeyCode.A)){
				moveIt = MOVE.BACK;
			}
			else if (Input.GetKeyDown(KeyCode.D)){
				moveIt = MOVE.FORWARD;
			}        
        }
        else if (CM.direction == CameraMovement.Direction.Up || CM.direction == CameraMovement.Direction.Down){
            if (Input.GetKeyDown(KeyCode.W)){
				moveIt = MOVE.BACK;
			}
			else if (Input.GetKeyDown(KeyCode.S)){
				moveIt = MOVE.FORWARD;
			}   
		}
	}    

    void FixedUpdate()
    {        
		int PI = getPlayerIndex(), platSize = platMap.platformList.Count;

		switch (moveIt)
		{
		case MOVE.BACK:
			if(PI>0)currentPlatform = platMap.platformList[PI-1];
			break;
		case MOVE.FORWARD:
			if(PI<platSize-1)currentPlatform = platMap.platformList[PI+1];
			break;
		case MOVE.FARB:
			currentPlatform = platMap.platformList[0];
			break;
		case MOVE.FARF:
			currentPlatform = platMap.platformList[platSize-1];
			break;
		case MOVE.NONE:
			break;
		}
		
		moveIt = MOVE.NONE;

		if(PI != getPlayerIndex())
			sfxPlayer.PlaySfx("teleport"); //play teleport sound effect


		old_x = this.transform.position.x;
        transform.position = (currentPlatform).transform.position;
        transform.rotation = currentPlatform.transform.rotation;
        if (this.transform.position.x < old_x)
        {                     
            this.transform.localScale = new Vector3(-player_scale.x, player_scale.y, player_scale.z);
        }
        else if (this.transform.position.x > old_x)
        {            
            this.transform.localScale = new Vector3(player_scale.x, player_scale.y, player_scale.z);
        }
    }

	public int getPlayerIndex(){
		return platMap.platformList.IndexOf(currentPlatform);

	}

    void OnBecameInvisible()
    {
        GameManager.gameOver();
    }
}