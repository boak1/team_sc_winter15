using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ColoredGlass : MonoBehaviour {
    public enum COLOR { RED, GREEN, BLUE };
    public COLOR glassColor;
    string colorStr;

    public GameObject redLaser;
    public GameObject greenLaser;
    public GameObject blueLaser;

    private LineRenderer redLaserLine;
    private LineRenderer greenLaserLine;
    private LineRenderer blueLaserLine;

	// Use this for initialization
	void Start () {
        redLaserLine = redLaser.GetComponent<LineRenderer>();
        greenLaserLine = greenLaser.GetComponent<LineRenderer>();
        blueLaserLine = blueLaser.GetComponent<LineRenderer>();

        switch (glassColor)
        {
            case COLOR.RED:
                colorStr = "redLaser";
                break;
            case COLOR.GREEN:
                colorStr = "greenLaser";
                break;
            case COLOR.BLUE:
                colorStr = "blueLaser";
                break;
        }
	}
	
	// Update is called once per frame
    public void Shoot(Vector3 origin, Vector3 target)
    {
        //target = target * 10f;
        origin += (target - origin).normalized * 0.1f;
        Dictionary<LineRenderer, string> resetDict = new Dictionary<LineRenderer, string>{{redLaserLine, "resetRedLaserLine"},
        {greenLaserLine, "resetGreenLaserLine"}, {blueLaserLine, "resetBlueLaserLine"}};
        Dictionary<string, LineRenderer> colorDict = new Dictionary<string, LineRenderer>{{"redLaser", redLaserLine},
        {"greenLaser", greenLaserLine}, {"blueLaser", blueLaserLine}};

        colorDict[colorStr].SetPosition(0, origin);
        colorDict[colorStr].SetPosition(1, target);
        Invoke(resetDict[colorDict[colorStr]], 1f);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, target - origin);
        if (hits.Length > 0)
        {
            colorDict[colorStr].SetPosition(1, hits[0].point);
            if (hits[0].collider.CompareTag("Enemy"))
            {
                hits[0].collider.gameObject.GetComponentInParent<EnemyPreferences>().tookDamage();
            }
            else if (hits[0].collider.CompareTag("Mirror"))
            {
                Vector3 pos = Vector3.Reflect((Vector3)hits[0].point - origin, hits[0].normal);
                hits[0].collider.GetComponent<Mirror>().Shoot((Vector3)hits[0].point, pos, colorStr);
            }
            else if (hits[0].collider.CompareTag("Glass"))
            {
                hits[0].collider.GetComponent<ColoredGlass>().Shoot(hits[0].point, target);
            }
            else if (hits[0].collider.CompareTag("Button"))
            {
                hits[0].collider.GetComponentInParent<CagedPlatformButtonBehavior>().toggleButton();
            }
        }
    }

    void resetRedLaserLine()
    {
        redLaserLine.SetVertexCount(2);
        redLaserLine.SetPosition(0, new Vector3(0, 0, 0));
        redLaserLine.SetPosition(1, new Vector3(0, 0, 0));
    }
    void resetGreenLaserLine()
    {
        greenLaserLine.SetVertexCount(2);
        greenLaserLine.SetPosition(0, new Vector3(0, 0, 0));
        greenLaserLine.SetPosition(1, new Vector3(0, 0, 0));
    }
    void resetBlueLaserLine()
    {
        blueLaserLine.SetVertexCount(2);
        blueLaserLine.SetPosition(0, new Vector3(0, 0, 0));
        blueLaserLine.SetPosition(1, new Vector3(0, 0, 0));
    }
}
