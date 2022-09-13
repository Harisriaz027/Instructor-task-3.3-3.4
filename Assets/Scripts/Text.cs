using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Text : MonoBehaviour
{
    public TMP_Text txt;
    private int life;
    private PlayerController pcs;
    void Start()
    {
        pcs = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    
    void Update()
    {
        life = pcs.life;
        txt.text = life.ToString("Remaining lives: "+life);
        if (life < 1)
        {
            Invoke("freeze", 2);
        }
    }
    void freeze()
    {
        Time.timeScale = 0;
    }
}
