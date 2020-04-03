using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutTheRopeAction : MonoBehaviour
{

    /*
    public Color trailColor = new Color(1, 1, 1);
    public float startWidth = 0.1f;
    public float endWidth = 0f;
    public float trailTime = 0.24f;

    Transform trailTransform;
    */

    private void Awake()
    {
        /*
        GameObject trailObj = new GameObject("Mouse Trail");
        trailTransform = trailObj.transform;
        TrailRenderer trail = trailObj.AddComponent<TrailRenderer>();
        SpriteRenderer sprend = trailObj.AddComponent<SpriteRenderer>();
        sprend.sortingOrder = 5;
        trail.time = -1f;
        trail.time = trailTime;
        trail.startWidth = startWidth;
        trail.endWidth = endWidth;
        trail.numCapVertices = 2;
        trail.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
        trail.sharedMaterial.color = trailColor;
        */
    }

    // Start is called before the first frame update
    void Start()
    {
       
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.tag == "Pump")
                {
                    hit.collider.gameObject.GetComponent<Pump>().PlayAllMethods();
                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetMouseButton(0))
        {
            //MoveTrailToCursor(Input.mousePosition);
            RaycastHit2D raycastHit2D = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (raycastHit2D.collider != null)
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

    /*
    void MoveTrailToCursor(Vector2 screenPosition)
    {
        trailTransform.position = Camera.main.ScreenToWorldPoint(new Vector2(screenPosition.x, screenPosition.y));
    }
    */
}
