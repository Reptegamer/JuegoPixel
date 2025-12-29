using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int PuntosTotales { get { return puntosTotales; } }
    private int puntosTotales;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void SumarPuntos(int SumaPundos)
    {
        puntosTotales += SumaPundos;
    }
}
