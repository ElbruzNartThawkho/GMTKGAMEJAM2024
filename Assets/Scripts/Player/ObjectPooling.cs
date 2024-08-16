using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    public List<GameObject> gameObjects;
    private void Awake()
    {
        gameObjects = new List<GameObject>();
    }
    public GameObject PoolRequest(GameObject obj)
    {
        for (int i = 0; i < gameObjects.Count; i++)
        {
            if (!gameObjects[i].activeSelf)
            {
                gameObjects[i].SetActive(true);
                return gameObjects[i];
            }
        }
        GameObject returnObject = Instantiate(obj);
        gameObjects.Add(returnObject);
        return returnObject;
    }
}
