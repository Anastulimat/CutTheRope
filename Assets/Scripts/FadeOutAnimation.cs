using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutAnimation : MonoBehaviour
{

    SpriteRenderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            Debug.Log("KeyCode.LeftAlt");
            StartFading();
        }
    }

    IEnumerator FadeOut()
    {   
        for (float f = 1f; f >= -0.05f; f -= 0.05f)
        {
            Color color = rend.material.color;
            color.a = f;
            rend.material.color = color;
            yield return new WaitForSeconds(0.05f);
        }
    }

    public void StartFading()
    {
        StartCoroutine("FadeOut");
    }
}
