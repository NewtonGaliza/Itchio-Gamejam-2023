using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformController : MonoBehaviour
{
    [SerializeField] private Transform plataform, pointA, pointB;
    [SerializeField] private float plataformSpeed;
    [SerializeField] private Vector3 destinyPoint;
    [SerializeField] private GameObject player;
    
    // Start is called before the first frame update
    void Start()
    {
        plataform.position = pointA.position;
        destinyPoint = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(plataform.position == pointA.position)
        {
            destinyPoint = pointB.position;
        }

        if(plataform.position == pointB.position)
        {
            destinyPoint = pointA.position;
        }

        plataform.position = Vector3.MoveTowards(plataform.position, destinyPoint, plataformSpeed);
    }
}
