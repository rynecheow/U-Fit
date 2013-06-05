using UnityEngine;
using System.Collections;
 
public class HorizontalProgressBar : MonoBehaviour {

   #region Variable declaration
   public float                     loadingDuration; //current progress
	public float                     m_time_start;
	public static float              progressBarSize;
   public Vector2                   v_position;
   public Vector2                   v_dimension;
   public Texture2D                 startTexture;
   public Texture2D                 stopTexture;
	public GUIText                   subText;
	public GUIText                   mainText;
   public static readonly float     POS_X_FACTOR        = 13.0f / 30.0f;
   public static readonly float     POS_Y_FACTOR        = 4.0f / 5.0f;
   public static readonly float     DIM_WIDTH           = 150.0f;
   public static readonly float     DIM_HEIGHT          = 20.0f;
	#endregion

   #region MonoBehavior
	void Start() {
		v_position        = new Vector2 ( POS_X_FACTOR * Screen.width, POS_Y_FACTOR * Screen.height );
		v_dimension       = new Vector2 ( DIM_WIDTH, DIM_HEIGHT );
		
		startTexture      = (Texture2D) Resources.Load("white");
		stopTexture       = (Texture2D) Resources.Load("lightgray");
		
		m_time_start      = 0;
		progressBarSize   = 0;
		
	}

   void OnGUI() {
      if(SkeletonController.userId!=0){
         GUI.BeginGroup(new Rect(v_position.x,v_position.y, v_dimension.x, v_dimension.y));
         GUI.DrawTexture(new Rect(0.0f, 0.0f, v_dimension.x, v_dimension.y), startTexture);
         GUI.EndGroup();
			
         GUI.BeginGroup(new Rect(v_position.x,v_position.y, v_dimension.x * loadingDuration, v_dimension.y));
         GUI.DrawTexture(new Rect(0.0f, 0.0f, v_dimension.x, v_dimension.y), stopTexture);
         GUI.EndGroup();
      }
   }
 
   void Update() {
      if(SkeletonController.userId!=0){
         m_time_start                  = Time.time - SkeletonController.detectTime;
       	loadingDuration               = m_time_start * 0.2f;
			subText.text                  = @"";
			mainText.text                 = @"Loading...";
			mainText.transform.position   = new Vector3(subText.transform.position.x, mainText.transform.position.y);
			progressBarSize               = v_dimension.x * loadingDuration;
      }
   }
   #endregion
}