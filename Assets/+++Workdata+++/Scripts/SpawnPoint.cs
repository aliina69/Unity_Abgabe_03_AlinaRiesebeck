using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] Transform spawnPoint;
    void Start()
    {
        transform.position = spawnPoint.position;
    }
}