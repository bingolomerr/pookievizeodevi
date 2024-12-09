using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class pokie : MonoBehaviour
    {
    public static Vector3 pozisyon;
    public  GameObject inter_logo;
    public static GameObject E_logo;
    public static bool Key = false;
    public GameObject kutumspawn;
    public GameObject kutum;
    public GameObject fulut;
    public static bool kutu =false;
    Animator animator;
    public static float açlık= 200f;
    public bool acıkma;
    public Image hungaryImage;
    public Image staminaImage;
    public float speed = 5f;
    bool facingSağ = true;
    Rigidbody2D rb;
    public static float horizontalInput;
    public static bool diolog = false;
    public static bool köpek_fülütü ;
    public static bool köğek_fülütü_true ;
    public float stamina = 10;
    float stamina_end=1;
    bool stamina_0 =false;
    AudioSource audioSource;
    public AudioClip[] miyav;

    private void Start()
        {
        açlık = 200;
        audioSource =GetComponent<AudioSource>();
        pozisyon = transform.position;
        animator = GetComponent<Animator>();
        kutu =false;
        E_logo = inter_logo;
        Key = false;
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;        
        }
        private void Update()
        {
        //if (Input.GetKey(KeyCode.E))
        //{

        //audioSource.clip = miyav[UnityEngine.Random.Range(0,miyav.Length)];
        //audioSource.Play();
        //}

        if (köpek_fülütü)
        {
            if(Input.GetKey(KeyCode.F)&&stamina>0)
            {
                köğek_fülütü_true= true;
                stamina -= Time.deltaTime;
                
            }
            else
            {
                köğek_fülütü_true = false;
                if (stamina < 0)
                {
                    stamina_0= true;
                    stamina = 0;
                    stamina_end = 0;
                }
                               
            }
            
        }
        if (acıkma)
        {
            if(köğek_fülütü_true == false && stamina_end>2.4f)
            {
                stamina += Time.deltaTime;
            }           
            açlık -= Time.deltaTime;
            if(açlık < 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                açlık = 200;          
            }
            hungaryImage.transform.localScale = new Vector3(açlık / 200f, 1, 1);
            staminaImage.transform.localScale = new Vector3(stamina / 10f, 1, 1);
        }
        if (kutu)
        {
            kutum.GetComponent<SpriteRenderer>().enabled = true;
            if (Input.GetKeyDown(KeyCode.E))
            {
                kutu = false;
                Instantiate(kutumspawn,transform.position+new Vector3(-4f* transform.localScale.x, 0,0),transform.rotation);
            }
        }
        else
        {
            kutum.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (!diolog)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            if (horizontalInput != 0)
            {
                animator.SetBool("Run", true);
            }
            else
            {
                animator.SetBool("Run", false);
            }
            rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rb.AddForce(new Vector2(0, 400));
            }
            if (horizontalInput < 0 && facingSağ)
            {
                Flip();
            }
            else if (horizontalInput > 0 && !facingSağ)
            {
                Flip();
            }
        }

   }

        private void Flip()
        {        
        facingSağ = !facingSağ;
            Vector3 scale = transform.localScale;
            scale.x *= -1;
            transform.localScale = scale;
            E_logo.transform.localScale = new Vector3(E_logo.transform.localScale.x * -1,0.5f,1);
        }
    private void LateUpdate()
    {
        pozisyon= transform.position;
        stamina_end += Time.deltaTime;
        if (stamina_end > 2.5f)
        {
            stamina_end = 2.5f;
            stamina_0 =false;
        }
        if (stamina > 10)
        {
            stamina = 10;
        }
        if (köğek_fülütü_true)
        {
            fulut.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            fulut.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
    public static void e_logo(bool inter)
    {
        if(E_logo != null) 
        if (inter == true)
        {
            E_logo.GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            E_logo.GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}

