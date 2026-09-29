//using System.Numerics;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    public static HealthBar Instance;
    [SerializeField] GameObject heart;
    Vector3 startPos = new Vector3(-50f,-50f,0f);
    Vector3 mod = new Vector3(-100f,-100f,0f);
    Vector3 actPos;
    GameObject[] hearts;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        updateHealthBar(5);
    }
    void Awake()
    {
           Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void updateHealthBar(int newHealth)
    {
        hearts=GameObject.FindGameObjectsWithTag("Heart");
        foreach(GameObject deletee in hearts)
        {
            Destroy(deletee);
        }
        for (int i = 0; i<=newHealth; i++)
        {
            actPos= startPos+(mod*i);
            Instantiate(heart, actPos, Quaternion.identity);

        }
    }
}
