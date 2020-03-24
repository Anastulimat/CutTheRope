using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleController : MonoBehaviour
{
    private bool isBubbleInCollision;

    [SerializeField] AudioClip candyOnBubbleSound;
    [SerializeField] AudioClip bubblePopSound;
    AudioSource audioSource;
    Animator animator;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Debug.Log("KeyCode.LeftAlt");
            animator.Play("BubblePop");
            audioSource.PlayOneShot(bubblePopSound);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            audioSource.PlayOneShot(candyOnBubbleSound);
            animator.Play("BubbleFlight");
        }
        transform.position += transform.up * Time.deltaTime;  // This line


    }

    /*
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        isBubbleInCollision = true;
        
    }
    */
}
