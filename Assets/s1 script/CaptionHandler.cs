using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CaptionHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _captionTextBox;

    private void Start()
    {
        _captionTextBox.enabled = false;
    }

    public void ReceiveCaption(CaptionTrigger trigger)
    {
        //put any logic for queuing or waiting or only showing one caption at a time
        StartCoroutine(DisplayCaption(trigger.Caption, trigger.DisplayDuration));

    }

    private IEnumerator DisplayCaption(string caption, float duration)
    {
        _captionTextBox.text = caption;
        _captionTextBox.enabled = true;
        yield return new WaitForSeconds(duration);
        _captionTextBox.enabled = false;   
    }
}
