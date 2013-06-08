using UnityEngine;
using System.Collections;

public class DetectHover : MonoBehaviour {
	public GameObject shirt;
	Vector3 center;
	// Use this for initialization
	void Start () {
		// First find a center for your bounds.
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider col)
	{
 
	    if (col.gameObject.name == "CollidorTry")
	    {
			
	    }
 
}

}
