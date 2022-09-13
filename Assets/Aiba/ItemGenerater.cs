using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [Header("アイテム")]
    [Tooltip("アイテム")] [SerializeField] GameObject _Item;

    [Header("生成間隔")]
    [Tooltip("生成間隔")] [SerializeField] float _time = 5;

    [Header("アイテム出現の場所")]
    [Tooltip("アイテム出現の場所")] [SerializeField] GameObject[] _pos = new GameObject[6];

    [Header("1回数に出すアイテム数")]
    [Tooltip("1回数に出すアイテム数")] [SerializeField] int _itemNum;


    [Header("Trueだったら特殊アイテム。Falseだったらスコアアイテム")]
    [Tooltip("1回数に出すアイテム数")] [SerializeField] bool _isSpecial = false;

    bool _isIns = true;
    bool _sp = false;

    void Start()
    {

        {

        }
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<GameManager>()._isGame)
        {
            if (_isIns)
            {
                Instasiate();
                _isIns = false;
            }
        }
    }

    IEnumerator Count()
    {
        yield return new WaitForSeconds(_time);
        _isIns = true;
        Debug.Log("cor");
    }

    void Instasiate()
    {
        if (!_isSpecial)
        {
            var r = Random.Range(0, _pos.Length);
            var num = Random.Range(1, 4);

            for (int i = 0; i < _itemNum; i++)
            {
                Debug.Log("2");
                if (r + i > _pos.Length)
                {
                    if (_pos[r + i].gameObject.transform.childCount == 0) //その場にアイテムがなかったら
                    {
                            var go = Instantiate(_Item);
                            go.transform.position = _pos[r + i].transform.position;
                            go.transform.SetParent(_pos[r + i].transform);
                    }
                }
            }
            Debug.Log("3");
            StartCoroutine(Count());
        }
        else if (_isSpecial)
        {
            Debug.Log("aa");
            for (int i = 0; i < 10; i++)
            {
                Debug.Log("vv");
                var r = Random.Range(0, _pos.Length);
                if (_pos[r].transform.childCount == 0)
                {
                    var go = Instantiate(_Item);
                    go.transform.position = _pos[r].transform.position;
                    go.transform.SetParent(_pos[r].transform);
                    return;
                }



            }
            StartCoroutine(Count());



        }
    }

}
