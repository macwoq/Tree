using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tree : MonoBehaviour
{
    public bool inRange;
    Rigidbody rb;
    [SerializeField] Transform spawner;
    [SerializeField] GameObject treePrefab;
    //spawn new tree in same place?
    public bool spawnNew;
    //Destroy cutted tree before spawn new?
    public bool destroyBeforeSpawn;
    //on-screen icon of tree range
    [SerializeField] Image treeInfo;

    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            treeInfo.color = Color.green;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = true;
            treeInfo.color = Color.green;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inRange = false;
            treeInfo.color = Color.red;
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
        rb.gameObject.name = "cutted";
        rb.gameObject.tag = "Untagged";
        yield return new WaitForSeconds(5);
        GameObject.Find("cutted").GetComponent<Collider>().enabled = false;
        yield return new WaitForSeconds(2);
        
        Destroy(GameObject.Find("cutted"));
        
        if (spawnNew)
        {
            Instantiate(treePrefab, spawner.position, Quaternion.identity);
        }
        else
        {
            print("Done");
        }

        
    }
}
