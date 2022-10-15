using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ozyama : MonoBehaviour
{
    [SerializeField] GameObject[] _ozyama = new GameObject[1];

    int count = 0;

    GameManager _gm;
    void Start()
    {
        _gm = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SetOzyama();
    }


    void SetOzyama()
    {
        if (_gm._timeCount <= 10 && count == 2)
        {
            count++;
            var a = Random.Range(0, _ozyama.Length);
            Instantiate(_ozyama[a]);
        }
        else if (_gm._timeCount <= 30 && count == 1)
        {
            count++;
            var a = Random.Range(0, _ozyama.Length);
            Instantiate(_ozyama[a]);
        }
        else if (_gm._timeCount <= 50 && count == 0)
        {
            count++;
            var a = Random.Range(0, _ozyama.Length);
            Instantiate(_ozyama[a]);
        }
    }

}
