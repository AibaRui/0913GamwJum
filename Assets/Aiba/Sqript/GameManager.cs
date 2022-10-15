using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  // DOTween ���g������
public class GameManager : MonoBehaviour
{
    [Header("�Q�[������")]
    [Tooltip("�Q�[������")] [SerializeField]public float _timeCount;

    [Header("�v���C���[1�̃I�u�W�F�N�g")]
    [Tooltip("�v���C���[1�̃I�u�W�F�N�g")] [SerializeField] GameObject _player1;

    [Header("�v���C���[2�̃I�u�W�F�N�g")]
    [Tooltip("�v���C���[2�̃I�u�W�F�N�g")] [SerializeField] GameObject _player2;

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


    [Header("�Q�[������BGM")]
    [Tooltip("�Q�[������BGM")] [SerializeField] GameObject _gameAudio;
    [Header("���U���g��ʂ�BGM")]
    [Tooltip("���U���g��ʂ�BGM")] [SerializeField] GameObject _endAudio;

    [SerializeField] List<GameObject> _deleteGameObject = new List<GameObject>();

    /// <summary>P1�̃X�R�A</summary>
    int _player1Score = 0;
    /// <summary>P2�̃X�R�A</summary>
    int _player2Score = 0;

    /// <summary>�Q�[�������ǂ����̔��f</summary>
    public bool _isGame = false;

    public float _enemySpeed = 0.1f;

    bool _one;
    void Start()
    {
        StartCoroutine(StartCount());
    }


    void Update()
    {
        if (_isGame)
        {
            _timeCount -= Time.deltaTime;
            _timeCountText.text = _timeCount.ToString("F0");

            if (_timeCount < 0)
            {


                ///�Ȃ̕ύX

                if (!_one)
                {
                    _one = true;

                    _gameAudio.SetActive(false);
                    _endAudio.SetActive(true);
                }


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
                _isGame = false;
            }
        }
        SpeedUpEnemy();
    }

    void SpeedUpEnemy()
    {
        if (_timeCount <= 20)
        {
            _enemySpeed = 0.3f;
        }
        else if (_timeCount <= 40)
        {
            _enemySpeed = 0.2f;
        }
        else if (_timeCount <= 50)
        {
            _enemySpeed = 0.15f;
        }
    }



    /// <summary>�X�R�A�ǉ����\�b�h</summary>
    /// <param name="playerNumber">�v���C���[���ʔԍ�</param>
    /// <param name="addScore">�ǉ�����X�R�A�̗�</param>
    public void AddScore(int playerNumber, int addScore)
    {
        if (playerNumber == 1)
        {
            int tempScore = _player1Score; // �ǉ��O�̃X�R�A

            _player1Score += addScore;

            if (_player1Score >= 0)
            {
                // DOTween.To() ���g���ĘA���I�ɕω�������
                DOTween.To(() => tempScore, // �A���I�ɕω�������Ώۂ̒l
                    x => tempScore = x, // �ω��������l x ���ǂ��������邩������
                    _player1Score, // x ���ǂ̒l�܂ŕω������邩�w������
                    0.5f)   // ���b�����ĕω������邩�w������
                    .OnUpdate(() => _scoreP1.text = tempScore.ToString())   // ���l���ω�����x�Ɏ��s���鏈��������
                    .OnComplete(() => _scoreP1.text = _player1Score.ToString());   // ���l�̕ω��������������Ɏ��s���鏈��������
            }
            else
            {
                _player1Score = 0;
            }
            _scoreP1.text = _player1Score.ToString();
        }
        else if (playerNumber == 2)
        {
            int tempScore = _player2Score; // �ǉ��O�̃X�R�A


            _player2Score += addScore;
            if (_player2Score >= 0)
            {
                // DOTween.To() ���g���ĘA���I�ɕω�������
                DOTween.To(() => tempScore, // �A���I�ɕω�������Ώۂ̒l
                    x => tempScore = x, // �ω��������l x ���ǂ��������邩������
                    _player2Score, // x ���ǂ̒l�܂ŕω������邩�w������
                    0.5f)   // ���b�����ĕω������邩�w������
                    .OnUpdate(() => _scoreP2.text = tempScore.ToString())   // ���l���ω�����x�Ɏ��s���鏈��������
                    .OnComplete(() => _scoreP2.text = _player2Score.ToString());   // ���l�̕ω��������������Ɏ��s���鏈��������
            }
            else
            {
                _player2Score = 0;
            }
            _scoreP2.text = _player2Score.ToString();
        }





    }


    /// <summary>�Q�[���J�n�̃J�E���g������R���[�`��</summary>
    IEnumerator StartCount()
    {
        _startCountText.text = "  3";
        yield return new WaitForSeconds(1);
        _startCountText.text = "  2";
        yield return new WaitForSeconds(1);
        _startCountText.text = "  1";
        yield return new WaitForSeconds(1);
        _startCountText.text = "Start";
        _isGame = true;
        _deleteGameObject.ForEach(i => Destroy(i));

        ////�v���C���[���o��
        //if (_player1 &&_player2) //null�`�F�b�N
        //{
        //    _player1.SetActive(true);
        //    _player2.SetActive(true);
        //}

        yield return new WaitForSeconds(1);
        _startCountText.text = "";
    }



}

