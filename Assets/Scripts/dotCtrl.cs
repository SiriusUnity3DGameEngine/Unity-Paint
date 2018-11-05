using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dotCtrl : MonoBehaviour {

	public static int time = 0;

	static bool del = false;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (del == true) {
			if (time == PaintManager.Instance.timeCount) {
				Destroy (gameObject);
				del = false;
			} else {
				del = false;
			}
		}
	}

	public static void delLine(){
		del = true;
	}

	void OnMouseOver()
	{
		//if (GM.toolType == "eraser")
			
	}
}
