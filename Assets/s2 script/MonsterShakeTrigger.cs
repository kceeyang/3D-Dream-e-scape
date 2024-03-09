using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//not in use 


public class MonsterShakeTrigger : MonoBehaviour
{
    public AudioSource source;
    public AudioDetection detector;

    public float loudnessSensibility = 100;
    public float thredhold = 0.1f;

    public MonsterShake monShake;

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
            //MonsterShake.Invoke(); //version 2
            //StartCoroutine(MonsterShake.Shake(.15f,.4f));
            StartCoroutine(monShake.Shake(.25f, .2f));
            Debug.Log(loudness);
        }
        else if (loudness < thredhold)
        {
            loudness = 0;
        }

    }
}
