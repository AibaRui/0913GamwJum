using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerater : MonoBehaviour
{
    [Header("�A�C�e��")]
    [Tooltip("�A�C�e��")] [SerializeField] GameObject _Item;

    [Header("�����Ԋu")]
    [Tooltip("�����Ԋu")] [SerializeField] float _time = 5;

    [Header("�A�C�e���o���̏ꏊ")]
    [Tooltip("�A�C�e���o���̏ꏊ")] [SerializeField] GameObject[] _pos = new GameObject[6];

    [Header("1�񐔂ɏo���A�C�e����")]
    [Tooltip("1�񐔂ɏo���A�C�e����")] [SerializeField] int _itemNum;


    [Header("True�����������A�C�e���BFalse��������X�R�A�A�C�e��")]
    [Tooltip("1�񐔂ɏo���A�C�e����")] [SerializeField] bool _isSpecial = false;

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
                    if (_pos[r + i].gameObject.transform.childCount == 0) //���̏�ɃA�C�e�����Ȃ�������
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
