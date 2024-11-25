using UnityEngine;

public class DifficultyManager : MonoBehaviour
{
    public static DifficultyManager Instance;

    private int currentDifficulty; // רמת הקושי הנוכחית

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public int GetCurrentDifficulty()
    {
        return currentDifficulty;
    }

    public void SetCurrentDifficulty(int difficulty)
    {
        currentDifficulty = difficulty;
        NotifyEnemies();
    }

    private void NotifyEnemies()
    {
        EnemyTagUpdater[] enemies = FindObjectsOfType<EnemyTagUpdater>();
        foreach (var enemy in enemies)
        {
            enemy.UpdateTagBasedOnDifficulty(); // עדכון תג האויבים המתאימים
        }
    }
}
