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

    float puntitos;
    bool auxAlineacion;
    int persistencia;
    public Onda onda = new Onda();

    float score;
    public GameObject scoreText;

    void Start()
    {
        initOnda();

        score = 0.0f;
        initRed();
        modifRed();
    }


    public bool calcAlign()
    {
        bool convertAlign;
        int auxAlign = Random.Range(1, 100);

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

    public void initOnda()
    {
        puntitos = Random.Range(1.0f, 100.0f);
        onda.setIntensidad(puntitos);

        auxAlineacion = calcAlign();
        onda.setAlign(auxAlineacion);

        persistencia = Random.Range(1, 5);
        onda.setDure(persistencia);
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


    float calculateScore()
    {
        float scoreCalculado;
        scoreCalculado = 0;

        
        Debug.Log(scoreCalculado);

        return scoreCalculado;
    }

    public void AddScore(float newScoreValue)
    {
        score = score + Mathf.RoundToInt(newScoreValue);
        //Aquí se tantea el puntaje 
        UpdateScore();
        //Debug.Log("Added! score is "+score);
    }

    void UpdateScore()
    {
        scoreText.GetComponentInChildren<TextMesh>().text = "Score: " + score;
        //Debug.Log("Updated! Score is "+score);
    }

    private void Update()
    {
        //Debug.Log("Fila: " + red[0,0].fila + " Columna: " + red[0,0].columna + " porcentaje: " + red[0,0].bondad + "%  Estatus: "+red[0,0].estatus);
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