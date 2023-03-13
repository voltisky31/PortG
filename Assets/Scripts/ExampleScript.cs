using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    public int Liczba;
    [SerializeField] List<string> ListaStringow;

    [ContextMenu("CzyParzysta")]
    public void CzyParzysta()
    {
        for (int i = 0; i < ListaStringow.Count; i++)
        {
            ListaStringow[i] = (ListaStringow.Count - i - 1).ToString();
        }

        //if (Liczba != 0 && Liczba % 2 == 0)
        //{
        //    Debug.Log("Jest parzysta");
        //}
        //else
        //{
        //    Debug.Log("Jest nieparzysta");
        //}
    }
}

