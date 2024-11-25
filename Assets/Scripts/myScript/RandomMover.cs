using UnityEngine;

public class RandomMover : MonoBehaviour
{
    [SerializeField] private float speed = 5f; 
    [SerializeField] private float minAngle = 200f; 
    [SerializeField] private float maxAngle = 340f; 

    private Vector2 direction;

    private void Start()
    {
        // בוחרים זווית רנדומלית בטווח המעלות
        float angle = Random.Range(minAngle, maxAngle);

        // מחשבים את כיוון התנועה על בסיס הזווית
        float radians = angle * Mathf.Deg2Rad; // המרה מרדיאנים למעלות
        direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
    }

    private void Update()
    {
        // תנועה
        transform.Translate(direction * speed * Time.deltaTime);

        // השמדה כשיוצאים מגבולות המסך
        if (transform.position.y < -Camera.main.orthographicSize - 1 ||
            transform.position.x < -Camera.main.orthographicSize * Camera.main.aspect - 1 ||
            transform.position.x > Camera.main.orthographicSize * Camera.main.aspect + 1)
        {
            Destroy(gameObject);
        }
    }
}
