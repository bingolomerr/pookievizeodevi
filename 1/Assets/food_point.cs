using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class food_point : interaction
{
    // Start is called before the first frame update
    bool food =true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        baseupdate();
    }
    private void LateUpdate()
    {
        baseLateUpdate();
        if (play == true)
        {
            if(food == true)
            {
                pokie.açlık = 200f;
                food = false;
            }
                   
        }
    }
}
