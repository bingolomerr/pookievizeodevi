using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trafic_maneger : MonoBehaviour
{
    public static bool green;
    float time;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time < 10)
        {
        green = true; 
        }
        else if(time < 20)
        {
            green = false;
        }
        else
        {
            time = 0;
        }         
    }
}
