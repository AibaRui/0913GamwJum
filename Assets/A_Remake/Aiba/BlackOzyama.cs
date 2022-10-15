using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BlackOzyama : MonoBehaviour
{
    [SerializeField] GameObject _black;
    [SerializeField] GameObject _p1Mask;
    [SerializeField] GameObject _p2Mask;

    List<GameObject> a = new List<GameObject>(3);

    [SerializeField] float _time;
    GameObject _p1;
    GameObject _p2;

    void Start()
    {

        a.Add(Instantiate(_black));
        a.Add(Instantiate(_p1Mask));
        a.Add(Instantiate(_p2Mask));

        a.ForEach(i => i.transform.SetParent(transform));

        _p1 = GameObject.FindGameObjectWithTag("Player1");
        _p2 = GameObject.FindGameObjectWithTag("Player2");
    }

    // Update is called once per frame
    void Update()
    {
        a[0].transform.position = new Vector3(-2.42f, -18.89656f, 0);
        a[1].transform.position = _p1.transform.position;
        a[2].transform.position = _p2.transform.position;

        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            Destroy(gameObject);
        }
    }
}
