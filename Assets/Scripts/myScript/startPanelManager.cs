using TMPro; // נדרש לעבודה עם InputField מסוג TMP
using UnityEngine;

public class startPanelManager : MonoBehaviour
{
    [SerializeField] private TMP_InputField targetScoreInputField; // שדה הקלט לכמות הנקודות
    [SerializeField] private TMP_Dropdown difficultyDropdown;
    [SerializeField] private GameObject startPanel; // הפאנל ההתחלתי
    [SerializeField] private CheckWinning checkWinning; // הסקריפט שבודק את הניקוד
    [SerializeField] private DifficultyManager difficultyManager;

    private void Start()
    {
        Time.timeScale = 0;
    }
    public void StartGame()
    {
        if (int.TryParse(targetScoreInputField.text, out int targetScore) && targetScore > 0)
        {
            checkWinning.SetTargetScore(targetScore);
            SetDifficulty();
            startPanel.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            checkWinning.SetTargetScore(20);
            SetDifficulty();
            startPanel.SetActive(false);
            Time.timeScale = 1;
        }
    }
    private void SetDifficulty()
    {
        int selectedDifficulty = difficultyDropdown.value;
        difficultyManager.SetCurrentDifficulty(selectedDifficulty);
    }
}
