using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected StateMachine<Base> _stateMachine;

    public Animator Anim;
    public Rigidbody2D Rigidbody2D;

    public bool IsAttack = false;
    public bool IsRun = false;
    
    #region Unity Method
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }
    
    private void Start()
    {
        Init();
    }

    #endregion
    
    
    private void Init()
    {
        AddState();
    }
    private void AddState()
    {
        _stateMachine = new StateMachine<Base>(this, new Idle());
        _stateMachine.AddState(new Attack());
        _stateMachine.AddState(new Run());
    }

    public bool Attack()
    {
        if (Input.GetMouseButton(0))
        {
            IsAttack = true;
        }
        return IsAttack;
    }

    public bool Run()
    {
        /*
         * IsRun = true;
            return IsRun;
         */
        return false;
    }
}
