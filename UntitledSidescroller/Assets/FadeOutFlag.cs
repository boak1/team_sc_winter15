using UnityEngine;
using System.Collections;

public class FadeOutFlag : MonoBehaviour {
    private BgmPlayer bgmPlayer;

	// Use this for initialization
	void Start () {
        bgmPlayer = GameObject.Find("BgmPlayer").GetComponent<BgmPlayer>();
	}
	
	// Update is called once per frame
	void OnBecameVisible () {
        bgmPlayer.FadeOut();
	}

}
