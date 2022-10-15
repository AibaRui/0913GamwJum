using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [Header("アイテム")]
    [Tooltip("アイテム")] [SerializeField] GameObject[] _Item = new GameObject[2];

    [Header("特殊アイテム")]
    [Tooltip("特殊アイテム")] [SerializeField] GameObject[] _specialItem = new GameObject[2];

    [Header("生成間隔")]
    [Tooltip("生成間隔")] [SerializeField] float _time = 5;

    [Header("アイテム出現の場所")]
    [Tooltip("アイテム出現の場所")] [SerializeField] List<GameObject> _pos = new List<GameObject>();

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
            var rm = Random.Range(0, _pos.Count / 2);

            var noItemZone = _pos.Where(i => i.transform.childCount == 0).ToList();
            var r = Random.Range(0, noItemZone.Count);

            if (noItemZone.Count >= _itemNum)
            {
                for (int i = 0; i < _itemNum; i++)
                {
                    if (r + i < noItemZone.Count)
                    {
                        if (noItemZone[r + i].gameObject.transform.childCount == 0) //その場にアイテムがなかったら
                        {
                            var itemR = Random.Range(1, _Item.Length);
                            if (i>1)
                            {
                                itemR = 0;
                            }
                            var go = Instantiate(_Item[itemR]);
                            go.transform.position = noItemZone[r + i].transform.position;
                            go.transform.SetParent(noItemZone[r + i].transform);
                        }
                    }
                }
            }
            Debug.Log("3");
            StartCoroutine(Count());
        }
        else if (_isSpecial)
        {
            var itemR = Random.Range(0, _Item.Length);

            Debug.Log("Specilal");
            for (int i = 0; i < _pos.Count; i++)
            {
                var r = Random.Range(0, _pos.Count);
                if (_pos[r].transform.childCount == 0)
                {
                    var go = Instantiate(_Item[itemR]);
                    go.transform.position = _pos[r].transform.position;
                    go.transform.SetParent(_pos[r].transform);
                    break;
                }
            }
            StartCoroutine(Count());
        }
    }

}
