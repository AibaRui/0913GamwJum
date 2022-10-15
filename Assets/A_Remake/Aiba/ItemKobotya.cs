using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemKobotya : ItemBase
{
    public override void Activate1()
    {
        FindObjectOfType<PlayerMove>().StartCoroutine("mutekiItem");
    }

    public override void Activate2()
    {
        FindObjectOfType<Player2>().StartCoroutine("mutekiItem");
    }
}
