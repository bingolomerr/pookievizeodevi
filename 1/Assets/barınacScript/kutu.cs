using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class kutu : interaction
{
    void Update()
    {
        baseupdate();
    }
    private void LateUpdate()
    {
        baseLateUpdate();
        if(play == true)
        {
            pokie.kutu = true;
            Destroy(gameObject);
            
        }     
    }
}
