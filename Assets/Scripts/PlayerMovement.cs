using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float 
        speed,Score;

    Rigidbody PlayerRigidBody;

    public Text ScoreText;
    public Text TimerTxt;
    float Timer = 30f;
    public GameObject CoinParticle;

    Scene CurrentScene;
   
    void Start()
    {
        PlayerRigidBody = GetComponent<Rigidbody>();
        CurrentScene = SceneManager.GetActiveScene();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);
        PlayerRigidBody.AddForce(movement * speed * Time.deltaTime);
    }

    void Update()   
    {
        ScoreText.text = "Score : " + Score.ToString();

        // Lvl 1 Win Condition
        if (Score == 5 && CurrentScene.name == "Gameplay_Level1")
            SceneManager.LoadScene("Gameplay_Level2");

        // Lvl 2 Win Condition
        else if (Score == 5 && CurrentScene.name == "Gameplay_Level2")
            SceneManager.LoadScene("Gameplay_Level3");

        // Lvl 3 Win Condition
        else if (Score == 5 && CurrentScene.name == "Gamplay_Level3")
            SceneManager.LoadScene("GameWin");

        // For the timer in Lvl 3
        if (CurrentScene.name == "Gameplay_Level3")
        {
            TimerTxt.text = "Timer: " + Timer.ToString("0");
            Timer -= Time.deltaTime;
            if (Timer <= 0)
            {
                SceneManager.LoadScene("GameLose");
            }
        }
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Lose condition
        if(collision.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Collecting coins
        if (other.gameObject.tag == "Coin")
        {
            Instantiate(CoinParticle, transform.position, transform.rotation);
            Score += 1;
            Destroy(other.gameObject);
        }
    }
}
