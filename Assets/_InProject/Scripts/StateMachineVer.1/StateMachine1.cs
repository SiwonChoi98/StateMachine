using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State1<T>
{
    protected StateMachine1<T> StateMachine1;
    protected T context;

    public void SetMachineAndContext(StateMachine1<T> stateMachine1, T context)
    {
        this.StateMachine1 = stateMachine1;
        this.context = context;
        
        OnInitialized();
    }

    public virtual void OnInitialized()
    {
    }

    public virtual void OnEnter()
    {
    }

    public abstract void Update(float deltaTime);

    public virtual void OnExit()
    {
    }
}
public class StateMachine1<T>
{
    private T _context;

    private State1<T> _currentState1;

    private Dictionary<Type, State1<T>> _states = new();

    public StateMachine1(T context, State1<T> initState1)
    {
        this._context = _context;
        
        AddState(initState1);
        _currentState1 = initState1;
        _currentState1.OnEnter();
    }

    public void AddState(State1<T> state1)
    {
        state1.SetMachineAndContext(this, _context);
        _states[state1.GetType()] = state1;
    }

    public R ChangeState<R>() where R : State1<T>
    {
        var newType = typeof(R);
        if (_currentState1.GetType() == newType)
        {
            return _currentState1 as R;
        }

        if (_currentState1 != null)
        {
            _currentState1.OnExit();
        }

        _currentState1 = _states[newType];
        _currentState1.OnEnter();
        
        return _currentState1 as R;
    }

    public void Update(float detaTime)
    {
        _currentState1.Update(detaTime);
    }
}
