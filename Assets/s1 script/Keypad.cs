using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Keypad : Interactables
{
    [SerializeField] private GameObject door;
    private bool doorOpen;

    //add door open audio
    public AudioSource doorOpenSound;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void Interact()
    {
        //Debug.Log("Interacted with " + gameObject.name);
        doorOpen = !doorOpen;
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        //add door open audio
        doorOpenSound.Play();
    }
}
