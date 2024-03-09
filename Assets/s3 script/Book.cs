using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;


public class Book : MonoBehaviour
{
    [SerializeField] private Image bookImage;

    public GameObject MessagePanel;
    public bool Action = false;

    public string scenename;

    public AudioSource pickupSound;
    public AudioSource bookOpenSound;

    public void Start()
    {
        MessagePanel.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (Action == true)
            {
                pickupSound.Play();
                MessagePanel.SetActive(false);
                Action = false;
                bookImage.enabled = true;

                bookOpenSound.Play();

                Invoke("CompleteLevel", 9f);

                //SceneManager.LoadScene(scenename);
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera"))    //Player
        {
            MessagePanel.SetActive(true);
            Action = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))     //Player
        {
            MessagePanel.SetActive(false);
            Action = false;
            bookImage.enabled = false;
        }
    }

    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
