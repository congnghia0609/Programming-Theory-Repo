using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BallRed : BallBase
{
    [SerializeField] private int score = 3;

    // ABSTRACTION
    public override string GetName()
    {
        return "BallRed";
    }

    // ABSTRACTION
    public override int GetScore()
    {
        return score;
    }
}
