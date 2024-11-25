using UnityEngine;

public class EnemyTagUpdater : MonoBehaviour
{
    [SerializeField] private string easyTag = "EasyEnemy";        // תג ברמת קל
    [SerializeField] private string mediumTag = "MediumEnemy";    // תג ברמת בינוני
    [SerializeField] private string hardTag = "HardEnemy";        // תג ברמת קשה
    [SerializeField] private string extremeTag = "ExtremeEnemy";  // תג ברמת אקסטרים

    private void Start()
    {
        UpdateTagBasedOnDifficulty(); // עדכון תג בתחילת המשחק
    }

    // פונקציה לעדכון תג האויב
    public void UpdateTagBasedOnDifficulty()
    {
        int difficultyLevel = DifficultyManager.Instance.GetCurrentDifficulty();

        switch (difficultyLevel)
        {
            case 0: // Easy
                gameObject.tag = easyTag;
                break;
            case 1: // Medium
                gameObject.tag = mediumTag;
                break;
            case 2: // Hard
                gameObject.tag = hardTag;
                break;
            case 3: // Extreme
                gameObject.tag = extremeTag;
                break;
            default:
                Debug.LogWarning("Invalid difficulty level!");
                break;
        }
    }
}
