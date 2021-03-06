﻿using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {  
    /// <summary>
    //  DESIGNER VARIABLES
    /// :direction: Direction which the camera will move
    /// :speed:     How fast the camera will move
    /// </summary>
    public enum Direction { Left, Right, Up, Down, UpLeft, UpRight, DownLeft, DownRight };
    public Direction direction;
    public Vector2 speed = new Vector2(0, 0);

 
    /// <summary>
    //  PROGRAMMER VARIABLES
    /// :movement: The speed and direction which the camera will move at
    /// :v2dir:    The direction in terms of a Vector2 - see getDirection() 
    /// </summary>
    private Vector2 movement;
    private Vector2 v2dir;    

    void Update()
    {
        /// Calculates the movement        
        v2dir = getDirection(direction);
        movement = new Vector2(
          speed.x * v2dir.x,
          speed.y * v2dir.y);
    }

    void FixedUpdate()
    {
        /// Applies movement to the rigidbody
        GetComponent<Rigidbody2D>().velocity = movement;
    }

    /// <summary>
    /// Gets moving direction in terms of an (x, y) direction
    /// LEFT = (-1,0) || RIGHT = (1,0) || UP = (0,1) || DOWN = (0,-1)
    /// </summary>     
    public Vector2 getDirection(Direction direction)
    {
        switch (direction)
        {
            case Direction.Left:
                return new Vector2(-1, 0);                
            case Direction.Right:
                return new Vector2(1, 0);                
            case Direction.Up:
                return new Vector2(0, 1);
            case Direction.Down:
                return new Vector2(0, -1);
            case Direction.UpLeft:
                return new Vector2(-1, 1);
            case Direction.UpRight:
                return new Vector2(1, 1);
            case Direction.DownLeft:
                return new Vector2(-1, -1);
            case Direction.DownRight:
                return new Vector2(1, -1);
            default:
                return new Vector2(0, 0);
        }
    }

    public Vector2 getCurrentSpeed()
    {
        return speed;
    }
    public string getCurrentDirection()
    {
        return direction.ToString();
    }

    public Direction stringToDirection(string directionString)
    {
        switch (directionString)
        {
            case "Left":
                return Direction.Left;
            case "Right":
                return Direction.Right;
            case "Up":
                return Direction.Up;
            case "Down":
                return Direction.Down;
            case "UpLeft":
                return Direction.UpLeft;
            case "UpRight":
                return Direction.UpRight;
            case "DownLeft":
                return Direction.DownLeft;
            case "DownRight":
                return Direction.DownRight;
            default:
                return Direction.Right;
        }
    }
}
