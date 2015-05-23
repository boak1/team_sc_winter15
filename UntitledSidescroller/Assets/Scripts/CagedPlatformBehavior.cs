using UnityEngine;
using System.Collections;

public class CagedPlatformBehavior : MonoBehaviour {
    public GameObject[] walls;
    public float cageLifeTime = 5;
    public bool caged = false;

    private float lifeTime;

    void Start()
    {
        lifeTime = cageLifeTime;

        if (caged)
            addCage();
        else
            removeCage();
    }

    void Update()
    {
        if (isCaged())
        {
            lifeTime -= Time.deltaTime;
            if (lifeTime <= 0.0f)
                removeCage();
        }
        else
            lifeTime = cageLifeTime;
    }
    
    public bool isCaged()
    {
        return caged;
    }

    public void addCage()
    {
        for (int i = 0; i < walls.Length; ++i)
            walls[i].SetActive(true);

        caged = true;
    }

    public void removeCage()
    {
        for (int i = 0; i < walls.Length; ++i)
            walls[i].SetActive(false);

        caged = false;
    }
}
