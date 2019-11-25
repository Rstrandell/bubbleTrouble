using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewGame : MonoBehaviour
{
   // public GameObject ball;
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public List<GameObject> activeBalls;
    public bool gameOver;
    public int[] startPos;
    public int level;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        // ball = Instantiate(ball);
        // activeBalls.Add(ball);
        int direction = 1;
        for (int i = 0; i < activeBalls.Count; i++)
        {
            activeBalls[i] = Instantiate(activeBalls[0], new Vector2(startPos[i], 4), transform.rotation);
            activeBalls[i].transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(250 * direction, 0));
            direction *= -1;
        }
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
            GameObject.Find("Player").GetComponent<Player>().transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GameObject.Find("Player").GetComponent<Player>().transform.GetComponent<Rigidbody2D>().angularVelocity = 0;
        }

        if (activeBalls.Count == 0)
        {
            if (level == 1)
            {
                SceneManager.LoadScene("LevelTwo");
            }
            else
            {
                Instantiate(winScreen);
            }
        }
        
    }
}
