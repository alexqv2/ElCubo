using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AlexSonido : MonoBehaviour
{
    AudioSource _audioSource;
    public static float[] _samples = new float[1024];

    public static float[] _freqBand = new float[8];
    public static float[] _bandBuffer = new float[8];
    private readonly float[] _bufferDecrease = new float[8];
    public float RmsValue;
    public float DbValue;
    public float PitchValue;

    private const int QSamples = 1024;
    private const float RefValue = 0.1f;
    private const float Threshold = 0.02f;
    private float[] _spectrum = new float[1024];
    private float _fSample;
    
    private string _selectedDevice;
    int c;
    // Start is called before the first frame update
    void Start()
    { 
        _audioSource = GetComponent<AudioSource>();
       // _audioSource.clip = Microphone.Start(Microphone.devices[0], true, 10, 44100);
        _fSample = AudioSettings.outputSampleRate;
        _audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        _audioSource.GetOutputData(_samples, 0);
        _audioSource.GetSpectrumData(_spectrum, 0, FFTWindow.BlackmanHarris);
        AnalyzeSound();
        
    }

    

    void AnalyzeSound()
    {
       
        int i;
        float sum = 0;
        for (i = 0; i < QSamples; i++)
        {
            sum += _samples[i] * _samples[i]; // sum squared samples
        }
        RmsValue = Mathf.Sqrt(sum / QSamples); // rms = square root of average
        DbValue = 20 * Mathf.Log10(RmsValue / RefValue); // calculate dB
        if (DbValue < -160) DbValue = -160; // clamp it to -160dB min
                                            // get sound spectrum
        float maxV = 0;
        var maxN = 0;
        for (i = 0; i < QSamples; i++)
        { // find max 
            if (!(_spectrum[i] > maxV) || !(_spectrum[i] > Threshold))
                continue;

            maxV = _spectrum[i];
            maxN = i; // maxN is the index of max
        }
        float freqN = maxN; // pass the index to a float variable
        if (maxN > 0 && maxN < QSamples - 1)
        { // interpolate index using neighbours
            var dL = _spectrum[maxN - 1] / _spectrum[maxN];
            var dR = _spectrum[maxN + 1] / _spectrum[maxN];
            freqN += 0.5f * (dR * dR - dL * dL);
        }
        PitchValue = freqN * (_fSample / 2) / QSamples; // convert index to frequency
    }
}



