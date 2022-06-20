using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MyState
{
    protected ActionController _actionController;

    public ActionController IaStateMachine
    {
        set => _actionController = value;
    }
    
    public abstract void Move();
    public abstract MyState SwitchState();
}

public class IdleState : MyState
{
    public override void Move()
    {
        
    }
    
    public override MyState SwitchState()
    {
        return this;
    }
}

public class PickUpState : MyState
{
    public override void Move()
    {
        
    }
    
    public override MyState SwitchState()
    {
        return this;
    }
}

public class ActionController : MonoBehaviour
{

}
