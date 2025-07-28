using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BallBase : MonoBehaviour
{
    public virtual string GetName()
    {
        return "BallBase";
    }

    public abstract int GetScore();
}
