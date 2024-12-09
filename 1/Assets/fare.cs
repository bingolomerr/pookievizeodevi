using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fare : MonoBehaviour
{
    Collider2D hit;
    private void Update()
    {
        hit = Physics2D.OverlapCircle(transform.position + new Vector3(3f * transform.localScale.x, 0.3f, 0), 0.1f);
        //hit = Physics2D.Raycast(transform.position, transform.forward);
        if (hit != null)
        {
            if (hit.gameObject.tag == "Player")
            {

            }
            else
            {
                transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            }
        }

        transform.Translate(15 * Time.deltaTime * transform.localScale.x, 0, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            pokie.açlık = 200;
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        // Hesaplanan pozisyonu bul
        Vector3 circlePosition = transform.position + new Vector3(3f * transform.localScale.x, 0.3f, 0);

        // Gizmo rengini ayarla
        Gizmos.color = Color.red;

        // Daireyi çiz
        Gizmos.DrawWireSphere(circlePosition, 0.1f);
    }
}
