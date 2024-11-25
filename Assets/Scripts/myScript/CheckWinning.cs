using UnityEngine;

public class CheckWinning : MonoBehaviour
{
    [SerializeField] private NumberField numberField; // רכיב NumberField שמציג את הניקוד
    [SerializeField] private GameObject winningPanel; // הפאנל שיוצג כאשר השחקן מנצח
    [SerializeField] private int targetScore = 100;  // הניקוד הנדרש לניצחון

    private bool hasWon = false; // כדי לוודא שהניצחון מופעל רק פעם אחת

    private void Update()
    {
        if (!hasWon && numberField.GetNumber() >= targetScore)
        {
            TriggerWin();
        }
    }

    private void TriggerWin()
    {
        hasWon = true; // כדי לוודא שהפונקציה מופעלת רק פעם אחת
        winningPanel.SetActive(true); // הפעלה של פאנל הניצחון
        Time.timeScale = 0f; // עצירת המשחק (אופציונלי)
    }

    public void SetTargetScore(int newTargetScore)
    {
        targetScore = newTargetScore;
    }
}
