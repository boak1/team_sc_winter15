using UnityEngine;
using System.Collections;

public class CameraVisibleTurn : MonoBehaviour {
    CameraMovement CM;
    public CameraMovement.Direction newDirection;
    public Vector2 newSpeed = new Vector2(0, 0);

    void Start()
    {
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();
    }

    void OnBecameVisible()
    {
        CM.direction = newDirection;
        CM.speed = newSpeed;
    }
}
