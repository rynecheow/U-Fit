using UnityEngine;
using System.Collections;

public class CircularAnimation : MonoBehaviour {
	GameObject gameObject;
	// Use this for initialization
	void Start () {
	
		gameObject = GameObject.Find("Sphere");
		animation.wrapMode = WrapMode.PingPong;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
}
