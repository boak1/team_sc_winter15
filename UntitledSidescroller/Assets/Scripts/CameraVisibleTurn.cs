using UnityEngine;
using System.Collections;

public class CameraVisibleTurn : MonoBehaviour {
    CameraMovement CM;
    public CameraMovement.Direction newDirection;

    void Start()
    {
        CM = GameObject.Find("CameraMovement").GetComponent<CameraMovement>();
    }

    void OnBecameVisible()
    {
        CM.direction = newDirection;
    }
}
