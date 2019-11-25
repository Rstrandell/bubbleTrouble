using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public GameObject[] projectile;

    public enum Direction { LEFT, RIGHT, UP, DOWN };
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime, 0, 0));
            Debug.Log("hej");

        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject temp = Instantiate(projectile[0], transform.position, Quaternion.identity);
            temp.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));
        }

    }
}
