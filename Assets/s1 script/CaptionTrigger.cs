using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptionTrigger : MonoBehaviour
{
    public string Caption;
    public float DisplayDuration;    // store how long the caption shown in seconds


    private void OnTriggerEnter(Collider other)
    {
        CaptionHandler potentialHandler = other.GetComponent<CaptionHandler>();
        if (potentialHandler != null)
        {
            // send caption info to CaptionHandler
            potentialHandler.ReceiveCaption(this);
            gameObject.SetActive(false);     //text won't show up after the first time
        }
    }
}
