using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : State<Base>
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
        _stateMachine.ChangeState<Idle>();
        return;
    }

    public override void OnExit()
    {
        context.IsAttack = false;
    }
}
