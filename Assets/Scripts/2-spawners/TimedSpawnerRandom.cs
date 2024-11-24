using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom: MonoBehaviour {
    [SerializeField] Mover prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 0.2f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 1.0f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 1.5f;
    [Tooltip("Minimum distance in X between spawner and spawned objects, in meters")] [SerializeField] float minXDistance = 0.5f;

    // [SerializeField] Transform parentOfAllInstances;

    void Start() {
         SpawnRoutine();
    }

    async void SpawnRoutine() {
        while (true) {
            float timeBetweenSpawnsInSeconds = UnityEngine.Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            await Awaitable.WaitForSecondsAsync(timeBetweenSpawnsInSeconds);       // co-routines
            if (!this) break;   // might be destroyed when moving to a new scene
            float XPos = UnityEngine.Random.Range(minXDistance, maxXDistance);
            int randomSign = UnityEngine.Random.Range(0, 2) * 2 - 1;

            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + XPos*randomSign,
                transform.position.y,
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            newObject.GetComponent<Mover>().SetVelocity(velocityOfSpawnedObject);
            // newObject.transform.parent = parentOfAllInstances;
        }
    }
}
