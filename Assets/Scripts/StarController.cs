using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    public bool isStarInCollision;

    [SerializeField] AudioClip starSound;
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

    void OnTriggerEnter2D(Collider2D collider)
    {
        isStarInCollision = true;
        audioSource.PlayOneShot(starSound);
        SpriteRenderer[] spriteRenderers = gameObject.GetComponentsInChildren<SpriteRenderer>();
        foreach (SpriteRenderer spr in spriteRenderers)
        {
            spr.enabled = false;
        }
        Destroy(gameObject, 1f);
    }
}
