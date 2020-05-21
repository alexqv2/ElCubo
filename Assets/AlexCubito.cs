using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlexCubito : MonoBehaviour
{
    LineRenderer linea;
    LineRenderer linea2;
    AlexSonido alexSonido;
    AlexScript alexBolitas;
    Renderer alexCubito;
    Color c2;
    int t = 0;
    int c = 0;
    float sy =1;
    float sx = 1;
    float sz = 1;
    float sizetemp = 0;
    // Start is called before the first frame update
    void Start()
    {
        alexBolitas = GameObject.Find("Particle System").GetComponent<AlexScript>();
        alexSonido = GameObject.Find("Audio Source").GetComponent<AlexSonido>();
        alexCubito = GetComponent<Renderer>();
        GameObject gameObject = new GameObject();
        GameObject gameObject2 = new GameObject();
        linea = gameObject.AddComponent<LineRenderer>();
        linea2 = gameObject2.AddComponent<LineRenderer>();
        linea.SetPosition(0, new Vector3(4, 0, -40));
        linea2.SetPosition(0, new Vector3(-36, 0, 0));
        linea.material = new Material(Shader.Find("Sprites/Default")); linea2.material = new Material(Shader.Find("Sprites/Default"));
        linea.SetWidth(1,1);
        linea2.SetWidth(1,1);

    }

    // Update is called once per frame
    void Update()
    {
        /* c++;
         if (c == 90) {
             linea2.SetPosition(1, new Vector3(-35, 0, 0));
             linea.SetPosition(1, new Vector3(4, 0, -39 + 1));
             c = 0;
         }
         if (c > 70)
         {
             linea2.SetPosition(1, new Vector3(-35 + (90-c)*(sizetemp/20), 0, 0));
             linea.SetPosition(1, new Vector3(4, 0, -39 + (90-c) * (sizetemp / 20)));
         }
         else
         {*/
        var sizet = alexBolitas.size-0.8f;
            sizet = sizet < 0.2 ? 3 : sizet * 15;
            linea2.SetPosition(1, new Vector3(-35 + sizet, 0, 0));
            linea.SetPosition(1, new Vector3(4, 0, -39 + sizet));
      //  }
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
    //    transform.Rotate(0.5f, 0.5f, 0.5f);
        alexCubito.material.color = new Color(alexBolitas.r, alexBolitas.g, alexBolitas.b);
        c2 = new Color(alexBolitas.r, alexBolitas.g, alexBolitas.b);
        linea.SetColors(c2, c2);
        linea2.SetColors(c2, c2);

    }
}
