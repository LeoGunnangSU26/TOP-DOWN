using System;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Cleanse();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies")) {
        Destroy(collision.gameObject);
        RequisitionManager.Instance.GrantRequisition(1.5f);
        }
        //Destroy(gameObject);
    }
    void Cleanse()
    {
        if (Mathf.Abs(transform.position.x)>25.37 || Mathf.Abs(transform.position.y)>12.5)
        {
            Destroy(gameObject);
        }
        Invoke("Cleanse", 3);
    }
    void OnBecameInvisible() {
        Destroy(gameObject);
}}
