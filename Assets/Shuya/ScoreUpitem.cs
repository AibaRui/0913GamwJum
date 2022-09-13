using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreUpitem : ItemBase
{
    [SerializeField] int _addscore = 1;
    public override void Activate1()
    {
        FindObjectOfType<GameManager>().Addscore(1, 1);
    }

    public override void Activate2()
    {
        FindObjectOfType<GameManager>().Addscore(2, 1);
    }
}
