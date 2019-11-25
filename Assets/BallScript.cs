using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector2 currentVelocity;
    private NewGame manager;
    // Start is called before the first frame update
    void Start()
    {
        // transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(250, 0));
        manager = GameObject.Find("Manager").GetComponent<NewGame>();



    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameOver)
        {
            currentVelocity = transform.GetComponent<Rigidbody2D>().velocity;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.tag == "player")
        {
            GameObject.Find("Manager").GetComponent<NewGame>().gameOver = true;
            gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0;
            gameObject.GetComponent<Rigidbody2D>().isKinematic = true;
            Instantiate(manager.gameOverScreen);
        }
    }
}
