using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class jumpscare : MonoBehaviour
{
    //public string scenename;
    public GameObject monsterObj;

    public bool isAlarmPlayed;
    public AudioSource alarmSoundEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //SceneManager.LoadScene(scenename);

            if (isAlarmPlayed == true)
            {

                alarmSoundEffect.Stop();
                Destroy(monsterObj);
            }
        }
    }
}
