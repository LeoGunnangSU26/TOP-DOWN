using UnityEngine;
using TMPro;
public class AmmoCounter : MonoBehaviour
{
    public static AmmoCounter Instance;
    [SerializeField] TextMeshProUGUI ammoCounter;
    //string innerText;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //innerText= ammoCounter.text;
    }
    void Awake()
    {
        Instance = this;
    }
    // Update is called once per frame

    public void UpdateAmmoCounter(int ammo)
    {
        ammoCounter.text="Ammo:"+ammo;
    }
    void Update()
    {
        
    }
}
