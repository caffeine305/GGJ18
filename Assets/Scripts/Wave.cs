using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour {

    private DestroyTest destroyTest;
    private ScriptTest scriptTest;
    float puntitos;
    bool auxAlineacion;
    public Onda onda = new Onda();

    private void Start()
    {
        puntitos = Random.Range(1.0f, 100.0f);
        onda.setIntensidad(puntitos);

        auxAlineacion = calcAlign();
        onda.setAlign(auxAlineacion);


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


    public bool calcAlign()
    {
        bool convertAlign;
        int auxAlign = Random.Range(1,100);

        if (auxAlign < 50)
        {
            convertAlign = false;
        }
        else
        {
            convertAlign = true;
        }

        return convertAlign;
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Nodenchi")
            {
            Debug.Log("Colisión!");
            }

        float puntos = onda.getIntensidad();
        scriptTest.AddScore(puntos);
    }

    void Update () {

        CircleCollider2D anilloExt = transform.GetComponent<CircleCollider2D>();
        //CapsuleCollider2D anilloInt = transform.GetComponent<CapsuleCollider2D>();
        anilloExt.radius += 1.5f * Time.deltaTime * 2;

        //Vector2 radio = new Vector2(1.7f,1.7f);
        //anilloInt.size += radio * Time.deltaTime * 2;
    }

    public class Onda
    {
        //atributos

        bool alineacion; //Afecta distinto a buenos y malos
        int duracion; //Contador de colisiones
        float intensidad; //Afecta los puntos

        //Métodos
        public void setAlign(bool asignarAlign)
        {
            alineacion = asignarAlign;
        }

        public bool getAlign()
        {
            return alineacion;
        }

        public void setDure(int asignarDuracion)
        {
            duracion = asignarDuracion;
        }

        public int getDure()
        {
            return duracion;
        }

        public void setIntensidad(float asignInten)
        {
            intensidad = asignInten;
        }

        public float getIntensidad()
        {
            return intensidad;
        }

        //Constructores

        public Onda()
        {
            alineacion = true;
            duracion = 0;
            intensidad = 0;
        }

        public Onda(bool algn, int dur, float intenso)
        {
            alineacion = algn;
            duracion = dur;
            intensidad = intenso;
        }
    }

}