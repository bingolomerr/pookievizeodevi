using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fulut : interaction
{
    void Update()
    {
        baseupdate();
    }
    private void LateUpdate()
    {
        baseLateUpdate();
        if (play == true)
        {
            

            Destroy(gameObject);
            pokie.köpek_fülütü = true;
        }
    }
}
