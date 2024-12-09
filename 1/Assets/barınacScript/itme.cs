using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itme : MonoBehaviour
{
    // Start is called before the first frame update
    Collider2D[] itici1;
    Collider2D[] itici2;
    bool it;
    GameObject iten;
    void Update()
    {
        it = false;
        itici1 = Physics2D.OverlapCircleAll(transform.position + new Vector3(2f, -0.3f, 0), 0.1f);
        foreach (Collider2D col in itici1)
        {
           if( col.gameObject.tag == "Player")
            {
                it = true;
                iten = col.gameObject;
            }
        }
        itici2 = Physics2D.OverlapCircleAll(transform.position+ new Vector3(-1, -0.3f, 0), 0.1f);
        foreach (Collider2D col in itici2)
        {
            if (col.gameObject.tag == "Player")
            {
                it = true;
                iten = col.gameObject;
            }
        }
        if (it)
            if (iten.transform.position.x > transform.position.x&& Input.GetKey(KeyCode.A))
            {
                transform.Translate(-3 * Time.deltaTime, 0, 0);
            }
            else if(iten.transform.position.x < transform.position.x && Input.GetKey(KeyCode.D)) 
            {
                transform.Translate(3 * Time.deltaTime, 0, 0);
            }
    }
    void OnDrawGizmos()
    {
        // Çizim rengini ayarlama
        Gizmos.color = Color.green;

        // OverlapCircleAll başlangıç konumu ve yarıçapı ile çember çizimi
        Gizmos.DrawWireSphere(transform.position + new Vector3(-1, -0.3f, 0), 0.1f);
        Gizmos.DrawWireSphere(transform.position + new Vector3(2f, -0.3f, 0), 0.1f);
    }
}
