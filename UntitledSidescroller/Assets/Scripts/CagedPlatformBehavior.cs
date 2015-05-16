using UnityEngine;
using System.Collections;

public class CagedPlatformBehavior : MonoBehaviour {
    public GameObject[] walls;

    public bool caged = false;

    void Start()
    {
        if (caged)
            addCage();
        else
            removeCage();
    }
    
    public bool isCaged()
    {
        return caged;
    }

    public void addCage()
    {
        Debug.Log("addCage");
        for (int i = 0; i < walls.Length; ++i)
            walls[i].SetActive(true);

        caged = true;
    }

    public void removeCage()
    {
        Debug.Log("remCage");
        for (int i = 0; i < walls.Length; ++i)
            walls[i].SetActive(false);

        caged = false;
    }
}
