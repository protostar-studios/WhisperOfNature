using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnTutorial : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorialText;
    public GameObject tutorialButton;
    //private GameObject child;
    //private Vector3 distance = new Vector3(0.0f, 0.0f, 1.0f);
    void Start()
    {
        tutorialButton.transform.parent = transform;
        tutorialText.transform.parent = transform;
        tutorialButton.transform.localPosition = new Vector3(3.49f, 0, 0);
        tutorialText.transform.localPosition = new Vector3(0, 0, 0);
        tutorialButton.SetActive(false);
        tutorialText.SetActive(false);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            tutorialText.SetActive(true);
            tutorialButton.SetActive(true);
            tutorialButton.transform.localPosition = new Vector3(3.49f, 0, 0);
            tutorialText.transform.localPosition = new Vector3(0, 0, 0);
            //child = Instantiate(tutorialText, transform) as GameObject;
            //child.transform.position = gameObject.transform.position;
            //child.transform.rotation = gameObject.transform.rotation;

            //child.transform.SetParent(gameObject.transform, false);
            //child.transform.position = new Vector3(33.36f, 16.25f, 5.0f);
            // child.transform.localPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            // Debug.Log(child.transform.localPosition);
            //Debug.Log(child.transform.position);
            // Debug.Log(transform.position);

            //child = Instantiate(tutorialButton) as GameObject;
            //child.transform.position = gameObject.transform.position + Vector3(0,0,2f);
            //child.transform.rotation = gameObject.transform.rotation;

            //child.transform.parent = gameObject.transform.parent;
            //Instantiate(tutorialButton, transform);
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
