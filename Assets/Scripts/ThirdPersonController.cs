using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    Animator anim;
    public float acceleration = 2f;
    public float deceleration = 2f;
    public float maxSpeed = 5;
    float speed = 0;
    public Vector3 input;


    //Camera movement
    public Transform cam;
    float currentVelocity;
    public float smoothTime = 0.1f;

    void Start()
    {
        //Get reference to the Animator Controller on Maria
        anim = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        //get user input that will determine Maria's forward direction
        input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

        //get the magnitude of the user's input, which will be continuous for a joystick
        float inputMagnitude = input.magnitude;

        //normalizing the input so that it has a magnitude of 1
        Vector3 direction = input / inputMagnitude;

        float currentMaxSpeed = inputMagnitude * maxSpeed;
        if (currentMaxSpeed > maxSpeed)
        {
            currentMaxSpeed = maxSpeed;
        }


        //if user is pressing arrow or WASD keys, then set Maria's forward direction and accelerate up to maxSpeed
        if (inputMagnitude > 0)
        {
            //compute the target angle from the user
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            //compute an in-between angle for smoother rotations
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref currentVelocity, smoothTime);

            //turn to face the direction specified by the user
            //transform.forward = direction;
            transform.rotation = Quaternion.Euler(0, angle, 0);

            if (speed < currentMaxSpeed)
            {
                speed += acceleration * Time.deltaTime;
            }
            else
            {
                //speed -= deceleration * Time.deltaTime;
                speed = Mathf.Lerp(speed, currentMaxSpeed, 0.1f);
            }
        }

        //if user is not pressing arrow or WASD keys, then decelerate
        else
        {
            speed -= deceleration * Time.deltaTime;
        }

        //Make sure that speed doesn't go below zero
        if (speed < 0)
        {
            speed = 0;
        }

        //communicates the speed to the animator
        anim.SetFloat("Speed", speed);

    }
}
