using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptTest : MonoBehaviour {

    int fila = 4;
    int columna = 4;

    public GameObject ola;
    public Elemento[,] red = new Elemento[4,4];
    public GameObject nodoSolo;
    GameObject[,] nodos = new GameObject[4,4];

    float score;
    public GameObject scoreText;

    void Start()
    {
        score = 0.0f;
        initRed();
        modifRed();
    }

    public void initRed()  //Esta función inicializa la muchedumbre
    {
        Vector3 posicion = new Vector3(0.0f, 0.0f, 0.0f);
        Vector3 offset = new Vector3(5.0f,5.0f,0.0f);

        for (int i = 0; i < fila; ++i)
        {
            for (int j = 0; j < columna; ++j)
            {
                float nivelBondad = Random.Range(1,100);
                float valorEstado = Random.Range(1, 100);
                red[i,j] = new Elemento(i + 1,j + 1, nivelBondad, valorEstado);

                    posicion.x = (float)(i + 1);
                    posicion.y = (float)(j + 1);
                    transform.position = posicion * 2;
                    nodos[i, j] = Instantiate(nodoSolo, transform.position - offset, transform.rotation);
            }
            //auxCont += 4;
        }
    }

    public void modifRed() //Esta función Recorta la muchedumbre
    {
        red[1, 0].estatus = 0;
        red[2, 0].estatus = 0;
        red[1, 2].estatus = 0;
        red[2, 2].estatus = 0;
        red[1, 3].estatus = 0;
        red[2, 3].estatus = 0;

        for (int i = 0; i < fila; ++i)
        {
            for (int j = 0; j < columna; ++j)
            {
                if (red[i, j].estatus == 0)
                    Destroy(nodos[i, j]);
            }    
        }
    }

    private void OnMouseDown()
    {
        /*
        valorScore = 100;
        eliminado = 1;
        vel = walk.speed;
        */

        //           this.gameObject.SetActive(false);
        //           loadWave.Pedo();
        //           loadWave.UpdateEliminados(eliminado);
        //           loadWave.UpdateSpeed(vel);
        //           Destroy(this.gameObject, 2.0f);
        // Debug.Log(verBondad);;
    }


    public void AddScore(float newScoreValue)
    {
        score += newScoreValue;
        //Aquí se tantea el puntaje 
        UpdateScore();
        Debug.Log("Added! score is "+score);
    }

    void UpdateScore()
    {
        scoreText.GetComponent<TextMesh>().text = "Score:" + score;
        Debug.Log("Updated! Score is "+score);
    }

    private void Update()
    {
        Debug.Log("Fila: " + red[0,0].fila + " Columna: " + red[0,0].columna + " porcentaje: " + red[0,0].bondad + "%  Estatus: "+red[0,0].estatus);
    }

}


//----------------------------------


public class Elemento
{
    public float bondad;
    public float estatus;
    public int fila;
    public int columna;

    //Métodos
    public void setBondad(float asignarBondad)
    {
        bondad = asignarBondad;
    }

    public float getBondad()
    {
        return bondad;
    }

    public void setEstatus(float asignarEstatus)
    {
        bondad = asignarEstatus;
    }

    public float getEstatus()
    {
        return estatus;
    }


    public void setFila(int asignarFila)
    {
        fila = asignarFila;
    }
    
    public int getFila()
    {
        return fila;
    }

    public void setColumna(int asignarCol)
    {
        columna = asignarCol;
    }
    
    public int getColumna()
    {
        return columna;
    }

    //constructores
    public Elemento()
    {
        bondad = 0;
        fila = 1;
        columna = 1;
        estatus = 0;
    }

    public Elemento(int fil, int col, float val,float edo)
    {
        bondad = val;
        fila = fil;
        columna = col;
        estatus = edo;
    }

}