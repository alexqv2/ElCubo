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
    int side;
    int c = 81;
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
        transform.localScale = Vector3.Scale(transform.localScale, new Vector3(1, 1, (alexBolitas.size*23 > 0 ? alexBolitas.size*23 :1)/sx)) ;
        UnityEngine.Debug.Log(transform.localScale.z);
        sx = alexBolitas.size*23>0? alexBolitas.size*23:1;
      //  transform.Rotate(0.5f, 0.5f, 0.5f);
        alexCubito.material.color = new Color( alexBolitas.r, alexBolitas.g, alexBolitas.b);
    }
}
