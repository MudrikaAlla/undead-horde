using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickToKill : MonoBehaviour
{
    Animator anim;
    AudioSource slash;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

        //getting audio source attached to Maria
        slash = GetComponent<AudioSource>();
    }

    void Update()
    {
        //if user clicks K, Maria slashes her sword. this animation is triggered by a boolean parameter kill
        if (Input.GetKey(KeyCode.K))
        {
            //setting the kill parameter true, triggering slash animation of Maria
            anim.SetBool("Kill", true);

            //play sound attached to Maria
            slash.Play();
        }
        
        if (Input.GetKeyUp(KeyCode.K))
        {
            anim.SetBool("Kill", false);
        }
    }
}
