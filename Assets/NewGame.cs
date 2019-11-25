using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewGame : MonoBehaviour
{
    public GameObject ball;
    public GameObject gameOverScreen;
    public List<GameObject> activeBalls;
    public bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        ball = Instantiate(ball);
        ball.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 0));
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver)
        {
            for (int i = 0; i < activeBalls.Count; i++)
            {
                GameObject tmp = activeBalls[i];
                tmp.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                tmp.GetComponent<Rigidbody2D>().angularVelocity = 0;
                tmp.GetComponent<Rigidbody2D>().isKinematic = true;
            }
            Instantiate(gameOverScreen);
            GameObject.Find("Player").GetComponent<Player>().transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.Find("Player").GetComponent<Player>().transform.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }
        
    }
}
