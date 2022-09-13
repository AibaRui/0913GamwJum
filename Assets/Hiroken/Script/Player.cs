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
    Rigidbody2D _rb;
    [Tooltip("縦の移動速度")] float verticalInput;
    [Tooltip("横の移動速度")] float horizontalInput;

    int _index;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        verticalInput = _speed * 1;
        horizontalInput = _speed * 0;
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        //float verticalInput = _speed * Input.GetAxisRaw("Vertical");
        //float horizontalInput = _speed * Input.GetAxisRaw("Horizontal");
        //_rb.velocity = new Vector2(horizontalInput, verticalInput);

        //if (Input.GetButtonDown(_up))
        //{
        //    verticalInput = _speed;
        //}
        //else if (Input.GetButtonDown(_down))
        //{
        //    verticalInput = -_speed;
        //}
        //else if (Input.GetButtonDown(_left))
        //{
        //    horizontalInput = _speed;
        //}
        //else if (Input.GetButtonDown(_right))
        //{
        //    horizontalInput = -_speed;
        //}
        _rb.velocity = new Vector2(horizontalInput, verticalInput);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        horizontalInput = 0;
        verticalInput = 0;
    }
    public void AddSpeed1(int _addSpeed)
    {

    }
    public void AddSpeed2(int _addSpeed)
    {
        
    }
}
