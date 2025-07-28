using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BallGreen : BallBase
{
    [SerializeField] private int score = 2;

    // ABSTRACTION
    public override string GetName()
    {
        return "BallGreen";
    }

    // ABSTRACTION
    public override int GetScore()
    {
        return score;
    }
}
