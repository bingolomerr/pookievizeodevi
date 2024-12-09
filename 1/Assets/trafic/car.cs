using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class car : MonoBehaviour
{
    // Start is called before the first frame update
    public float min_scale;
    public float max_scale;
    public float death_scale;
    public GameObject[] cars;
    bool blood;

   
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (trafic_maneger.green)
        {
            transform.localScale = transform.localScale * (1 + (Time.deltaTime / 3.5f));
            if (transform.localScale.x > death_scale)
            {
                blood = true;                
            }
            else
            {
                blood= false;
            }
            if (transform.localScale.x > max_scale)
            {
                Instantiate(cars[cars.Length-1],transform.position,transform.rotation);
                Destroy(gameObject);
            }
        }
        else
        {
            blood = false;
            if(transform.localScale.x>max_scale)
            {
            }
            else
            {
                transform.localScale = transform.localScale * (1 + (Time.deltaTime/3.5f));
            }   
        }
    }  
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (blood)
        {
            if (collision.gameObject.tag == "Player")
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }

    }
}
