using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour
{

        float score;
        float highscore;

        public float JumpForce;

        [SerializeField]
        bool isGrounded = false;
        bool isAlive = true;

        Rigidbody2D RB;

    public Text ScoreTxt;
    public Text HighscoreTxt;

    private void Awake()
    {
        RB = GetComponent<Rigidbody2D>();
        score = 0;
        highscore = 0;
    }

    void Start()
    {
        HighscoreTxt.text = PlayerPrefs.GetFloat("Highscore", 0).ToString("F");
    }

        
    

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                RB.AddForce(Vector2.up * JumpForce);
                isGrounded = false;
            }
        }

        if(isAlive)
        {
            score += Time.deltaTime * 4;
            ScoreTxt.text = "SCORE : " + score.ToString("F");
            


            if(score > PlayerPrefs.GetFloat("Highscore", 0 ))
            {
                PlayerPrefs.SetFloat("Highscore", score);
            }
            
           
        }
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("ground"))
        {
                if(isGrounded == false)
                {
                    isGrounded = true;
                }
        }

        if (collision.gameObject.CompareTag("spike"))
        {
            
            SceneManager.LoadScene("SampleScene");
        }

    }
}
