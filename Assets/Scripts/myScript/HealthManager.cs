using UnityEngine;
using TMPro;


public class HealthManager : MonoBehaviour
{
    
    public int PlayerStartWith = 3;

    public int PlayerCurrentHealth;
    public TextMeshProUGUI healthText;
    public GameObject gameOverPanel;
    public string damageTag = "Enemy";
    public string healthTag = "Heart";

    void Start()
    {
        PlayerCurrentHealth = PlayerStartWith;
        UpdateHealthUI();
        gameOverPanel.SetActive(false);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(damageTag))
        {
            DecreaseOne();
            Destroy(collision.gameObject);
        }
        else if(collision.CompareTag(healthTag))
        {
            AddOne();
            Destroy(collision.gameObject);
        }
    }

    public void DecreaseHealth (int damage){
        PlayerCurrentHealth -= damage;
        UpdateHealthUI();

        if (PlayerCurrentHealth <= 0)
        {
            GameOver();
        }
    }

    public void AddHealth(int amountToAdd){
        PlayerCurrentHealth += amountToAdd;
        UpdateHealthUI();
    }
    

    

    public void AddOne (){
        AddHealth(1);
    }
    public void DecreaseOne(){
        DecreaseHealth(1);
    }

    void UpdateHealthUI()
    {
        healthText.text =  PlayerCurrentHealth.ToString();
    }

    void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f;
    }
}
