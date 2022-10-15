using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  // DOTween を使うため
public class GameManager : MonoBehaviour
{
    [Header("ゲーム時間")]
    [Tooltip("ゲーム時間")] [SerializeField]public float _timeCount;

    [Header("プレイヤー1のオブジェクト")]
    [Tooltip("プレイヤー1のオブジェクト")] [SerializeField] GameObject _player1;

    [Header("プレイヤー2のオブジェクト")]
    [Tooltip("プレイヤー2のオブジェクト")] [SerializeField] GameObject _player2;

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


    [Header("ゲーム中のBGM")]
    [Tooltip("ゲーム中のBGM")] [SerializeField] GameObject _gameAudio;
    [Header("リザルト画面のBGM")]
    [Tooltip("リザルト画面のBGM")] [SerializeField] GameObject _endAudio;

    [SerializeField] List<GameObject> _deleteGameObject = new List<GameObject>();

    /// <summary>P1のスコア</summary>
    int _player1Score = 0;
    /// <summary>P2のスコア</summary>
    int _player2Score = 0;

    /// <summary>ゲーム中かどうかの判断</summary>
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


                ///曲の変更

                if (!_one)
                {
                    _one = true;

                    _gameAudio.SetActive(false);
                    _endAudio.SetActive(true);
                }


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



    /// <summary>スコア追加メソッド</summary>
    /// <param name="playerNumber">プレイヤー識別番号</param>
    /// <param name="addScore">追加するスコアの量</param>
    public void AddScore(int playerNumber, int addScore)
    {
        if (playerNumber == 1)
        {
            int tempScore = _player1Score; // 追加前のスコア

            _player1Score += addScore;

            if (_player1Score >= 0)
            {
                // DOTween.To() を使って連続的に変化させる
                DOTween.To(() => tempScore, // 連続的に変化させる対象の値
                    x => tempScore = x, // 変化させた値 x をどう処理するかを書く
                    _player1Score, // x をどの値まで変化させるか指示する
                    0.5f)   // 何秒かけて変化させるか指示する
                    .OnUpdate(() => _scoreP1.text = tempScore.ToString())   // 数値が変化する度に実行する処理を書く
                    .OnComplete(() => _scoreP1.text = _player1Score.ToString());   // 数値の変化が完了した時に実行する処理を書く
            }
            else
            {
                _player1Score = 0;
            }
            _scoreP1.text = _player1Score.ToString();
        }
        else if (playerNumber == 2)
        {
            int tempScore = _player2Score; // 追加前のスコア


            _player2Score += addScore;
            if (_player2Score >= 0)
            {
                // DOTween.To() を使って連続的に変化させる
                DOTween.To(() => tempScore, // 連続的に変化させる対象の値
                    x => tempScore = x, // 変化させた値 x をどう処理するかを書く
                    _player2Score, // x をどの値まで変化させるか指示する
                    0.5f)   // 何秒かけて変化させるか指示する
                    .OnUpdate(() => _scoreP2.text = tempScore.ToString())   // 数値が変化する度に実行する処理を書く
                    .OnComplete(() => _scoreP2.text = _player2Score.ToString());   // 数値の変化が完了した時に実行する処理を書く
            }
            else
            {
                _player2Score = 0;
            }
            _scoreP2.text = _player2Score.ToString();
        }





    }


    /// <summary>ゲーム開始のカウントをするコルーチン</summary>
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

        ////プレイヤーを出す
        //if (_player1 &&_player2) //nullチェック
        //{
        //    _player1.SetActive(true);
        //    _player2.SetActive(true);
        //}

        yield return new WaitForSeconds(1);
        _startCountText.text = "";
    }



}

