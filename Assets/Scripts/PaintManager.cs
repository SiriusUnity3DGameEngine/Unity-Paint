using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintManager : MonoBehaviour {

	public GameObject baseDot;
	public KeyCode mouseLeft;
	public string toolType = "pencil";
	public int timeCount = 0;
	public LayerMask layerMask;

	public List<GameObject> dotList = new List<GameObject>();


    #region Singleton Initialize

    private static PaintManager sInstance;

    public static PaintManager Instance
    {
        get
        {
            if (sInstance == null)
            {
                GameObject newGameObject = new GameObject("_PaintManager");
                sInstance = newGameObject.AddComponent<PaintManager>();
            }

            return sInstance;
        }
    }

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void OnDestroy()
    {
    }

    #endregion


    // Use this for initialization
    void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = new Vector3 (Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
		Vector2 objPosition = Camera.main.ScreenToWorldPoint (mousePosition);

		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);

		RaycastHit2D hit = Physics2D.GetRayIntersection (ray, Mathf.Infinity);

		if (hit.collider != null && hit.collider.tag == "drawing") {
			if (toolType == "pencil") {

				if (Input.GetMouseButtonDown (0)) {
					GameObject dot = Instantiate (baseDot, objPosition, baseDot.transform.rotation ) as GameObject;
					dotList.Add (dot);
					timeCount++;
					dotCtrl.time += timeCount;

				}
			}
		}



		if (toolType == "eraser") {
			


		}
	}
}
