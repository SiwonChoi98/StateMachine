using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected StateMachine1<Base> StateMachine1;

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
        StateMachine1 = new StateMachine1<Base>(this, new Idle());
        StateMachine1.AddState(new Attack());
        StateMachine1.AddState(new Run());
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
