using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Bird : MonoBehaviour
{
    private Rigidbody2D rigidbody; // check vật lý
    private SpriteRenderer spriteRenderer; // animation cho chim
    public Sprite[] sprites;
    private int spriteIndex;
    #region Hiển thị điểm
    private int score;
    public Text scoreText;
    public Text scoreTextInEnd;
    public Text bestText;
    #endregion

    #region Animation và di chuyển của chim
    public float junpForce;
    public float initZ;
    #endregion

    #region GameObject
    public GameObject gameController;
    public GameObject tutorial;
    public GameObject buttonOut;
    public GameObject gameOver;
    public GameObject textScore;
    public GameObject textBest;
    public GameObject soundController;
    #endregion
    private bool check;
    private int best;
    private bool gameStart; // kiểm tra game đã bắt đầu chưa
    private void Awake()
    {
        #region khởi tạo 
        check = false;
        spriteRenderer = this.gameObject.GetComponent<SpriteRenderer>();
        rigidbody = this.gameObject.GetComponent<Rigidbody2D>();
        gameStart = false;
        rigidbody.gravityScale = 0;
        initZ = 0;
        score = 0;
        
        scoreText.text = score.ToString();
        #endregion

        #region ẩn các text
        scoreText.GetComponent<Text>().enabled = false;
        gameController.GetComponent<PineGener>().agreeGener = false;
        gameOver.GetComponent<SpriteRenderer>().enabled = false;
        textScore.GetComponent<SpriteRenderer>().enabled = false;
        textBest.GetComponent<SpriteRenderer>().enabled = false;
        scoreTextInEnd.GetComponent<Text>().enabled = false;
        bestText.GetComponent<Text>().enabled=false;
        #endregion


    }

    private void Start()
    {
        InvokeRepeating(nameof(BirdFlying), 0.15f, 0.15f);
    }
    // Update is called once per frame
    void Update()
    {
        #region Tap to play

        if (Input.GetMouseButtonDown(0))
        {
            
            soundController.GetComponent<SoundController>().PlayThisSound("wing", 0.5f);
            //Debug.Log(this.gameObject.ToString());
            if (gameStart == false)
            {
                //Debug.Log(Time.timeScale);
                tutorial.GetComponent<SpriteRenderer>().enabled = false;
                gameStart = true;
                rigidbody.gravityScale = 2f;
                gameController.GetComponent<PineGener>().agreeGener = true;
                scoreText.GetComponent<Text>().enabled = true;

            }
            
             if(Time.timeScale == 1) BirdMoveUp();
        }
        else
        {
            if(gameStart == true )
            {
                if(check == false) BirdMoveDown();
            }
        }
        #endregion
    }

    private void BirdMoveDown() // chim cắm đầu xuống đất
    {
        
        transform.rotation = Quaternion.Euler(0, 0, initZ);
        initZ -= 1.5f;
    }
    private void BirdMoveUp() // làm chim bay lên
    {
        
        rigidbody.velocity = Vector2.up * junpForce;
        while (initZ <= 20f)
        {
            initZ += 4f;
            transform.rotation = Quaternion.Euler(0, 0, initZ);
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision) // va chạm bật ra
    {
        check = true;
        Time.timeScale = 0;
        gameStart = false;
        soundController.GetComponent<SoundController>().PlayThisSound("hit", 0.5f);
        Show();
        soundController.GetComponent<SoundController>().PlayThisSound("die", 0.5f);
    }

    private void OnTriggerEnter2D(Collider2D collision) // va chạm nhưng xuyên qua
    {
        score += 1;
        soundController.GetComponent<SoundController>().PlayThisSound("point", 0.5f);
        scoreText.text = score.ToString();
    }
    private void Show() // hiển thị kết quả
    {
         // dừng hình ảnh trong Scene hiện tại
        #region load kỉ lục
        SaveHightScore(score);
        scoreTextInEnd.text = scoreText.text;
        bestText.text = LoadHightScore().ToString();
        #endregion

        #region hiển thị endgame
        scoreText.GetComponent<Text>().enabled = false;
        gameOver.GetComponent<SpriteRenderer>().enabled = true;
        textScore.GetComponent<SpriteRenderer>().enabled = true;
        buttonOut.GetComponent<Image>().enabled = true;
        scoreTextInEnd.GetComponent<Text>().enabled = true;
        bestText.GetComponent<Text>().enabled = true;
        textBest.GetComponent<SpriteRenderer>().enabled = true;

        #endregion
    }

    private void SaveHightScore(int score)
    {
        if (score > PlayerPrefs.GetInt("HightScore", 0))
        {
            best = score;
            PlayerPrefs.SetInt("HightScore", score);
            PlayerPrefs.Save();
        }
    }

    private int LoadHightScore()
    {
        return PlayerPrefs.GetInt("HightScore", best);
    }

    private void BirdFlying()
    {
        spriteIndex++;
        if (spriteIndex >= sprites.Length) { spriteIndex = 0;}

        spriteRenderer.sprite = sprites[spriteIndex];

    }
}
