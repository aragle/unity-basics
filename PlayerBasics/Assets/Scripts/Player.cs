using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float speedMultiplier = 10.0f;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private float recoveryCounter = 0;


    // Start is called before the first frame update
    void Start()
    {
        Camera.main.backgroundColor = Color.white;
        Debug.Log("I am a player!");   
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * speedMultiplier * Time.deltaTime;

        recoveryCounter += Time.deltaTime;

        CheckBoundaries();

    }

    void CheckBoundaries(){
        if (transform.position.x > 8.4f)
        {
            transform.position = new Vector3(8.4f, transform.position.y, 0);
            Hurt();
        }
        else if (transform.position.x < -8.4f)
        {
            transform.position = new Vector3(-8.4f, transform.position.y, 0);
            Hurt();
        }

        if (transform.position.y > 4.5f)
        {
            transform.position = new Vector3(transform.position.x, 4.5f, 0);
            Hurt();
        }
        else if (transform.position.y < -4.5f)
        {
            transform.position = new Vector3(transform.position.x, -4.5f, 0);
            Hurt();
        }
    }

    
    void Hurt()
    {
        if (recoveryCounter > 2)
        {
            maxHealth -= 1;
            recoveryCounter = 0;
            Debug.Log(maxHealth);
        }
    }
}
