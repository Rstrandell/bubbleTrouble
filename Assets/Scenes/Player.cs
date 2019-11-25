using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] projectile;
    private bool gcd;
    private float gcdTimer;

    public enum Direction { LEFT, RIGHT, UP, DOWN };
    // Start is called before the first frame update
    void Start()
    {
        gcd = false;
        gcdTimer = 0.2f;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!GameObject.Find("Manager").GetComponent<NewGame>().gameOver)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0));

            }

            if (Input.GetKeyDown(KeyCode.Space) && !gcd)
            {
                GameObject temp = Instantiate(projectile[0], transform.position, Quaternion.identity);
                temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
                gcd = true;
            }
            if (gcd)
            {
                gcdTimer-= Time.deltaTime;
                if (gcdTimer <= 0)
                {
                    gcd = false;
                    gcdTimer = 0.2f;
                }
            }
        }

    }
}
