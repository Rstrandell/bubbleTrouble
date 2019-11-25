using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    private NewGame manager;
    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Manager").GetComponent<NewGame>();


    }

    // Update is called once per frame
    void Update()
    {
        if (!manager.gameOver){
            transform.Translate(new Vector3(0, 10 * Time.deltaTime, 0));
        }
       

    }

    void spawnNewBalls(Collider2D collision)
    {
        int direction = 1;
        for (int i = 0; i < 2; i++)
        {
            GameObject temp = Instantiate(collision.gameObject);
            temp.transform.GetComponent<Rigidbody2D>().AddForce(new Vector2(direction * 150, 250));
            Vector2 size = temp.GetComponent<Renderer>().bounds.size;

            Vector2 rescale = temp.transform.localScale;

            rescale.y = 0.5f * rescale.y;
            rescale.x = 0.5f * rescale.x;

            temp.transform.localScale = rescale;
            temp.tag = "ball";
            direction *= -1;
            manager.activeBalls.Add(temp);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            if (collision.gameObject.transform.localScale.x >= 0.07f)
            {
                spawnNewBalls(collision);
            }
            manager.activeBalls.Remove(collision.gameObject);
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
