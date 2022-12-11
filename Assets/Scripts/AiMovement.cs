using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : CharacterMovement
{


    private Robot robot;
    private float currentStoppingTime;
    private float currentTime;
    private bool shouldBeCounting = true;

    private void OnEnable()
    {
        if (robot == null)
            robot = FindObjectOfType<Robot>();

        robot.OnStartCounting +=OnStartCounting;
        robot.OnStopCounting+=OnStopCounting;
        currentStoppingTime = Random.Range(3, 6);
    }
    // Start is called before the first frame update
    private void Update()
    {
        if (shouldBeCounting)
            currentTime += Time.deltaTime;
        if (currentTime >= currentStoppingTime)
        {
            verticalDirection = 0;
            shouldBeCounting = false;
            
        }

        animator.SetFloat("Speed", rb.velocity.normalized.magnitude);

    }
    
    private void OnStartCounting()
    {
        verticalDirection = 1;
        shouldBeCounting = true;
        currentTime = 0;
        currentStoppingTime = Random.Range(3, 6);
    }
    private void OnStopCounting()
    {
        verticalDirection = 0;
    }
}
