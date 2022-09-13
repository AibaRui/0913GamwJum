using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] string _up;
    [SerializeField] string _down;
    [SerializeField] string _left;
    [SerializeField] string _right;
    Rigidbody _rb;

    int _index;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        _rb.velocity = new Vector3(_index*_speed,0,0);
    }

    void Move()
    {
        
    }
}
