using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();    
    }
    private void Step(){
        if(FindObjectOfType<Move>().isGrounded){
            AudioClip clip = GetRandomClip();
            audioSource.PlayOneShot(clip);
        }
    }

    private AudioClip GetRandomClip(){
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }
}
