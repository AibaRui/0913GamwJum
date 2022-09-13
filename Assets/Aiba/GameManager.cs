using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [Header("ゲーム時間")]
    [Tooltip("ゲーム時間")] [SerializeField] float _timeCount;

    [Header("プレイヤー1のオブジェクト")]
    [Tooltip("プレイヤー1のオブジェクト")] [SerializeField] GameObject _player1;

    [Header("プレイヤー1を出す場所")]
    [Tooltip("プレイヤー1を出す場所")] [SerializeField] Transform _player1InstantiatePos;

    [Header("プレイヤー2のオブジェクト")]
    [Tooltip("プレイヤー2のオブジェクト")] [SerializeField] GameObject _player2;

    [Header("プレイヤー2を出す場所")]
    [Tooltip("プレイヤー2を出す場所")] [SerializeField] Transform _player2InstantiatePos;

    [Header("ゲーム開始カウント用のテキスト")]
    [Tooltip("ゲーム開始カウント用のテキスト")] [SerializeField] Text _startCountText;

    [Header("ゲーム時間カウント用のテキスト")]
    [Tooltip("ゲーム時間カウント用のテキスト")] [SerializeField] Text _timeCountText;

    [Header("プレイヤー1のスコアテキスト")]
    [Tooltip("プレイヤー1のスコアテキスト")] [SerializeField] Text _scoreP1;

    [Header("プレイヤー2のスコアテキスト")]
    [Tooltip("プレイヤー2のスコアテキスト")] [SerializeField] Text _scoreP2;

    [Header("Player1勝利パネル")]
    [Tooltip("Player1勝利パネル")] [SerializeField] GameObject _p1WinnerPanel;

    [Header("Player2勝利パネル")]
    [Tooltip("Player2勝利パネル")] [SerializeField] GameObject _p2WinnerPanel;

    [Header("引き分けパネル")]
    [Tooltip("引き分けパネル")] [SerializeField] GameObject _DrawPanel;


    [SerializeField] AudioSource _gameAudio;
    [SerializeField] AudioSource _endAudio;

    /// <summary>P1のスコア</summary>
    int _player1Score = 2;
    /// <summary>P2のスコア</summary>
    int _player2Score = 0;

    /// <summary>ゲーム中かどうかの判断</summary>
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


                ///曲の変更
                _gameAudio.Stop();
                _endAudio.Play();

                ///勝敗に応じたパネルを表示

                if (_player1Score > _player2Score)    //P1勝利
                {
                    _p1WinnerPanel.SetActive(true);
                }
                else if (_player1Score < _player2Score)//P2勝利
                {
                    _p2WinnerPanel.SetActive(true);
                }
                else if (_player1Score == _player2Score)//引き分け
                {
                    _DrawPanel.SetActive(true);
                }
            }

        }
    }

    /// <summary>スコア追加メソッド</summary>
    /// <param name="playerNumber">プレイヤー識別番号</param>
    /// <param name="addScore">追加するスコアの量</param>
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



    /// <summary>ゲーム開始のカウントをするコルーチン</summary>
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

        //プレイヤーを出す
        if (_player1 && _player1InstantiatePos && _player2 && _player2InstantiatePos) //nullチェック
        {
            var go1 = Instantiate(_player1);
            go1.transform.position = _player1InstantiatePos.position;
            var go2 = Instantiate(_player2);
            go2.transform.position = _player2InstantiatePos.position;
        }
    }



}

