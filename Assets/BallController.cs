using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    //ボールが見える可能性のあるz軸の最大値
    private float visiblePosZ = -6.5f;

    //ゲームオーバーを表示するテキスト
    private GameObject gameoverText;

    //スコアを表示するテキスト
    private GameObject ScoreText;

    private int Score = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.ScoreText.GetComponent<Text>().text = "Score: " + this.Score;
        //シーン中のGameOverTextオブジェクトを取得
        this.gameoverText = GameObject.Find("GameOverText");

        //シーン内のScoreTextオブジェクトを取得
        this.ScoreText = GameObject.Find("ScoreText");
    }

    // Update is called once per frame
    void Update()
    {
        //ボールが画面外に出た場合
        if (this.transform.position.z < this.visiblePosZ)
        {
            //GameOverTextにゲームオーバーを表示
            this.gameoverText.GetComponent<Text>().text = "Game Over";
        }
        //ScoreTextを表示
       
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "SmallStarTag")
        {
            this.Score += 5;
        }
        else if (other.gameObject.tag == "LargeStarTag")
        {
            this.Score += 10;
        }
        else if (other.gameObject.tag == "SmallCloudTag")
        {
            this.Score += 50;
        }
        else if (other.gameObject.tag == "LargeCloudTag")
        {
            this.Score += 100;
        }
        this.ScoreText.GetComponent<Text>().text = "Score: " + this.Score;
    }
}

