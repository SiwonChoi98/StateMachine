using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Idle : State<Base>
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
            _stateMachine.ChangeState<Attack>();
            return;    
        }

        if (context.Run())
        {
            _stateMachine.ChangeState<Run>();
            return; 
        }
    }

    public override void OnExit()
    {
    }
}
