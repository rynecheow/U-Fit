using UnityEngine;
using System.Collections;

public class AspectCorrection : MonoBehaviour
{
    public float m_NativeRatio = Screen.width/Screen.height;
 
    void Start ()
    {
        float currentRatio = (float)Screen.width / (float)Screen.height;
        Vector3 scale = transform.localScale;
        scale.x *= m_NativeRatio / currentRatio;
        transform.localScale = scale;
    }
 
}


