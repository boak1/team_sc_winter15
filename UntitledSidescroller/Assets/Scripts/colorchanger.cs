//using UnityEngine;
//using System.Collections;
//using System.Collections.Generic;
//
//public class colorchanger : MonoBehaviour {
//	
//	public List<GameObject> coloredStuff = new List<GameObject>();
//	private List<GameObject> targets = new List<GameObject> ();
//	ShootingScript SS;
//	public float colorTimerInit = 5f;
//	private float colorTimer;
//	private int r;
//
//	// Use this for initialization
//	void Start () {
//		SS = GameObject.Find("PlayerShooting").GetComponent<ShootingScript>();	
//		colorTimer = colorTimerInit;
//		while(targets.Count <3)
//		{
//			r = Random.Range(0,4);
//			if (r==1 && SS.redTarget == null)
//			{
//				targets.append(SS.redTarget );
//			}
//			if (r==2 && SS.greenTarget == null)
//			{
//				targets.append(SS.greenTarget);
//			}
//			if (r==3 && SS.blueTarget == null)
//			{
//				targets.append(SS.blueTarget)
//			}
//		}
//		
//	}
//}
//
//
//
//	Global list of targets = LOT
//		__________________________
//			Randomize  LOT
//			If list.count >=3
//			3count = 3;
//	Else
//		3count = list.count
//		For(int x = 0, x <3; x++){
//			if LOT[x] within colored list || null{
//				3count--;
//				If LOT[x] != null
//					Change LOT[x] current occupant to neutral(sprite/color)
//				While(true){
//					Get new random object from colored list
//						If new object isn’t a target make it LOT[x] and change color then break
//							Else redo choice
//				}
//			}
//			If 3count <=0;
//			Break;
//		}

	
//	void Update()
//	{
//		colorTimer -= Time.deltaTime;
//		if (colorTimer <= 0) 
//		{
//			changeColor();
//			colorTimer = colorTimerInit;
//		}
//	}
//	void changeColor()
//	{
//		if (coloredStuff.Contains(SS.redTarget))
//			SS.redTarget =null;
//		if (coloredStuff.Contains(SS.blueTarget))
//			SS.blueTarget = null;
//		if (coloredStuff.Contains(SS.greenTarget))
//			SS.greenTarget = null;
//		for(int x = 0; x < coloredStuff.Count; x++)
//		if (coloredStuff.Count == 1) {
//
//		
//		//else if (coloredStuff.Count == 2) {
//			
//		} 
//		else {
//			int r1 = Random.Range(0,coloredStuff.Count+1);
//			int r2 = Random.Range(0,coloredStuff.Count+1);
//			int r3 = Random.Range(0,coloredStuff.Count+1);
//			while (r1==r2)
//			 r2 = Random.Range(0,coloredStuff.Count+1);
//			while(r2==r3)
//				r3 = Random.Range(0,coloredStuff.Count+1);
//			GameObject first = coloredStuff[r1];
//			//GameObject second = coloredStuff[r2];
//
//		}
//	}
//
//}
