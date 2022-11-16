using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip[] clips;
    private AudioSource audioSource;
    private void Awake() {
        audioSource = GetComponent<AudioSource>();    
    }
    void Step(){
        if(Mathf.Min(Mathf.Clamp(GetComponentInParent<PlayerMainController>().walkingSpeed, 0, 1), 
                                GetComponentInParent<PlayerMainController>().animWalkingSpeed) > 0.01){
            if(FindObjectOfType<PlayerMainController>().isGrounded){
                AudioClip clip = GetRandomClip();
                audioSource.PlayOneShot(clip);
            }
        }
    }

    private AudioClip GetRandomClip(){
        return clips[UnityEngine.Random.Range(0, clips.Length)];
    }

    
    void resetBool(string anim){
        GetComponentInParent<PlayerMainController>().resetAnimBool(anim);
    }
}
