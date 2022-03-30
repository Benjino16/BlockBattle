using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnToPointer : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    void Update()
    {
        if(rb == null)
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, mousePos - transform.position);
        }
        else
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            rb.SetRotation(Quaternion.LookRotation(Vector3.forward, mousePos - transform.position));
        }
        
    }
}
