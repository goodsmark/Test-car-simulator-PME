using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

public class CarSelector : MonoBehaviour
{
    private List<RCC_CarControllerV3> spawnedCars;
    private int selectedIndex;
    
    [Inject] private DataC _dataC;
    [Inject] private Scene1Controller _controller;
    
    public void Init(Vector3 carPositionSpawn)
    {
        _controller.OnCarChanged += OnCarChanged;
        
        CreateInstanceCars(carPositionSpawn);
        GetRandomCar();
    }

    private void OnCarChanged(int index)
    {
        foreach (var sc in spawnedCars)
        {
            sc.gameObject.SetActive(false);
        }
        
        spawnedCars[index].gameObject.SetActive(true);
        Scene2Controller.carIndex = index;
    }

    private void CreateInstanceCars(Vector3 carPositionSpawn)
    {
        spawnedCars = new List<RCC_CarControllerV3>();

        foreach (var car in _dataC.carsObj)
        {
            var c = Instantiate(car, carPositionSpawn, Quaternion.identity);
            c.gameObject.SetActive(false);
            spawnedCars.Add(c);
        }
    }

    private void GetRandomCar()
    {
        var randomNum = Random.Range(0, spawnedCars.Count);
        spawnedCars[randomNum].gameObject.SetActive(true);
        selectedIndex = randomNum;
        Scene2Controller.carIndex = randomNum;
    }

    public void SelectNext()
    {
        selectedIndex++;
        if (selectedIndex >= spawnedCars.Count)
        {
            selectedIndex = 0;
        }
        
        _controller.OnCarChanged?.Invoke(selectedIndex);
    }

    public void SelectPrevious()
    {
        selectedIndex--;
        if (selectedIndex < 0)
        {
            selectedIndex = spawnedCars.Count-1;
        }
        
        _controller.OnCarChanged?.Invoke(selectedIndex);
    }

    private void OnDestroy()
    {
        _controller.OnCarChanged -= OnCarChanged;
    }
}
