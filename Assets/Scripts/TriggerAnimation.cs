using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerAnimation : MonoBehaviour
{
    public static bool isHungry;
    public static bool isEating;
    public static bool isSad;

    [SerializeField]
    public AudioClip sound;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();   
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (gameObject.CompareTag("HungryAnimation") && collider.gameObject.CompareTag("Candy"))
        {
            isHungry = true;
            audioSource.PlayOneShot(sound);
        }
        if (gameObject.CompareTag("EatAnimation") && collider.gameObject.CompareTag("Candy"))
        {
            isHungry = false;
            isEating = true;
            audioSource.PlayOneShot(sound);
        }
        if (gameObject.CompareTag("SadAnimation") && collider.gameObject.CompareTag("Candy"))
        {
            isHungry = false;
            isEating = false;
            isSad = true;
            audioSource.PlayOneShot(sound);
        }
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        if (gameObject.CompareTag("HungryAnimation") && collider.gameObject.CompareTag("Candy"))
        {
            isHungry = false;
        }
    }


}
