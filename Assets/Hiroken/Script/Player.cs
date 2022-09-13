using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float _speed;
    //[SerializeField] string _up;
    //[SerializeField] string _down;
    //[SerializeField] string _left;
    //[SerializeField] string _right;
    Rigidbody2D _rb;
    [Tooltip("縦の移動速度")] public float verticalInput;
    [Tooltip("横の移動速度")] public float horizontalInput;

    int _index;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        horizontalInput = _speed * 1;
        verticalInput = _speed * 0;
    }
    void Update()
    {
        if (gameObject.tag == "Player")
        {
            Debug.Log("Player_One");
            MovePlayer_One();
        }
        if (gameObject.tag == "PlayerTwo")
        {
            Debug.Log("Player_Two");
            MovePlayer_Two();
        }
    }

    /// <summary>
    /// Player1の移動処理(WASD)
    /// </summary>
    void MovePlayer_One()
    {
        //float verticalInput = _speed * Input.GetAxisRaw("Vertical");
        //float horizontalInput = _speed * Input.GetAxisRaw("Horizontal");
        //_rb.velocity = new Vector2(horizontalInput, verticalInput);

        if (Input.GetButtonDown("Vertical")) //W,S
        {
            float vertical = Input.GetAxis("Vertical");

            if (vertical > 0) //W
            {
                verticalInput = _speed;
                horizontalInput = 0;
            }
            else if (vertical < 0) //S
            {
                verticalInput = -_speed;
                horizontalInput = 0;
            }
        }
        if (Input.GetButtonDown("Horizontal")) //A,D
        {
            float horizontal = Input.GetAxis("Horizontal");

            if (horizontal > 0) //A
            {
                verticalInput = 0;
                horizontalInput = _speed;
            }
            else if (horizontal < 0) //D
            {
                verticalInput = 0;
                horizontalInput = -_speed;
            }
        }
        _rb.velocity = new Vector2(horizontalInput, verticalInput);
    }

    /// <summary>
    /// Player2の移動処理(矢印キー)
    /// </summary>
    void MovePlayer_Two()
    {
        if (Input.GetButtonDown("Vertical2")) //上下
        {
            float vertical = Input.GetAxis("Vertical2");

            if (vertical > 0) //上
            {
                verticalInput = _speed;
                horizontalInput = 0;
            }
            else if (vertical < 0) //下
            {
                verticalInput = -_speed;
                horizontalInput = 0;
            }
        }
        if (Input.GetButtonDown("Horizontal2")) //左右
        {
            float horizontal = Input.GetAxis("Horizontal2");

            if (horizontal > 0) //左
            {
                verticalInput = 0;
                horizontalInput = _speed;
            }
            else if (horizontal < 0) //右
            {
                verticalInput = 0;
                horizontalInput = -_speed;
            }
        }
        _rb.velocity = new Vector2(horizontalInput, verticalInput);
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        horizontalInput = 0;
        verticalInput = 0;
    }
    public void AddSpeed1(int _spd)
    {
        _speed += _spd;
        StartCoroutine(RemoveSpeed(_spd));
    }
    public void AddSpeed2(int _spd)
    {
        _speed += _spd;
        StartCoroutine(RemoveSpeed(_spd));
    }

    IEnumerator RemoveSpeed(int _spd)
    {
        yield return new WaitForSeconds(1);
        _speed -= _spd;
    }
}
