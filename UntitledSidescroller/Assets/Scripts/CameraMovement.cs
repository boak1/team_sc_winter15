using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {  
    /// <summary>
    //  DESIGNER VARIABLES
    /// :direction: Direction which the camera will move
    /// :speed:     How fast the camera will move
    /// </summary>
    public enum Direction { Left, Right, Up, Down };
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
        rigidbody2D.velocity = movement;
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
            default:
                return new Vector2(0, 0);
        }
    }
}
