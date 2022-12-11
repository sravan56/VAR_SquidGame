using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : CharacterMovement
{
    
    
    


    
     private void Update()
    {
        verticalDirection = Input.GetAxis("Vertical");
        sprintValue = Input.GetAxis("Sprint");
        verticalDirection = Mathf.Clamp(verticalDirection, 0, 1);
        animator.SetFloat("Speed", verticalDirection+ sprintValue);

    }
    // Update is called once per frame
    public override void Die()
    {
        base.Die();
        UIManager.Instance.TriggerLoseMenu();
    }
    public override void Win()
    {
        base.Win();
        UIManager.Instance.TriggerWinMenu();
    }
    
}
