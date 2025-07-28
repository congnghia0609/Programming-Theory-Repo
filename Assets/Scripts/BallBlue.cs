using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// INHERITANCE
public class BallBlue : BallBase
{
    [SerializeField] private int score = 1;

    // ABSTRACTION
    public override string GetName()
    {
        return "BallBlue";
    }

    // ABSTRACTION
    public override int GetScore()
    {
        return score;
    }
}
