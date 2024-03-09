using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class key : MonoBehaviour
{
    public GameObject inticon, mykey;

    public AudioSource pickup;

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("MainCamera"))
        {
            inticon.SetActive(true);

            if(Input.GetKeyDown(KeyCode.P))
            {
                mykey.SetActive(false);
                Door.keyfound = true;
                inticon.SetActive(false);
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
