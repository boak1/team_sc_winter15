using UnityEngine;
using System.Collections;

public class PlatformMovement : MonoBehaviour {
    /// <summary>
    /// :platMap:  Import PlatformMapper as platMap to grab the platformList and the Add() and Remove() methods
    /// </summary>
    PlatformMapper platMap;

    void Start()
    {
        platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMapper>();
    }


    /// <summary>
    /// :Visible & Invisible:  ADDs or REMOVEs the platform to the platformList when this platform ENTERS or EXITS the Camera view
    ///                        -  !!!CAUTION!!!  THIS WILL NOT WORK IN THE EDITOR IF THE SCENE VIEW HAS EYES ON THE PLATFORM
    /// </summary>
    void OnBecameVisible()
    {
        platMap.Add(this.gameObject);        
    }
    void OnBecameInvisible()
    {
        platMap.Remove(this.gameObject);
    }
}



    /// Trash below
    //// 1 - Designer variables

    ///// <summary>
    ///// Object speed
    ///// </summary>
    //public Vector2 speed = new Vector2(0, 0);

    ///// <summary>
    ///// Moving direction
    ///// (-1,0) to move LEFT || (1,0) to move RIGHT || (0,1) to move UP || (0,-1) to move DOWN
    ///// </summary>
    //public Vector2 direction = new Vector2(0, 0);


    ///// <summary>
    ///// Variables for programmers
    ///// </summary>
    //private Vector2 movement;
    //PlatformMappingScript platMap;

    //void Start()
    //{
    //    platMap = GameObject.Find("PlatformMapper").GetComponent<PlatformMappingScript>();       
    //}

    //void Update()
    //{
    //    // 2 - Movement
    //    movement = new Vector2(
    //      speed.x * direction.x,
    //      speed.y * direction.y);

    //    //if (-6 <= transform.position.x && transform.position.x <= 6)
    //    //{
    //    //    platMap.Enqueue(this.gameObject);
    //    //}

    //    //if (transform.position.x < -6 || transform.position.x > 6)
    //    //{
    //    //    platMap.Dequeue(this.gameObject);
    //    //}
    //}

    //void FixedUpdate()
    //{
    //    // Apply movement to the rigidbody
    //    rigidbody2D.velocity = movement;
    //}

    //void OnBecameVisible()
    //{
    //    platMap.Enqueue(this.gameObject);
    //}

    //void OnBecameInvisible()
    //{
    //    platMap.Dequeue(this.gameObject);
    //}