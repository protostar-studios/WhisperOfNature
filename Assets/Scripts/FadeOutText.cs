using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutText : MonoBehaviour
{
    TextMesh textmesh;
    private float secondsToFade =3.5f;


    private bool isCoroutineExecuting = false;
    // Start is called before the first frame update
    void Start()
    {
     textmesh = gameObject.GetComponent<TextMesh>();
     //FadeTextToZeroAlpha(3, textmesh);
     //Invoke("FadeOutEvent", 3);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.R) || Input.GetButtonDown("PS_CloseTut") || Input.GetButtonDown("Xbox_CloseTut"))
            {
                StartCoroutine(FadeTextToZeroAlpha(1f, textmesh));
            }
        }
        if (textmesh.color.a == 0.0f)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }
    public void FadeOutEvent()
    {
        // Get the GameObject fromt the recieved Object.
        //GameObject parent = go as GameObject;
        //TextMesh textmesh = parent.GetComponentInChildren<TextMesh>();
        //GameObject child = parent.GetComponentInChildren<GameObject>();
        //// Get all ChildGameObjects and try to get their PBR Shader
        Debug.Log("Fading out");
        Color color = textmesh.color;
        //Debug.Log(color);
        // Call our FadeOut Coroutine for each Component found.
        while (textmesh.color.a > 0)
        {
            Debug.Log(textmesh.color.a);
            color.a -= (float) 0.01;
            textmesh.color = color;
        }
    }

    public IEnumerator FadeTextToZeroAlpha(float t, TextMesh i)
    {
        i.color = new Color(i.color.r, i.color.g, i.color.b, 1);
        while (i.color.a > 0.0f)
        {
            Debug.Log(i.color.a);
            i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
