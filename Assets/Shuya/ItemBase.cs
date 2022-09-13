using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemBase : MonoBehaviour
{
    public abstract void Activate1();
    public abstract void Activate2();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player1"))
        {
            Activate1();
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("Player2"))
        {
            Activate2();
            Destroy(this.gameObject);
        }
    }
}
