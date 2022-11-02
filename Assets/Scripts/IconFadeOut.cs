using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconFadeOut : MonoBehaviour
{
    Renderer renderer;
    private float secondsToFade = 3.5f;

    private bool isCoroutineExecuting = false;
    // Start is called before the first frame update
    void Start()
    {
        renderer = gameObject.GetComponent<Renderer>();
        //FadeTextToZeroAlpha(3, textmesh);
        //Invoke("FadeOutEvent", 3);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (Input.GetButtonDown("CloseTut") || Input.GetButtonDown("PS_CloseTut") || Input.GetButtonDown("Xbox_CloseTut"))
            {
                StartCoroutine(FadeIconToZeroAlpha(1f, renderer));
            }
            if (renderer.material.color.a == 0.0f) { 
                Destroy(gameObject);
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
    

    }
   

    public IEnumerator FadeIconToZeroAlpha(float t, Renderer i)
    {
        i.material.color = new Color(i.material.color.r, i.material.color.g, i.material.color.b, 1);
        while (i.material.color.a > 0.0f)
        {
            Debug.Log(i.material.color.a);
            i.material.color = new Color(i.material.color.r, i.material.color.g, i.material.color.b, i.material.color.a - (Time.deltaTime / t));
            yield return null;
        }
    }
}
