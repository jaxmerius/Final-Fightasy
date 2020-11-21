using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTrigger : MonoBehaviour
{
    private Animator controller;
    void Start()
    {
        controller = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
        {
            controller.ResetTrigger("Idle");
            controller.SetTrigger("Walk");
            controller.ResetTrigger("Jab");
            controller.ResetTrigger("Special");
            controller.ResetTrigger("Charge");
            controller.ResetTrigger("Power");
            controller.ResetTrigger("Guard");
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            controller.ResetTrigger("Idle");
            controller.ResetTrigger("Walk");
            controller.SetTrigger("Jab");
            controller.ResetTrigger("Special");
            controller.ResetTrigger("Charge");
            controller.ResetTrigger("Power");
            controller.ResetTrigger("Guard");
        }
        else if (Input.GetKeyDown(KeyCode.K))
        {
            controller.ResetTrigger("Idle");
            controller.ResetTrigger("Walk");
            controller.ResetTrigger("Jab");
            controller.SetTrigger("Special");
            controller.ResetTrigger("Charge");
            controller.ResetTrigger("Power");
            controller.ResetTrigger("Guard");
        }
        else if (Input.GetKey(KeyCode.L))
        {
            controller.ResetTrigger("Idle");
            controller.ResetTrigger("Walk");
            controller.ResetTrigger("Jab");
            controller.ResetTrigger("Special");
            controller.SetTrigger("Charge");
            controller.ResetTrigger("Power");
            controller.ResetTrigger("Guard");
        }
        else if (Input.GetKeyUp(KeyCode.L))
        {
            controller.ResetTrigger("Idle");
            controller.ResetTrigger("Walk");
            controller.ResetTrigger("Jab");
            controller.ResetTrigger("Special");
            controller.ResetTrigger("Charge");
            controller.SetTrigger("Power");
            controller.ResetTrigger("Guard");
        }
        else if (Input.GetKey(KeyCode.E))
        {
            controller.ResetTrigger("Idle");
            controller.ResetTrigger("Walk");
            controller.ResetTrigger("Jab");
            controller.ResetTrigger("Special");
            controller.ResetTrigger("Charge");
            controller.ResetTrigger("Power");
            controller.SetTrigger("Guard");
        }
        else
        {
            controller.SetTrigger("Idle");
            controller.ResetTrigger("Walk");
            controller.ResetTrigger("Jab");
            controller.ResetTrigger("Special");
            controller.ResetTrigger("Charge");
            controller.ResetTrigger("Power");
            controller.ResetTrigger("Guard");
        }

    }
}
