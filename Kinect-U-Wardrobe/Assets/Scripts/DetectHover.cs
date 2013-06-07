using UnityEngine;
using System.Collections;

public class DetectHover : MonoBehaviour {
	public GameObject shirt;
	Vector3 center;
	Bounds bounds;
	// Use this for initialization
	void Start () {
		// First find a center for your bounds.
		
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log("XXX" + transform.position.x + "YYY" + transform.position.y);
	}
}
