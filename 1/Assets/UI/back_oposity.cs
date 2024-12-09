using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class back_oposity : MonoBehaviour
{
    GameObject[] back;
    SpriteRenderer backRenderer;
    Color backColor;
    public float arka=255;
    public float rgb =1f;
   
    void Start()
    {
        int childCount = transform.childCount;
        back = new GameObject[childCount];
        for (int i = 0; i < childCount; i++)
        {
            back[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in back)
        {
            backRenderer = go.GetComponent<SpriteRenderer>();
            backColor = backRenderer.color;
            backColor.a = arka / 255f;
            backColor.r = rgb;
            backColor.g = rgb;
            backColor.b = rgb;
            backRenderer.color = backColor;
            


            //go.GetComponent<SpriteRenderer>().color = backColor;
        }
    }
}
