using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Run : State<Base>
{
    public override void OnInitialized()
    {
    }
    
    public override void OnEnter()
    {
        context.IsRun = true;
        Debug.Log("Run");
    }

    public override void Update(float deltaTime)
    {
        //if(RUN == TRUE){
    
        //ELSE
            //if(Attack == true)
            _stateMachine.ChangeState<Attack>();
            return;
            //else 
            //_stateMachine.ChangeState<Idle>();
            //return;
    }

    public override void OnExit()
    {
        context.IsRun = false;
    }
}
