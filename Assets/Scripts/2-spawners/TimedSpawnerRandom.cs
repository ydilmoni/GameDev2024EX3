using System.Collections;
using System.Threading.Tasks;
using UnityEngine;

/**
 * This component instantiates a given prefab at random time intervals and random bias from its object position.
 */
public class TimedSpawnerRandom: MonoBehaviour {
    [SerializeField] GameObject prefabToSpawn;
    [SerializeField] Vector3 velocityOfSpawnedObject;
    [Tooltip("Minimum time between consecutive spawns, in seconds")] [SerializeField] float minTimeBetweenSpawns = 0.2f;
    [Tooltip("Maximum time between consecutive spawns, in seconds")] [SerializeField] float maxTimeBetweenSpawns = 1.0f;
    [Tooltip("Maximum distance in X between spawner and spawned objects, in meters")] [SerializeField] float maxXDistance = 1.5f;
    [Tooltip("Maximum distance in Y between spawner and spawned objects, in meters")] [SerializeField] float maxYDistance = 1.5f;


    // [SerializeField] Transform parentOfAllInstances;

    void Start() {
         SpawnRoutine();
    }

    async void SpawnRoutine() {
        while (true) {
            float timeBetweenSpawnsInSeconds = UnityEngine.Random.Range(minTimeBetweenSpawns, maxTimeBetweenSpawns);
            await Awaitable.WaitForSecondsAsync(timeBetweenSpawnsInSeconds);       // co-routines
            if (!this) break;   // might be destroyed when moving to a new scene

            float XAddToPos = UnityEngine.Random.Range(-maxXDistance, maxXDistance);
            
            float YAddToPos = UnityEngine.Random.Range(-maxYDistance, maxYDistance);
      
            Vector3 positionOfSpawnedObject = new Vector3(
                transform.position.x + XAddToPos,
                transform.position.y + YAddToPos,
                transform.position.z);
            GameObject newObject = Instantiate(prefabToSpawn.gameObject, positionOfSpawnedObject, Quaternion.identity);
            //הוספתי כאן בדיקה האם יש לאובייקט רכיב של תזוזה או תזוזה רנדומלית
            if (newObject.TryGetComponent<Mover>(out Mover mover))
            {
                mover.SetVelocity(velocityOfSpawnedObject);
            }

            else if (newObject.TryGetComponent<RandomMover>(out RandomMover randomMover))
            {
            }

            else
            {
                Debug.LogWarning("The prefab does not contain a Mover or RandomMover component.");
            }
            // newObject.transform.parent = parentOfAllInstances;
        }
    }
}
