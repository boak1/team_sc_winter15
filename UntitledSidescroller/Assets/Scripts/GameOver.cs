using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(PlayerPrefs.GetInt("CheckpointCounter"));
            Application.LoadLevel(PlayerPrefs.GetInt("CurrentLevel"));
        }

    }

}
