using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterState
{
    private State state;

    public enum State
    {
        WAIT,
        MOVE,
        ATTACK
    }

    public State getState()
    {
        return state;
    }

    public void setState(State state)
    {
        this.state = state;
    }



}
