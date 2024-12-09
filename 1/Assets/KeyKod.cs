using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class KeyInteraction : MonoBehaviour
 {
    private void OnTriggerEnter2D(Collider2D collision)
    {       
            if (collision.gameObject.CompareTag("Player"))
            {
                pokie.Key = true;
                Destroy(gameObject);
            }
    }        
 }

