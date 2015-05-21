using UnityEngine;
using System.Collections;

public class colorchanger : MonoBehaviour {
	
	Color[] colors=new Color[3];
	// Use this for initialization
	void Start () {
		
		colors [0] = Color.red;
		colors [1] = Color.blue;
		colors [2] = Color.green;
		
	}
	
	// Update is called once per frame
	void OnTriggerEnter(Collider other) {
		//gameObject.GetComponent<Renderer>().material.color = colors [Random.Range (0, ColorSpace.Length)];
		
	}
}
