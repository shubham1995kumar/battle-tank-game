using System.Collections.Generic;
using UnityEngine;

public class TankSpawner : MonoBehaviour
{
    [System.Serializable]
    public class Tank
    {
        public float movementSpeed;
        public float rotationSpeed;
        public Material color;
    }

    public List<Tank> tankList;
    public TankView tankViewPrefab;
    public Transform spawnPoint;

    private TankController currentTankController;

    // Start is called before the first frame update
    void Start()
    {
        CreateTank();
    }

    public void CreateTank()
    {
        if (tankList.Count > 0)
        {
            if (currentTankController != null)
            {
                // Destroy the GameObject to which the current tank controller is attached
                Destroy(currentTankController.GetTankView().gameObject);
            }

            Tank tankProperties = tankList[0]; // Use the first tank properties from the list
            TankModel tankModel = new TankModel(tankProperties.movementSpeed, tankProperties.rotationSpeed, tankProperties.color);
            currentTankController = new TankController(tankModel, tankViewPrefab);
            currentTankController.GetTankView().transform.position = spawnPoint.position; // Set the tank's position at the spawn point
            tankViewPrefab.SetTankController(currentTankController); // Set the tank controller in the TankView
        }
    }

    public void RespawnTank()
    {
        CreateTank(); // Create a new tank, destroying the current one if it exists
    }
}
