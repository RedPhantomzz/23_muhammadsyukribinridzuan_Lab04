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
        ScoreText.text = "Score : " + Score;

        if (Score == 5 && CurrentScene.name == "Gameplay_Level1")
            SceneManager.LoadScene("Gameplay_Level2");
        else if (Score == 5 && CurrentScene.name == "Gameplay_Level2")
            SceneManager.LoadScene("GameWin");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Coin"))
        {
            Score += 1;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.CompareTag("Hazard"))
        {
            SceneManager.LoadScene("GameLose");
        }
    }
}
