using UnityEngine;

public class AsteroidExplosion : MonoBehaviour
{
    [SerializeField] private GameObject smallerAsteroidPrefab; // פריפאב של אסטרואיד קטן
    [SerializeField] private int numberOfSmallerAsteroids = 3; // מספר האסטרואידים שייצאו
    [Tooltip("The minimum screen size that the asteroid passes until it explodes")][Range(0, 100)][SerializeField] private float MinExplosionPointYInInPercent = 25f; // נקודת הפיצוץ
    [Tooltip("The maximum screen size that the asteroid passes until it explodes")][Range(0, 100)][SerializeField] private float MaxExplosionPointYInInPercent = 75f; // נקודת הפיצוץ

    private float explosionPointY;
    private void Start() 
    {
        /*
        הסבר קצר על מה שקורה פה
        שני המשתנים הראשונים שומרים את שתי הנקודות שמצייגות את הקצוות האנכיים של המסך בעולם האמיתי
        לאחר מכן אני משתמש בפונקציה שמביאה לי את הערך של האחוזים לעולם האמיתי
        ואז אני בוחור שם נקודה רנדומלית לפיצוץ
        */
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y;
        float explosionRangeMin = Mathf.Lerp(minY, maxY, MinExplosionPointYInInPercent / 100f);
        float explosionRangeMax = Mathf.Lerp(minY, maxY, MaxExplosionPointYInInPercent / 100f);
        explosionPointY = UnityEngine.Random.Range(explosionRangeMin, explosionRangeMax);
    }
    private void Update()
    {
        // בדיקה אם הגיע לנקודת הפיצוץ
        if (transform.position.y <= explosionPointY)
        {
            Explode();
        }
    }

    private void Explode()
    {
        // יצירת אסטרואידים קטנים
        for (int i = 0; i < numberOfSmallerAsteroids; i++)
        {
            Instantiate(smallerAsteroidPrefab, transform.position, Quaternion.identity);
        }

        // השמדה של האובייקט הנוכחי
        Destroy(gameObject);
    }
}
