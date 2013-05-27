using UnityEngine;
using System.Collections;
 
public class HorizontalProgressBar : MonoBehaviour {
    public float barDisplay; //current progress
    public Vector2 pos;
    public Vector2 size;
    public Texture2D emptyTex;
    public Texture2D fullTex;
 
	void Start() {
		
//		Texture2D texture = new Texture2D(150, 20);
//        emptyTex = texture;
//		fullTex = texture;
//		
//        int y = 0;
//        while (y < texture.height) {
//            int x = 0;
//            while (x < texture.width) {
//                Color color = Color.blue;
//                texture.SetPixel(x, y, color);
//                ++x;
//            }
//            ++y;
//        }
//        texture.Apply();

		pos = new Vector2(Screen.width/2,Screen.height*4/5);
		size  = new Vector2(150,20);
		Debug.Log(pos);
	}
    void OnGUI() {
       //draw the background:
       GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
         GUI.Box(new Rect(0,0, size.x, size.y), emptyTex);
 
         //draw the filled-in part:
         GUI.BeginGroup(new Rect(0,0, size.x * barDisplay, size.y));
          GUI.Box(new Rect(0,0, size.x, size.y), fullTex);
         GUI.EndGroup();
       GUI.EndGroup();
    }
 
    void Update() {
       //for this example, the bar display is linked to the current time,
       //however you would set this value based on your desired display
       //eg, the loading progress, the player's health, or whatever.
       barDisplay = Time.time*0.05f;
//   barDisplay = MyControlScript.staticHealth;
    }

}