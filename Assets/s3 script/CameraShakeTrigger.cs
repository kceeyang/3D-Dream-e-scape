using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CameraShakeTrigger : MonoBehaviour
{
    public AudioSource source;
    public AudioDetection detector;

    public float loudnessSensibility = 100;
    public float thredhold = 0.1f;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float loudness = detector.GetLoudnessFromAudioClip(source.timeSamples, source.clip) * loudnessSensibility;
      
        //CameraShake.Invoke();
        if (loudness > thredhold)
        {
            CameraShake.Invoke();
            Debug.Log(loudness);
        }
        else if (loudness < thredhold)
        {
            loudness = 0;
        }

    }
}
