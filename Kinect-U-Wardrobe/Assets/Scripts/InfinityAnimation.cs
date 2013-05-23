using UnityEngine;
using System.Collections;

public class InfinityAnimation : MonoBehaviour {
	bool hasPlayed = false;
	GameObject target;
	// Use this for initialization
	void Start () {
		target= GameObject.Find("Cube");
	target.animation.wrapMode = WrapMode.PingPong;
	}
	
	// Update is called once per frame
        
        void OnGUI(){
       	if(Event.current.Equals(Event.KeyboardEvent("z")) && hasPlayed)
       	{
          	hasPlayed = false;
          	target.animation.Stop();
       	}	
	}

}
