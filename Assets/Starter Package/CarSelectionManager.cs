using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSelectionManager : MonoBehaviour
{
    public GameObject[] carPrefabs;
    public static GameObject selectedCarPrefab;

    public GameObject carSelectionPanel;

    public void SelectCar(int index)
    {
        selectedCarPrefab = carPrefabs[index];
        Debug.Log("Carro seleccionado: " + selectedCarPrefab.name);

        CarManager carManager = FindObjectOfType<CarManager>();
        if (carManager.Car != null)
        {
            Destroy(carManager.Car.gameObject);
            carManager.Car = null;
        }

        carSelectionPanel.SetActive(false);
    }


    public void ShowCarSelectionPanel()
    {
        carSelectionPanel.SetActive(true);
    }
}
