using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drawline : MonoBehaviour {


	private LineRenderer line;

	public List<Vector3> pointList;
	private Vector3 mousePos;
	public static Color lineColor = Color.black;

	struct myLine
	{
		public Vector3 StartPoint;
		public Vector3 EndPoint;
	}

	void Awake()
	{
		line = gameObject.AddComponent<LineRenderer> ();
		line.material = new Material (Shader.Find("Sprites/Default"));//Shader.Find ("Particles/Additive")
		line.SetVertexCount (0);
		line.SetWidth (0.1f, 0.1f);
		line.SetColors (lineColor, lineColor);
		line.useWorldSpace = true;

		pointList = new List<Vector3> ();
	}

	void Update () {
		if (Input.GetMouseButtonDown (0)) {

			line.SetVertexCount (0);
			pointList.RemoveRange (0, pointList.Count);
			line.SetColors (lineColor, lineColor);
		}
		if (Input.GetMouseButtonUp (0)) {
			gameObject.GetComponent<Drawline> ().enabled = false;
		}
		if (Input.GetMouseButton(0)) {
			mousePos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			mousePos.z = 0;
			if(!pointList.Contains(mousePos)){
				pointList.Add (mousePos);
				line.SetVertexCount (pointList.Count);
				line.SetPosition (pointList.Count - 1, (Vector3)pointList [pointList.Count - 1]);
			}
		}
	}
}