using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// to display ring attack instruction (won't disappear after 1st access)

public class RingCaptionTrigger : MonoBehaviour
{
    public string Caption;
    public float DisplayDuration;    // store how long the caption shown in seconds


    private void OnTriggerEnter(Collider other)
    {
        RingCaptionHandler potentialHandler = other.GetComponent<RingCaptionHandler>();
        if (potentialHandler != null)
        {
            // send caption info to CaptionHandler
            potentialHandler.ReceiveCaption(this);
            //gameObject.SetActive(false);    //text won't show up after the first time
        }
    }
}

