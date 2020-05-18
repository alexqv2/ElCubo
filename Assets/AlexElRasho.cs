using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexElRasho : MonoBehaviour
{
    AlexSonido alexSonido;
    AlexScript alexBolitas;
    Renderer alexCubito;
    int t = 0;
    int c = 0;
    float sy = 1;
    float sx = 1;
    float sz = 1;
    float lineG = 0.125f;
    float large = 80;
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
        if (alexBolitas.lightFrecuency < 514)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(large / sx, lineG / sy, lineG / sz));
            sx = large;
            sz = lineG;
            sy = lineG;
        }
        else if (alexBolitas.lightFrecuency < 648)
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(lineG / sx, large / sy, lineG / sz));
            sx = lineG;
            sz = lineG;
            sy = large;
        }
        else
        {
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(lineG / sx, lineG / sy, large / sz));
            sx = lineG;
            sz = large;
            sy = lineG;
        }
        transform.Rotate(0.5f, 0.5f, 0.5f);
        alexCubito.material.color = new Color(1 - alexBolitas.r, 1 - alexBolitas.g, 1 - alexBolitas.b);
    }
}
