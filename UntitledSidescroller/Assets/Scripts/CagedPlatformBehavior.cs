using UnityEngine;
using System.Collections;

public class CagedPlatformBehavior : MonoBehaviour {
    public GameObject[] walls;

    public void addCage()
    {
        for (int i = 0; i < walls.Length; ++i)
            walls[i].SetActive(true);
    }

    public void removeCage()
    {
        for (int i = 0; i < walls.Length; ++i)
            walls[i].SetActive(false);
    }
}
