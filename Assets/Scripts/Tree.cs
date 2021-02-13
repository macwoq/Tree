using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public bool inRange;
    Rigidbody rb;
    [SerializeField] Transform spawner;
    [SerializeField] GameObject treePrefab;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
        }
    }

    public void Cut()
    {
        StartCoroutine(CutTree());
    }

    IEnumerator CutTree()
    {
        rb = GameObject.FindGameObjectWithTag("Tree").GetComponent<Rigidbody>();
        rb.isKinematic = false;
        rb.gameObject.name = "..";
        rb.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(7);

        Instantiate(treePrefab, spawner.position, Quaternion.identity);
    }
}
