using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

//using TMPro;

public class BubbleCollision : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI _captionTextBox;

    public GameObject textObject;
    //private GameObject textObject;

    public Material[] material;
    Renderer rend;


    // spawn the object
    public Transform TextspawnPoint;




    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.enabled = true;
        rend.sharedMaterial = material[0];

        //textObject = GameObject.Find("Canvas/Hint");
        //textObject = GameObject.FindWithTag("Respawn");

        Debug.Log("text is not active");

       // _captionTextBox.enabled = false;

        //textObject.SetActive(false);    //add a heart prefab to test
    }

    void OnParticleCollision(GameObject other)
    {
        rend.sharedMaterial = material[1];

        // spawn the prefab (show the prefab)
        Instantiate(textObject, TextspawnPoint.position, TextspawnPoint.rotation);



        Debug.Log("text is active");
        //textObject.SetActive(true);   //fail to show the prefab


        StartCoroutine("waitforSec");
        //Destroy(gameObject);
    }

    IEnumerator waitforSec()
    {
        yield return new WaitForSeconds(4);
        //Destroy(textObject);
        Destroy(gameObject);
        //unloadObject();

    }

}
