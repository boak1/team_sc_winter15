using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mirror : MonoBehaviour
{
    static int antiInfLoop = 0;

    public GameObject redLaser;
    public GameObject greenLaser;
    public GameObject blueLaser;

    private LineRenderer redLaserLine;
    private LineRenderer greenLaserLine;
    private LineRenderer blueLaserLine;

    void Start()
    {
        redLaserLine = redLaser.GetComponent<LineRenderer>();
        greenLaserLine = greenLaser.GetComponent<LineRenderer>();
        blueLaserLine = blueLaser.GetComponent<LineRenderer>();
    }

    public void Shoot(Vector3 origin, Vector3 target, string color)
    {
        if (++antiInfLoop > 1000)
            return;
        target = target * 10f;
        origin += (target - origin).normalized * 0.1f;
        Dictionary<LineRenderer, string> resetDict = new Dictionary<LineRenderer, string>{{redLaserLine, "resetRedLaserLine"},
        {greenLaserLine, "resetGreenLaserLine"}, {blueLaserLine, "resetBlueLaserLine"}};
        Dictionary<string, LineRenderer> colorDict = new Dictionary<string, LineRenderer>{{"redLaser", redLaserLine},
        {"greenLaser", greenLaserLine}, {"blueLaser", blueLaserLine}};

        colorDict[color].SetPosition(0, origin);
        colorDict[color].SetPosition(1, target);
        Invoke(resetDict[colorDict[color]], 1f);

        RaycastHit2D[] hits = Physics2D.RaycastAll(origin, target - origin);
        if (hits.Length > 0)
        {
            Debug.Log(hits[0].collider.name);
            colorDict[color].SetPosition(1, hits[0].point);
            if (hits[0].collider.CompareTag("Enemy"))
            {
                Destroy(hits[0].collider.gameObject);
            }
            if (hits[0].collider.CompareTag("Mirror"))
            {
                Vector3 pos = Vector3.Reflect((Vector3)hits[0].point - origin, hits[0].normal);
                hits[0].collider.GetComponent<Mirror>().Shoot((Vector3)hits[0].point, pos, color);
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
