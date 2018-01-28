using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTest : MonoBehaviour {

    
    private ScriptTest scriptTest;
    public bool isTouching;

    private void Start()
    {
        isTouching = false;
        GameObject LoadScriptTest = GameObject.FindWithTag("Generator");
        if (LoadScriptTest != null)
        {
            scriptTest = LoadScriptTest.GetComponent <ScriptTest>();
        }

        if (LoadScriptTest == null)
        {
            Debug.Log("No se puede encontrar el Script 'GenerateNetwork' ");
        }
    }

    private void OnMouseOver()
    {
        Vector3 aux = this.transform.position;
        //Debug.Log(aux);

       // Debug.Log("x Original: " + aux.x + " y original: " + aux.y);

        int auxx = (int) (aux.x + 3)/2;
        int auxy = (int) (aux.y + 3)/2;
         
        Debug.Log("x ajustada: " + auxx + " y ajustada: " + auxy);
 
        Debug.Log("Bondad: " + scriptTest.red[auxx, auxy].getBondad());
        Debug.Log("Estado: " + scriptTest.red[auxx, auxy].getEstatus());
        isTouching = true;
        //verBondad = scriptTest.red[auxx, auxy].getBondad();
    }

    private void OnMouseExit()
    {
        isTouching = false;
    }

    private void Update()
    {
        if ((isTouching) && (Input.GetButtonDown("Fire1")))
        {
            Vector3 p = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            GameObject olaclon = Instantiate(scriptTest.ola, new Vector3(p.x, p.y, 0.0f), Quaternion.identity);

            Destroy(olaclon,5.0f);
        }
    }

}
