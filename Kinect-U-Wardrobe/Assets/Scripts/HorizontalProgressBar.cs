using UnityEngine;
using System.Collections;
 
public class HorizontalProgressBar : MonoBehaviour {
	
    public float         barDisplay; //current progress
	public float         startTime;
	public static float  progressBarSize;
    public Vector2       position;
    public Vector2       size;
    public Texture2D     emptyTex;
    public Texture2D     fullTex;
	public GUIText       subText;
	public GUIText       mainText;
	
 
	void Start() {
		
		position   = new Vector2 ( (13 * Screen.width)/30, (4 * Screen.height)/5 );
		size       = new Vector2 ( 150, 20 );
		
		emptyTex   = (Texture2D) Resources.Load("white");
		fullTex    = (Texture2D)  Resources.Load("lightgray");
		
		startTime = 0;
		progressBarSize = 0;
		
	}
    void OnGUI() {
		if(SkeletonController.userId!=0){
			GUI.BeginGroup(new Rect(position.x,position.y, size.x, size.y));
	        GUI.DrawTexture(new Rect(0,0, size.x, size.y), emptyTex);
	        GUI.EndGroup();
			
			GUI.BeginGroup(new Rect(position.x,position.y, size.x * barDisplay, size.y));
	        GUI.DrawTexture(new Rect(0,0, size.x, size.y), fullTex);
	        GUI.EndGroup();
		}
    }
 
    void Update() {
		if(SkeletonController.userId!=0){
			startTime = Time.time - SkeletonController.detectTime;
       		barDisplay = startTime*0.2f;
			subText.text = "";
			mainText.text = "Loading...";
			mainText.transform.position = new Vector3(subText.transform.position.x, mainText.transform.position.y);
			
			progressBarSize = size.x * barDisplay;
		}
	}
}