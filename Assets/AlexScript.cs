using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Diagnostics;
using UnityEngine;

public class AlexScript : MonoBehaviour
{
    public AlexSonido alexSonido;
    public ParticleSystem alexBolita;
    public float g;
    public float r;
    public float b;
    public int c = 0;
    public float t;
    public float tt=0;
    public float size=1;
    public double lightFrecuency;
    // Start is called before the first frame update
    void Start()
    {
        alexSonido = GameObject.Find("Audio Source").GetComponent<AlexSonido>();
        alexBolita = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        var sh = alexBolita.shape;
        var main = alexBolita.main;
        converToRGB(alexSonido.PitchValue);
        main.startColor = new Color(r,g,b);
        t = ((float)alexSonido.DbValue);
        if (t < -20) {
            size = 1;
        }
        else if (size > 7) {
            size = 5;
        }
        else {
            size = size + (t - tt)/4;
            size = size < 1 || size > 7 ? 5 : size;
        }
        sh.scale = new Vector3(size, size, size);
        tt = t;
        main.startSpeed = size/5;      
        alexBolita.transform.Rotate(new Vector3(Mathf.PI,0,0));
       
    }

    void converToRGB(double soundFrecuency)
    {
        if (soundFrecuency > 19 && soundFrecuency < 2500)
        {
            double Red;
            double Green;
            double Blue;
            lightFrecuency = Math.Sqrt(soundFrecuency*53.333)+380;     //(((soundFrecuency / 10 - 2) / 1998) * 4 + 3.84) * 100; <- Lineal
            if ((lightFrecuency >= 380) && (lightFrecuency < 440))
            {
                Red = -(lightFrecuency - 440) / (440 - 380);
                Green = 0.0;
                Blue = 1.0;
            }
            else if ((lightFrecuency >= 440) && (lightFrecuency < 490))
            {
                Red = 0.0;
                Green = (lightFrecuency - 440) / (490 - 440);
                Blue = 1.0;
            }
            else if ((lightFrecuency >= 490) && (lightFrecuency < 510))
            {
                Red = 0.0;
                Green = 1.0;
                Blue = -(lightFrecuency - 510) / (510 - 490);
            }
            else if ((lightFrecuency >= 510) && (lightFrecuency < 580))
            {
                Red = (lightFrecuency - 510) / (580 - 510);
                Green = 1.0;
                Blue = 0.0;
            }
            else if ((lightFrecuency >= 580) && (lightFrecuency < 645))
            {
                Red = 1.0;
                Green = -(lightFrecuency - 645) / (645 - 580);
                Blue = 0.0;
            }
            else if ((lightFrecuency >= 645) && (lightFrecuency < 781))
            {
                Red = 1.0;
                Green = 0.0;
                Blue = 0.0;
            }
            else
            {
                Red = 0.0;
                Green = 0.0;
                Blue = 0.0;
            };

            // Let the intensity fall off near the vision limits
            double factor;
            if ((lightFrecuency >= 380) && (lightFrecuency < 420))
            {
                factor = 0.3 + 0.7 * (lightFrecuency - 380) / (420 - 380);
            }
            else if ((lightFrecuency >= 420) && (lightFrecuency < 701))
            {
                factor = 1.0;
            }
            else if ((lightFrecuency >= 701) && (lightFrecuency < 781))
            {
                factor = 0.3 + 0.7 * (780 - lightFrecuency) / (780 - 700);
            }
            else
            {
                factor = 0.0;
            };



            r = Red == 0.0 ? 0 : (int)Math.Round(255 * Math.Pow(Red * factor, 0.4));
            g = Green == 0.0 ? 0 : (int)Math.Round(255 * Math.Pow(Green * factor, 0.4));
            b = Blue == 0.0 ? 0 : (int)Math.Round(255 * Math.Pow(Blue * factor, 0.4));
            r = r / 255;
            g = g / 255;
            b = b / 255;
          //  UnityEngine.Debug.Log(r +" - "+g+" - "+b);
        }

    }
}
