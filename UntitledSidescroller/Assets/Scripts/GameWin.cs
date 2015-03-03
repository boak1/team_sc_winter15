using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {

    public static bool visible = false;

    void OnBecameVisible()
    {
        visible = true;
        Application.LoadLevel("Game Win");
    }
}
