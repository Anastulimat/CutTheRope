using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Pump : MonoBehaviour
{

    [SerializeField] AudioClip[] pumpSounds = new AudioClip[3];
    [SerializeField] Vector2 rayCastDirection;

    AudioSource audioSource;

    Animator pumpAnimator;

    

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        pumpAnimator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAllMethods()
    {
        PlaySound();
        PlayAnim();
        HitCandy();
    }

    public void PlaySound()
    {
        System.Random random = new System.Random();
        int pumpSoundIndex = random.Next(0, pumpSounds.Length);
        audioSource.PlayOneShot(pumpSounds[pumpSoundIndex]);
    }   

    public void PlayAnim()
    {
        pumpAnimator.Play("PumpAction");
        StartCoroutine("SetPumpAnimatorState");
    }

    IEnumerator SetPumpAnimatorState()
    {
        yield return new WaitForSeconds(0.12f);
        pumpAnimator.Play("Do Nothing");
    }

    public void HitCandy()
    {

        SpriteRenderer spriteRenderer = gameObject.GetComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        Vector2 rayHitPos = new Vector2(transform.position.x + spriteRenderer.bounds.size.x, transform.position.y);
        RaycastHit2D hitObj = Physics2D.Raycast(rayHitPos, rayCastDirection);

        if (hitObj && !hitObj.transform.name.Equals("Pump"))
        {
            Debug.Log("HitCandy " + hitObj.collider.tag);
            if (hitObj.collider.CompareTag("Candy") && hitObj.distance <= 6.0f)
            {
                Debug.Log("HitCandy " + hitObj.collider.tag);
                hitObj.collider.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(4.0f, 0.0f);
            }

            if(hitObj.collider.CompareTag("Bubble") && hitObj.distance <= 6.0f && Candy.bubbeled)
            {
                Rigidbody2D parentRB = hitObj.collider.gameObject.GetComponentInParent(typeof(Rigidbody2D)) as Rigidbody2D;

                GameObject.FindGameObjectWithTag("Candy").GetComponent<Rigidbody2D>().velocity = new Vector2(4.0f, 0.0f);

                Debug.Log("HitCandy After" + parentRB.velocity);
            }
        }
    }

    
}
