using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
public class cam : MonoBehaviour
{
    public GameObject camleft;
    public GameObject camright;
    RaycastHit2D raycastHit1;
    RaycastHit2D raycastHit2;
    bool rotateleft = false;
    float currentZ;
    void Update()
    {
        currentZ = transform.eulerAngles.z;
        raycastHit1 = Physics2D.Raycast(camright.transform.position, camright.transform.right);
        raycastHit2 = Physics2D.Raycast(camleft.transform.position, camleft.transform.right );
        if ((raycastHit1.collider != null && raycastHit1.collider.gameObject.tag == "Player") ||
            (raycastHit2.collider != null && raycastHit2.collider.gameObject.tag == "Player"))
        {
            if (pokie.kutu == false)
            {
                Debug.Log("kutu giğ");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);


            }
            else if(Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
            {
                Debug.Log("hareket etme");
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
        
        if (rotateleft)
        {
            transform.Rotate(0, 0, -25 * Time.deltaTime);
            if (currentZ < 130)
            {
                rotateleft = false;
            }
        }
        else
        {
            transform.Rotate(0, 0, 25 * Time.deltaTime);
            if (currentZ > 230)
            {
                rotateleft = true;
            }
        }
    }
    void OnDrawGizmos()
    {
        // Işınlar için çizim rengi
        Gizmos.color = Color.red;
        // Sağ kamera için ışın çizimi
        if (camright != null)
        {
            Gizmos.DrawLine(camright.transform.position, camright.transform.position + camright.transform.right * 100);
        }
        // Sol kamera için ışın çizimi
        if (camleft != null)
        {
            Gizmos.DrawLine(camleft.transform.position, camleft.transform.position + camleft.transform.right * 100);
        }
    }
}
