using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private DestroyTest destroyTest;
    private ScriptTest scriptTest;
    float puntitos;

    private void Start()
    {
        GameObject LoadDestroyTest = GameObject.FindWithTag("Generator");
        if (LoadDestroyTest != null)
        {
            destroyTest = LoadDestroyTest.GetComponent<DestroyTest>();
        }

        if (LoadDestroyTest == null)
        {
            Debug.Log("No se puede encontrar el Script");
        }

        GameObject LoadScriptTest = GameObject.FindWithTag("Generator");
        if (LoadScriptTest != null)
        {
            scriptTest = LoadScriptTest.GetComponent<ScriptTest>();
        }

        if (LoadScriptTest == null)
        {
            Debug.Log("No se puede encontrar el Script 'GenerateNetwork' ");
        }

    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Nodenchi")
            {
            Debug.Log("Colisión!");
            }

        scriptTest.AddScore(puntitos);
    }

    void Update () {

        CircleCollider2D anilloExt = transform.GetComponent<CircleCollider2D>();
        //CapsuleCollider2D anilloInt = transform.GetComponent<CapsuleCollider2D>();
        anilloExt.radius += 1.5f * Time.deltaTime * 2;

        //Vector2 radio = new Vector2(1.7f,1.7f);
        //anilloInt.size += radio * Time.deltaTime * 2;
    }


    
}