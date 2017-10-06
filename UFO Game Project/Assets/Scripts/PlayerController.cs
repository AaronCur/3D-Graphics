//Name: Aaron Curry
//Start Date: 



using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class PlayerController : MonoBehaviour {

    public float speed;
    public Text countText;
    public Text winText;
    private float rad;
    //Compare rad is used to more acurately represent the players size when scaled down vs enemy moates
    //At scale = 1 the player is much bigger than the enemy players so compare rad is used to compensate.
    private Rigidbody2D rb2d;

    private int count;

    void Start()
    {
        rad = 0.5f;
        rb2d = GetComponent<Rigidbody2D>();
        transform.localScale = new Vector3(rad, rad, 0);
        rb2d.useAutoMass= true;
        count = 0;
        SetCountText();
       
        winText.text = "";
    }

	void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);


        if(Input.anyKeyDown)
        {
            transform.localScale -= new Vector3(0.02f, 0.02f);
        }

    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            if (other.rigidbody.mass <= rb2d.mass)
            {
                other.gameObject.SetActive(false);
                transform.localScale += new Vector3(0.1f, 0.1f);
                
                count = count + 1;

                SetCountText();
            }
            else
            {
                gameObject.SetActive(false);
                winText.text = "You Lose";
            }
        }
    }

    void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >=20)
        {
            winText.text = "You Win";
        }
    }
}
