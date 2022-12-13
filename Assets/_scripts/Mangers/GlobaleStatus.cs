using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public static class GlobaleStatus
{
    static float GlobalSpeed = 1;
    static StatePos state = StatePos.move;
    public static Action<Enemy> enemyDestroyed;

    public enum StatePos
    {
        move,
        stay
    }

    public static void SetSpeed(float speed)
    {
        GlobalSpeed = speed;
    }

    public static void switchState()
    {
        switch (state)
        {
            case StatePos.move:
                state = StatePos.stay;
                break;
            case StatePos.stay:
                state = StatePos.move;
                break;
        }
    }

    public static StatePos GetState()
    {
        return state;
    }

    public static float GetSpeed()
    {
        return GlobalSpeed;
    }
}
