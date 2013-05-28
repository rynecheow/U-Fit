using UnityEngine;
using System.Collections;
 
public class HorizontalProgressBar : MonoBehaviour {
    public float barDisplay; //current progress
    public Vector2 pos;
    public Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;
	public float startTime;
	public GUIText subText;
	public GUIText mainText;
	public static float progressBarSize;
 
	void Start() {
		
		pos = new Vector2(Screen.width/3 + Screen.width/10,Screen.height*4/5);
		size  = new Vector2(150,20);
		
		emptyTex =(Texture2D) Resources.Load("white");
		fullTex =(Texture2D)  Resources.Load("lightgray");
		
		startTime = 0;
		progressBarSize = 0;
		
	}
    void OnGUI() {
		
		if(SkeletonController.userId!=0)
		{
			GUI.BeginGroup(new Rect(pos.x,pos.y, size.x, size.y));
	        GUI.DrawTexture(new Rect(0,0, size.x, size.y), emptyTex);
	        GUI.EndGroup();
			
			GUI.BeginGroup(new Rect(pos.x,pos.y, size.x * barDisplay, size.y));
	        GUI.DrawTexture(new Rect(0,0, size.x, size.y), fullTex);
	        GUI.EndGroup();
		
		}
    }
 
    void Update() {
		if(SkeletonController.userId!=0)
		{
			startTime = Time.time - SkeletonController.detectTime;
       		barDisplay = startTime*0.2f;
			subText.text = "";
			mainText.text = "Loading...";
			mainText.transform.position = new Vector3(subText.transform.position.x, mainText.transform
				.position.y);
			
			progressBarSize = size.x * barDisplay;
		}
		
	}
	
}