using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class toolCtrl : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void pencil()
	{
		PaintManager.Instance.toolType = "pencil";
		Drawline.lineColor = Color.black;
		Debug.Log (PaintManager.Instance.toolType);
	}


	public void eraser()
	{
		//GM.toolType = "eraser";
		int lastDot = PaintManager.Instance.dotList.Count - 1;
		if (lastDot > -1) {
			DestroyObject (PaintManager.Instance.dotList [lastDot]);
            PaintManager.Instance.dotList.RemoveAt (lastDot);
		}
		Debug.Log ("컨트롤제트");
	}

	public void clear()
	{
		for (int i = 0; i < PaintManager.Instance.dotList.Count; i++) {
			DestroyObject (PaintManager.Instance.dotList [i]);
		}

        PaintManager.Instance.dotList.Clear ();
		Debug.Log ("전체지우기");
	}

//	void OnMouseDown()
//	{
//
//		if (gameObject.name == "eraser") {
//			paintGM.toolType = "eraser";
//		}
//
//		if (gameObject.name == "pencil") {
//			
//		}
//
//		if (gameObject.name == "sizeUp") {
//			paintGM.currentScale += 0.001f;
//		}
//	}
}
