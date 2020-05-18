using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AlexElRasho : MonoBehaviour
{
    AlexSonido alexSonido;
    AlexScript alexBolitas;
    Renderer alexCubito;
    float sy = 1;
    float sx = 1;
    float sz = 1;
    float lineG = 0.25f;
    float large = 1024;
    int side;
    int c = 27;
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
        c++;
        if (c == 28){
            UnityEngine.Debug.Log(transform.localScale.x + " - "+transform.localScale.y + " - "+ transform.localScale.z);
            transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1 / sx, 1 / sy, 1 / sz));
            if (alexBolitas.lightFrecuency < 514)
            {
                side = 1;
                sx = large;
                sy = 1;
                sz = 1;
            }
            else if (alexBolitas.lightFrecuency < 648)
            {
                side = 2;
                sx = 1;
                sy = large;
                sz = 1;
            }
            else
            {
                side = 3;
                sx = 1;
                sy = 1;
                sz = large;
            }
            c = 0;
        }
        if (c % 3 == 0){
            switch (side)
            {
                case 1:
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(2, 1, 1));
                    break;
                case 2:
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 2, 1));
                    break;
                case 3:
                    transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, 2));
                    break;
                default:
                    break;
            }
        }
        transform.Rotate(0.5f, 0.5f, 0.5f);
        alexCubito.material.color = new Color(1 - alexBolitas.r, 1 - alexBolitas.g, 1 - alexBolitas.b);
    }
}
