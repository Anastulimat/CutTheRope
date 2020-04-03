using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouvableHook : MonoBehaviour
{

    BoxCollider2D parentCollider;
    Vector2 initPosition;
    // Start is called before the first frame update
    void Start()
    {
        parentCollider = gameObject.GetComponentInParent(typeof(BoxCollider2D)) as BoxCollider2D;
        initPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
        objPosition.x = Mathf.Max(objPosition.x, initPosition.x);
        objPosition.x = Mathf.Min(objPosition.x, (initPosition.x + parentCollider.bounds.size.x) - 0.2f);
        Debug.Log("transform.position.x = " + transform.position.x);
        Debug.Log("initPosition.x = " + initPosition.x);
        Debug.Log("(initPosition.x + parentCollider.bounds.size.x) - 0.2f) = " + ((initPosition.x + parentCollider.bounds.size.x) - 0.2f));
        if (objPosition.x >= initPosition.x && objPosition.x <= ((initPosition.x + parentCollider.bounds.size.x) - 0.2f))
        {
            transform.position = new Vector2(objPosition.x, transform.position.y);
        }
        


    }
}
