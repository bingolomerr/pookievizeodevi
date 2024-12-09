
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class interaction : MonoBehaviour
{
    // Start is called before the first frame update
    public bool active =false;
    public bool play = false;
    public void baseupdate()
    {     
        active = false;
      //pokie.inter = false;
        pokie.e_logo(false);
    }
    public void baseLateUpdate()
    {
        
        Collider2D[] intercol = Physics2D.OverlapCircleAll(transform.position, 1f);
        foreach (Collider2D col in intercol)
        {
            if (col.gameObject.tag == "Player")
            {                
                active = true;               
            }
        }

        if (active)
        {
            pokie.e_logo(true);
            //pokie.inter=true;
            if (Input.GetKeyUp(KeyCode.E))
            {
                play = true;
            }
        }
        
    }
}
