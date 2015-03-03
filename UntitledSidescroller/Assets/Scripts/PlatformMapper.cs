using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlatformMapper : MonoBehaviour
{
    /// <summary>
    /// :platformList: List of all the platforms currently in the Camera's view
    /// :CM:           Import CameraMovement as CM to grab Camera's direction
    /// :PM:           Import PlayerMovement as PM to grab Player's positionIndex
    /// </summary>
    public List<GameObject> platformList;
    CameraMovement CM;
    PlayerMovement PM;

    void Start()
    {
        platformList = new List<GameObject>();
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();
        PM = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    void Update()
    {        
    }

    /// <summary>
    /// :Add & Remove:  Public methods which will be used by individual platforms to ADD or REMOVE THEMSELVES to and from the platformList
    ///                 - typically will be called when a platform ENTERS(ADD) or EXITS(REMOVE) the Camera view
    ///                 - Functions will adjust the PLAYER's POSITIONINDEX accordingly when a platform inserts into or removes from the list
    /// </summary>
    public void Add(GameObject platform)
    {       
        platformList.Add(platform);
        if (CM.direction == CameraMovement.Direction.Left || CM.direction == CameraMovement.Direction.Right)
            platformList.Sort(CompareX);
        else if (CM.direction == CameraMovement.Direction.Up || CM.direction == CameraMovement.Direction.Down)
            platformList.Sort(CompareY);
        if (CM.direction == CameraMovement.Direction.Left || CM.direction == CameraMovement.Direction.Up)
        {
            PM.positionIndex += 1;
        }
    }
    public void Remove(GameObject platform)
    {
        if (platformList[PM.positionIndex] == platform)
        {            
            GameManager.gameOver();
        }
        platformList.Remove(platform);
        if (CM.direction == CameraMovement.Direction.Left || CM.direction == CameraMovement.Direction.Right)
            platformList.Sort(CompareX);
        else if (CM.direction == CameraMovement.Direction.Up || CM.direction == CameraMovement.Direction.Down)
            platformList.Sort(CompareY);
        if (CM.direction == CameraMovement.Direction.Right || CM.direction == CameraMovement.Direction.Down)
        {
            PM.positionIndex -= 1;
        }
    }

    /// <summary>
    /// :CompareX & CompareY:  Comparison functions to be used for sorting - either for HORIZONTAL or VERTICAL movement
    /// </summary>
    private static int CompareX(GameObject object1, GameObject object2)
    {
        return object1.transform.position.x.CompareTo(object2.transform.position.x);
    }
    private static int CompareY(GameObject object1, GameObject object2)
    {
        return object2.transform.position.y.CompareTo(object1.transform.position.y);
    }
}









    ///Trash below
        //GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        //if (GM != null){
        //    ///Iterates through the entire list of platforms created in the GameManager script at the start of the game
        //    foreach (GameObject platform in GM.platformList){
        //        /// Grabs the first platforms already in the game screen at the start of the game                
        //        if (-6 <= platform.transform.position.x && platform.transform.position.x <= 6){
        //            platformQueue.Enqueue(platform);
        //        }
        //    }
        //}
       



        //foreach (GameObject platform in platformQueue)
        //{
        //    Debug.Log(platform.transform.position.x);
        //}	

    //public void Enqueue(GameObject platform)
    //{
    //    if (!platformQueue.Contains(platform))
    //    {
    //        platformQueue.Enqueue(platform);
    //        Debug.Log("Enqueued Something");
    //    }
    //}

    //public void Dequeue(GameObject platform)
    //{
    //    if (platformQueue.Contains(platform))
    //    {
    //        platformQueue.Dequeue();
    //        Debug.Log("Dequeued Something");
    //    }
    //}


    //private static int CompareByCoordinates(GameObject object1, GameObject object2, CameraMovement.Direction direction)
    //{
    //    switch (direction)
    //    {
    //        case CameraMovement.Direction.Left:
    //            return object1.transform.position.x.CompareTo(object2.transform.position.x);
    //        case CameraMovement.Direction.Right:
    //            return object1.transform.position.x.CompareTo(object2.transform.position.x);
    //        case CameraMovement.Direction.Up:
    //            return object1.transform.position.y.CompareTo(object2.transform.position.y);
    //        case CameraMovement.Direction.Down:
    //            return object1.transform.position.x.CompareTo(object2.transform.position.x);
    //        default:
    //            return object1.transform.position.x.CompareTo(object2.transform.position.x);
    //    }        
    //}