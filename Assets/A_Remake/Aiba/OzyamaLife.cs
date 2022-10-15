using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OzyamaLife : MonoBehaviour
{
    [SerializeField] float _time = 10;
    void Update()
    {
        _time -= Time.deltaTime;

        if(_time<=0)
        {
            Destroy(gameObject);
        }
    }
}
