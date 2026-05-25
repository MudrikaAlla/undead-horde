using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rand_Anim_Zombie : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        //get the animator component attached
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        int moveIndex = Random.Range(0, 3);
        anim.SetInteger("MoveIndex", moveIndex);
    }
}
