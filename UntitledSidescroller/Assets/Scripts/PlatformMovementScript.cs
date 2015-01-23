using UnityEngine;
using System.Collections;

public class PlatformMovementScript : MonoBehaviour {
    // 1 - Designer variables

    /// <summary>
    /// Object speed
    /// </summary>
    public Vector2 speed = new Vector2(0, 0);

    /// <summary>
    /// Moving direction
    /// (-1,0) to move LEFT || (1,0) to move RIGHT || (0,1) to move UP || (0,-1) to move DOWN
    /// </summary>
    public Vector2 direction = new Vector2(0, 0);

    private Vector2 movement;

    void Update()
    {
        // 2 - Movement
        movement = new Vector2(
          speed.x * direction.x,
          speed.y * direction.y);
    }

    void FixedUpdate()
    {
        // Apply movement to the rigidbody
        rigidbody2D.velocity = movement;
    }
}
