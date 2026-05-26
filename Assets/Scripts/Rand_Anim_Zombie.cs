using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rand_Anim_Zombie : MonoBehaviour
{
    Animator anim;

    [SerializeField] private float minChangeInterval = 2f;
    [SerializeField] private float maxChangeInterval = 5f;
    private float animChangeTimer;

    void Start()
    {
        anim = GetComponent<Animator>();
        animChangeTimer = Random.Range(minChangeInterval, maxChangeInterval);
    }

    void Update()
    {
        animChangeTimer -= Time.deltaTime;
        if (animChangeTimer <= 0f)
        {
            int moveIndex = Random.Range(0, 3);
            anim.SetInteger("MoveIndex", moveIndex);
            animChangeTimer = Random.Range(minChangeInterval, maxChangeInterval);
        }
    }
}
