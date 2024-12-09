using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class diyolog : interaction
{
    public scriptblediyalog[] diyalogs;
    int i = 0;
    public GameObject Canvas;
    public Text text;
    public string metin;
    public bool endmetin =false;
    public Image profil;
    public AudioSource audioSource;
    public bool katsin = false;
    public string sahne;

    private void Start()
    {
        
    }
    void Update()
    {
       
        baseupdate();
        if ((Input.GetKeyDown(KeyCode.E)&& play&& endmetin==false) || (katsin&& Input.GetKeyDown(KeyCode.E))|| (i==0&& katsin))
        {
            if (i >= diyalogs.Length)
            {
                if (katsin)
                {
                    SceneManager.LoadScene(sahne);
                }
                i = 0;
                Canvas.GetComponent<Canvas>().enabled = false;
                endmetin = true;
                pokie.diolog=false;
                audioSource.clip = null;                
            }
            else
            {               
                Canvas.GetComponent<Canvas>().enabled = true;
                metin = diyalogs[i].metin;
                profil.sprite = diyalogs[i].sprite;
                text.text = metin;                
                pokie.diolog=true;
                if (audioSource != null)
                {
                    if (diyalogs[i].ses != null)
                    {
                        audioSource.clip = diyalogs[i].ses;
                        audioSource.Play();
                    }
                }
                i++; // en sonda olmalı
            }
        }
    }
    private void LateUpdate()
    {
        baseLateUpdate();
    }
}
