using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Candy : MonoBehaviour
{

    [SerializeField]
    public GameObject bubble;

    [SerializeField]
    AudioClip bubblePopSound, candyOnBubbleSound;

    public float distanceFromChaineEnd = 0.3f;

    public static bool bubbeled = false;


    public void connectRopeEnd(Rigidbody2D endRB)
    {
        HingeJoint2D joint = gameObject.AddComponent<HingeJoint2D>();
        joint.autoConfigureConnectedAnchor = false;
        joint.connectedBody = endRB;
        joint.anchor = Vector2.zero;
        joint.connectedAnchor = new Vector2(0f, -distanceFromChaineEnd);
    }



    private void Update()
    {
        
        

        if (TriggerAnimation.isEating)
        {
            Destroy(gameObject, 0.07f);
        }

        if (bubbeled == true)
        {
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-4.0f, 0.0f);
            }

            gameObject.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
            gameObject.GetComponent<Rigidbody2D>().drag = 5f;

            bubble.transform.position = transform.position;
            bubble.transform.parent = transform;
            bubble.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
            bubble.GetComponent<Rigidbody2D>().drag = 10f;

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Bubble")
                    {
                        Debug.Log("Click on bubble !");
                        hit.collider.gameObject.GetComponent<AudioSource>().PlayOneShot(bubblePopSound);
                        hit.collider.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                        Destroy(hit.collider.gameObject, 0.7f);
                        bubbeled = false;
                    }
                }
            }
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 1.0f;
            gameObject.GetComponent<Rigidbody2D>().drag = 0.1f;
        }
       

    }

    

    private void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.gameObject.CompareTag("Bubble"))
        {
            Debug.Log("OnTriggerEnter2D with Bubble");
            bubble.transform.position = transform.position;
            bubble.transform.parent = transform;
            bubble.GetComponent<SpriteRenderer>().sortingOrder = 2;
            bubble.GetComponent<Animator>().enabled = true;
            bubble.GetComponent<AudioSource>().PlayOneShot(candyOnBubbleSound);
            bubble.GetComponent<Rigidbody2D>().gravityScale = -1.0f;
            bubble.GetComponent<Rigidbody2D>().drag = 10f;
            /*
            GameObject childGameObject = gameObject.transform.Find("CandyBubbleCover").gameObject;
            childGameObject.GetComponent<SpriteRenderer>().enabled = true;
            childGameObject.GetComponent<Animator>().enabled = true;
            gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            */
            bubbeled = true;
        }
    }
}
