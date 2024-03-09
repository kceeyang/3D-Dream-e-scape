using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class light : MonoBehaviour
{
    public GameObject flashlight_ground, inticon, flashlight_player;

    public AudioSource pickup;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(true);

            if (Input.GetKeyDown(KeyCode.P))
            {
                flashlight_ground.SetActive(false);
                inticon.SetActive(false);
                flashlight_player.SetActive(true);
                pickup.Play();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(false);
        }
    }

}
