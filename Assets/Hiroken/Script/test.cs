using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] string _up;
    [SerializeField] string _down;
    [SerializeField] string _left;
    [SerializeField] string _right;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown(_up))
        {
            Debug.Log("up");
        }
       if (Input.GetButtonDown(_down))
        {
            Debug.Log("d");
        }
      if (Input.GetButtonDown(_left))
        {
            Debug.Log("l");
        }
        if (Input.GetButtonDown(_right))
        {
            Debug.Log("r");
        }
    }
}
