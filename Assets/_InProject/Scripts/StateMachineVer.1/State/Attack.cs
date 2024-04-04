using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State1<Base>
{
    
    public override void OnInitialized()
    {
            
    }
    
    public override void OnEnter()
    {
        Debug.Log("Attack");
    }

    public override void Update(float deltaTime)
    {
        StateMachine1.ChangeState<Idle>();
        return;
    }

    public override void OnExit()
    {
        context.IsAttack = false;
    }
}
