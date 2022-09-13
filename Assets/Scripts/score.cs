using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class score : MonoBehaviour
{
    public TMP_Text txt;
    public static int count;

    void Start()
    {

    }


    void Update()
    {
       
        txt.text = count.ToString("Score: " + count);


    }
}
    
