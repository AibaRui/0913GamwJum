using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Mazyo : MonoBehaviour
{
    [SerializeField] List<GameObject> _ga = new List<GameObject>();

    [SerializeField] List<GameObject> _sprite = new List<GameObject>();

    List<GameObject> _obake = new List<GameObject>();

    [SerializeField] float _time = 10;

    void Start()
    {
        transform.position = new Vector3(-2, -4, 0);
        _obake = GameObject.FindGameObjectsWithTag("Enemy").ToList();

        for (int i = 0; i < _obake.Count; i++)
        {
            var r = Random.Range(0, _sprite.Count);
            var go = Instantiate(_sprite[r]);
            go.transform.position = _obake[i].transform.position;
            go.transform.SetParent(_obake[i].transform);
            _ga.Add(go);
        }
    }

    // Update is called once per frame
    void Update()
    {
        _time -= Time.deltaTime;

        if (_time <= 0)
        {
            _ga.ForEach(i => Destroy(i));
            Destroy(gameObject);
        }
    }
}
