using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCubito : MonoBehaviour
{
    AlexSonido alexSonido;
    AlexScript alexBolitas;
    Renderer alexCubito;
    int t = 0;
    int c = 0;
    float sy =1;
    float sx = 1;
    float sz = 1;

    // Start is called before the first frame update
    void Start()
    {
        alexBolitas = GameObject.Find("Particle System").GetComponent<AlexScript>();
        alexSonido = GameObject.Find("Audio Source").GetComponent<AlexSonido>();
        alexCubito = GetComponent<Renderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        var ss = alexBolitas.size/2;
        ss = ss < 1 ? 1 : ss;
        if (alexBolitas.lightFrecuency < 514){
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(ss/sx, 1, 1));
            sx = ss;
        }
        else if(alexBolitas.lightFrecuency < 648){
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, ss/sy, 1));
            sy = ss;
        } else{
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, ss/sz));
            sz = ss;
        }
        transform.Rotate(0.5f, 0.5f, 0.5f);
        alexCubito.material.color = new Color(1-alexBolitas.r, 1-alexBolitas.g, 1-alexBolitas.b);

    }
}
