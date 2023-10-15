using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bird : MonoBehaviour
{
    public float rotatePower;
    public float jumpSpeed;
    public TMP_Text scoreText;
    public float speed;
    public GameObject Endscreen;
    public GameObject yellowbird;
    public GameObject bluebird;
    public GameObject redbird;
    public GameObject DayBackground;
    public GameObject NightBackground;
    int score;
    Rigidbody2D rb;
    
    void Start()
    {

       
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
        RandomizeBirdSkin();
        RandomizeBackground();

    }
    void RandomizeBirdSkin()
    {
        int randomIndex = Random.Range(1, 4);
        print(randomIndex);
        switch (randomIndex)
        {
            case 1:
                yellowbird.SetActive(true);
                break;
            case 2:
                bluebird.SetActive(true);
                break;
            case 3:
                redbird.SetActive(true);
                break;


        }
    }
    void RandomizeBackground()
    {
        int randomIndex = Random.Range(1, 3);
        switch (randomIndex)
        {
            case 1:
                DayBackground.SetActive(true);
                break;
            case 2:
                NightBackground.SetActive(true);
                break;
        }

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }
    void Die()
        {
        jumpSpeed = 0;
        Pipe.speed = 0;
        
        Invoke("ShowMenu", 1f);
        //var currentScene = SceneManager.GetActiveScene().name;
        //SceneManager.LoadScene(currentScene);
    }
    void ShowMenu()
    {
        Endscreen.SetActive(true);
        scoreText.gameObject.SetActive(false);
       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        score++;
        scoreText.text = score.ToString();
    }
}