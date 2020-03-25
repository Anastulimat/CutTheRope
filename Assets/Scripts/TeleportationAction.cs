using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportationAction : MonoBehaviour
{
    [SerializeField]
    public GameObject candy;

    [SerializeField]
    public GameObject hatSpawningPoint;

    [SerializeField]
    public GameObject teleportaionAnimIn;

    [SerializeField]
    public GameObject teleportaionAnimOut;

    [SerializeField]
    public AudioClip teleportationSound;

    AudioSource audioSource;


    private void Awake()
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Candy"))
        {
            audioSource.PlayOneShot(teleportationSound);
            teleportaionAnimIn.GetComponent<Animator>().enabled = true;
            teleportaionAnimOut.GetComponent<Animator>().enabled = true;
            candy.transform.position = new Vector2(hatSpawningPoint.transform.position.x, hatSpawningPoint.transform.position.y);

            StartCoroutine(Teleport());
        }
    }

    
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.1f);
        teleportaionAnimIn.GetComponent<Animator>().enabled = false;
        teleportaionAnimIn.GetComponent<SpriteRenderer>().enabled = false;

        teleportaionAnimOut.GetComponent<Animator>().enabled = false;
        teleportaionAnimOut.GetComponent<SpriteRenderer>().enabled = false;
    }
}
