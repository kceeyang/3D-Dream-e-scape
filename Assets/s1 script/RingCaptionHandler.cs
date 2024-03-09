using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


// to display ring attack instruction (won't disappear after 1st access)
// same as the CaptionHandler, except minor change in ReceiveCaption()


public class RingCaptionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _captionTextBox;

    private void Start()
    {
        _captionTextBox.enabled = false;
    }

    public void ReceiveCaption(RingCaptionTrigger rtrigger)
    {
        //put any logic for queuing or waiting or only showing one caption at a time
        StartCoroutine(DisplayCaption(rtrigger.Caption, rtrigger.DisplayDuration));

    }

    private IEnumerator DisplayCaption(string caption, float duration)
    {
        _captionTextBox.text = caption;
        _captionTextBox.enabled = true;
        yield return new WaitForSeconds(duration);
        _captionTextBox.enabled = false;
    }
}
