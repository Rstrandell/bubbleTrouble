using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Vector2 currentVelocity;
    // Start is called before the first frame update
    void Start()
    {
        transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(500, 0));
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(transform.GetComponent<Rigidbody2D>().velocity);
        currentVelocity = transform.GetComponent<Rigidbody2D>().velocity;


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            Vector2 tmp = new Vector2(currentVelocity.x, currentVelocity.y * -1);
            Debug.Log(tmp.y+"");
            
        }
    }
}
