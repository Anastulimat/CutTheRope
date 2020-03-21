using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{

    [SerializeField]
    public Rigidbody2D hook;
    public GameObject linkPrefab;
    public int links = 7;
    public Candy candy;

    // Start is called before the first frame update
    void Start()
    {
        GenerateRope();
    }

    void GenerateRope()
    {
        Rigidbody2D previousRB = hook;
        for(int i = 0; i < links; i++)
        {
            GameObject link = Instantiate(linkPrefab, transform);
            HingeJoint2D joint = link.GetComponent<HingeJoint2D>();
            joint.connectedBody = previousRB;

            if(i < links - 1)
            {
                previousRB = link.GetComponent<Rigidbody2D>();
            }
            else
            {
                candy.connectRopeEnd(link.GetComponent<Rigidbody2D>());
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
