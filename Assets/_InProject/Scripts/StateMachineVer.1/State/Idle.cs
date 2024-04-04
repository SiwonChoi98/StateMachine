using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Idle : State1<Base>
{   
    public override void OnInitialized()
    {
        
    }
    
    public override void OnEnter()
    {
        Debug.Log("Idle");
    }

    public override void Update(float deltaTime)
    {
        if(context.Attack())
        {
            StateMachine1.ChangeState<Attack>();
            return;    
        }

        if (context.Run())
        {
            StateMachine1.ChangeState<Run>();
            return; 
        }
    }

    public override void OnExit()
    {
    }
}
