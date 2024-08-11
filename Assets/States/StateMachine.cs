using System.Collections;
using System.Collections.Generic;
using a;
using States;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IdleState _idleState;
    private MeleeAttack _meleeAttack;
    private RangeAttack _rangeAttack;

    private IState _currentState;

    public void ChangeState(StatesEnum newState)
    {
        
    }
}