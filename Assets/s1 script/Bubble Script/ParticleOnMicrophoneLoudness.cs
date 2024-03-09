using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleOnMicrophoneLoudness : MonoBehaviour
{
    public ParticleSystem particles;
    public AudioDetection detector;

    public float loudnessSensibility = 100;
    public float thredhold = 0.1f;


    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromMicrophone() * loudnessSensibility;

        if (loudness < thredhold && particles.isPlaying)
        {
            particles.Stop();
        }
        else if (loudness > thredhold && particles.isStopped)
        {
            particles.Play();
        }
        
    }

    private void OnDisable()
    {
        particles.Stop();
    }
}
