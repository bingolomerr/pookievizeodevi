using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class kopek : MonoBehaviour
{
   Collider2D hit;
   public bool kaç = false;
   public float neremde;
   public bool stop =false;
    float base_X;

    private void Start()
    {
        base_X = transform.localScale.x;
    }
    private void Update()
    {
        stop = false;
        
        if (pokie.pozisyon.x<transform.position.x)
        {
            neremde = +1;
        }
        else
        {
            neremde = -1;
        }
        if (pokie.köğek_fülütü_true==true)
        {
            kaç = true;
        }
        else
        {
            kaç=false;
        }
        hit= Physics2D.OverlapCircle(transform.position + new Vector3(1.0f* transform.localScale.x, -1.2f, 0), 0.1f);
        //hit = Physics2D.Raycast(transform.position, transform.forward);
        if (hit != null)
        { 
            if(hit.gameObject.tag== "Player")
            {
                
            }
            else
            { 
                if(kaç)
                {
                    stop = true;
                }
                else
                {
                    stop=false;
                    transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
                }
            }
        }
          if(kaç)
          {
            transform.localScale = new Vector3(base_X * neremde, transform.localScale.y, transform.localScale.z);
            if (stop)
            {
                
            }
            else
            {                
                transform.Translate(1.5f * Time.deltaTime * transform.localScale.x, 0, 0);
            }
          }
          else
           {                      
                transform.Translate(1.5f * Time.deltaTime * transform.localScale.x, 0, 0);
           }

           
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if(pokie.kutu== false||pokie.horizontalInput != 0)
            {
                if (pokie.köğek_fülütü_true==false)
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }               
            }            
        }
    }
    private void OnDrawGizmos()
    {
        // Hesaplanan pozisyonu bul
        Vector3 circlePosition = transform.position + new Vector3(1f * transform.localScale.x, -1.2f, 0);

        // Gizmo rengini ayarla
        Gizmos.color = Color.red;

        // Daireyi çiz
        Gizmos.DrawWireSphere(circlePosition, 0.1f);
    }
}
