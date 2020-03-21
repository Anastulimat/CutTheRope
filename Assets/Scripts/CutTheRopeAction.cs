using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutTheRopeAction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            RaycastHit2D raycastHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if(raycastHit2D.collider != null)
            {
                if(raycastHit2D.collider.tag == "Link")
                {
                    Destroy(raycastHit2D.collider.gameObject);
                    FadeOutAnimation[] allChildren = raycastHit2D.transform.parent.GetComponentsInChildren<FadeOutAnimation>();
                    foreach(FadeOutAnimation fadeOutAnimation in allChildren)
                    {
                        fadeOutAnimation.StartFading();
                    }
                    Destroy(raycastHit2D.transform.parent.gameObject, 1f);
                }
            }
        }
    }
}
