using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlarmClock : MonoBehaviour
{
    public GameObject clockText;
    public AudioSource alarmSoundEffect;
    public bool isAlarmPlayed;

    //test camera shake
    //public CameraShake cameraShake;

    void Start()
    {
        clockText.SetActive(false);

    }


    void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("MainCamera"))
        {
            clockText.SetActive(true);

            //StartCoroutine(cameraShake.Shake(.15f, .4f));

            if (isAlarmPlayed == true)
            {
                //test camera shake
                //CameraShake.Invoke();


                //clockText.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    //clockText.SetActive(false);

                    alarmSoundEffect.Stop();

                    //clockText.SetActive(false);
                    Destroy(clockText);

                }
            }
            if (isAlarmPlayed == false)
            {
                clockText.SetActive(false);

            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            clockText.SetActive(false);
            //lockedText.SetActive(false);

            //this.GetComponent<CameraShake>().enabled = false;
        }
    }
    /*
    IEnumerator repeat()
    {
        yield return new WaitForSeconds(4.0f);

        opened = false;
        door_closed.SetActive(true);
        door_opened.SetActive(false);
        //close.Play();
    }
   


    void Update()
    {
        if (isAlarmPlayed == true)
        {
            //clockText.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                //clockText.SetActive(false);
                alarmSoundEffect.Stop();
                clockText.SetActive(false);
            }
        }
        if (isAlarmPlayed == false)
        {
            clockText.SetActive(false);

        }
    }
     */


}

