using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("�Q�[������")]
    [Tooltip("�Q�[������")] [SerializeField] float _timeCount;

    [Header("�v���C���[1�̃I�u�W�F�N�g")]
    [Tooltip("�v���C���[1�̃I�u�W�F�N�g")] [SerializeField] GameObject _player1;

    [Header("�v���C���[1���o���ꏊ")]
    [Tooltip("�v���C���[1���o���ꏊ")] [SerializeField] Transform _player1InstantiatePos;

    [Header("�v���C���[2�̃I�u�W�F�N�g")]
    [Tooltip("�v���C���[2�̃I�u�W�F�N�g")] [SerializeField] GameObject _player2;

    [Header("�v���C���[2���o���ꏊ")]
    [Tooltip("�v���C���[2���o���ꏊ")] [SerializeField] Transform _player2InstantiatePos;

    [Header("�Q�[���J�n�J�E���g�p�̃e�L�X�g")]
    [Tooltip("�Q�[���J�n�J�E���g�p�̃e�L�X�g")] [SerializeField] Text _startCountText;

    [Header("�Q�[�����ԃJ�E���g�p�̃e�L�X�g")]
    [Tooltip("�Q�[�����ԃJ�E���g�p�̃e�L�X�g")] [SerializeField] Text _timeCountText;

    [Header("�v���C���[1�̃X�R�A�e�L�X�g")]
    [Tooltip("�v���C���[1�̃X�R�A�e�L�X�g")] [SerializeField] Text _scoreP1;

    [Header("�v���C���[2�̃X�R�A�e�L�X�g")]
    [Tooltip("�v���C���[2�̃X�R�A�e�L�X�g")] [SerializeField] Text _scoreP2;

    [Header("Player1�����p�l��")]
    [Tooltip("Player1�����p�l��")] [SerializeField] GameObject _p1WinnerPanel;

    [Header("Player2�����p�l��")]
    [Tooltip("Player2�����p�l��")] [SerializeField] GameObject _p2WinnerPanel;

    [Header("���������p�l��")]
    [Tooltip("���������p�l��")] [SerializeField] GameObject _DrawPanel;


    [SerializeField] AudioSource _gameAudio;
    [SerializeField] AudioSource _endAudio;

    /// <summary>P1�̃X�R�A</summary>
    int _player1Score = 2;
    /// <summary>P2�̃X�R�A</summary>
    int _player2Score = 0;

    /// <summary>�Q�[�������ǂ����̔��f</summary>
    bool _isGame = false;
    void Start()
    {
        _gameAudio = gameObject.GetComponent<AudioSource>();
        _endAudio = _endAudio.gameObject.GetComponent<AudioSource>();
        StartCoroutine(StartCount());
    }


    void Update()
    {
        if (_isGame)
        {
            _timeCount -= Time.deltaTime;
            _timeCountText.text = _timeCount.ToString("F0");

            if (_timeCount == 0)
            {
                _isGame = false;


                ///�Ȃ̕ύX
                _gameAudio.Stop();
                _endAudio.Play();

                ///���s�ɉ������p�l����\��

                if (_player1Score > _player2Score)    //P1����
                {
                    _p1WinnerPanel.SetActive(true);
                }
                else if (_player1Score < _player2Score)//P2����
                {
                    _p2WinnerPanel.SetActive(true);
                }
                else if (_player1Score == _player2Score)//��������
                {
                    _DrawPanel.SetActive(true);
                }
            }

        }
    }

    /// <summary>�X�R�A�ǉ����\�b�h</summary>
    /// <param name="playerNumber">�v���C���[���ʔԍ�</param>
    /// <param name="addScore">�ǉ�����X�R�A�̗�</param>
    public void AddScore(int playerNumber, int addScore)
    {
        if (playerNumber == 1)
        {
            _player1Score += addScore;
            _scoreP1.text = _player1Score.ToString();
        }
        else if (playerNumber == 2)
        {
            _player2Score += addScore;
            _scoreP2.text = _player2Score.ToString();
        }
    }



    /// <summary>�Q�[���J�n�̃J�E���g������R���[�`��</summary>
    IEnumerator StartCount()
    {
        _startCountText.text = "3";
        yield return new WaitForSeconds(1);
        _startCountText.text = "2";
        yield return new WaitForSeconds(1);
        _startCountText.text = "1";
        yield return new WaitForSeconds(1);
        _startCountText.text = "Start";
        _isGame = true;
        yield return new WaitForSeconds(1);
        _startCountText.text = "";

        //�v���C���[���o��
        if (_player1 && _player1InstantiatePos && _player2 && _player2InstantiatePos) //null�`�F�b�N
        {
            var go1 = Instantiate(_player1);
            go1.transform.position = _player1InstantiatePos.position;
            var go2 = Instantiate(_player2);
            go2.transform.position = _player2InstantiatePos.position;
        }
    }



}

