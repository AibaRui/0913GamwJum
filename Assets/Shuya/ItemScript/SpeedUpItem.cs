using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUpItem : ItemBase
{
    [SerializeField]int _addSpeed = 2;
    public override void Activate1()
    {
        FindObjectOfType<Player>().AddSpeed1(_addSpeed);

    }
    public override void Activate2()
    {
        FindObjectOfType<Player>().AddSpeed2(_addSpeed);

    }
}
