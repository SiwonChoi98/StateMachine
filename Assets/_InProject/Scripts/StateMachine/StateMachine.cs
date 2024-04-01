using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State<T>
{
    protected StateMachine<T> _stateMachine;
    protected T context;

    public void SetMachineAndContext(StateMachine<T> stateMachine, T context)
    {
        this._stateMachine = stateMachine;
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
public class StateMachine<T>
{
    private T _context;

    private State<T> _currentState;

    private Dictionary<Type, State<T>> _states = new();

    public StateMachine(T context, State<T> initState)
    {
        this._context = _context;
        
        AddState(initState);
        _currentState = initState;
        _currentState.OnEnter();
    }

    public void AddState(State<T> state)
    {
        state.SetMachineAndContext(this, _context);
        _states[state.GetType()] = state;
    }

    public R ChangeState<R>() where R : State<T>
    {
        var newType = typeof(R);
        if (_currentState.GetType() == newType)
        {
            return _currentState as R;
        }

        if (_currentState != null)
        {
            _currentState.OnExit();
        }

        _currentState = _states[newType];
        _currentState.OnEnter();
        
        return _currentState as R;
    }

    public void Update(float detaTime)
    {
        _currentState.Update(detaTime);
    }
}
