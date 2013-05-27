using UnityEngine;
using System.Collections;
 
public class HorizontalProgressBar : MonoBehaviour {
    public float barDisplay; //current progress
    public Vector2 pos;
    public Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;
 
	void Start() {
		
		pos = new Vector2(Screen.width/2,Screen.height*4/5);
		size  = new Vector2(150,20);
		
//		emptyTex = new Texture2D(300,20);
//		fullTex = new Texture2D(300,20);
		
		emptyTex =(Texture2D) Resources.Load("white");
		fullTex =(Texture2D)  Resources.Load("blue");

		Debug.Log(pos);
	}
    void OnGUI() {
		GUI.BeginGroup(new Rect(pos.x,pos.y, size.x, size.y));
        GUI.DrawTexture(new Rect(0,0, size.x, size.y), emptyTex);
        GUI.EndGroup();
		
		GUI.BeginGroup(new Rect(pos.x,pos.y, size.x * barDisplay, size.y));
        GUI.DrawTexture(new Rect(0,0, size.x, size.y), fullTex);
        GUI.EndGroup();
    }
 
    void Update() {
       	//for this example, the bar display is linked to the current time,
       	//however you would set this value based on your desired display
       	//eg, the loading progress, the player's health, or whatever.
		
       	barDisplay = Time.time*0.05f;
	   	if(size.x * barDisplay >150)
		{
			Time.time = 0;
		}
		
	//   barDisplay = MyControlScript.staticHealth;
    }

}