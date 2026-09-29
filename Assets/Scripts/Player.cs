//using System.Numerics;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public static Player Instance;
    Rigidbody2D rb;
    UnityEngine.Vector2 moveInput;
    UnityEngine.Vector2 ScreenBoundary;
    [SerializeField] int maxAmmo = 100;
    [SerializeField] int currentAmmo = 100;
    [SerializeField] int playerHealth = 5;
    [SerializeField] float invicibleTime;
    [SerializeField] float moveSpeed = 3.0f;
    [SerializeField] float bulletSpeed = 7f;
    [SerializeField] GameObject bullet; 
    [SerializeField] GameObject gun; 
    [SerializeField] float rotationSpeed = 7000f;
    bool invincible;
    float targetAngle;
    UnityEngine.Vector2 mousePos;
    Vector2 mousePosWorld;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ScreenBoundary = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        AmmoCounter.Instance.UpdateAmmoCounter(currentAmmo);
    }
    void Awake()
    {
        Instance = this;
    }
    private void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }
    void OnAttack()
    {
        if (currentAmmo>0) {
        Rigidbody2D playerBullet = Instantiate(bullet, gun.transform.position, transform.rotation).GetComponent<Rigidbody2D>();
        playerBullet.AddForce(transform.up * bulletSpeed, ForceMode2D.Impulse);
        currentAmmo --;
        AmmoCounter.Instance.UpdateAmmoCounter(currentAmmo);
        }
        else
        {
        }

    } 
    // Update is called once per frame
    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;
        mousePos = Mouse.current.position.ReadValue();
        mousePosWorld = Camera.main.ScreenToWorldPoint(mousePos);
        
        //Debug.Log(rb.position);
        //Debug.Log((mousePosWorld-rb.position).normalized);
        //Debug.Log((mousePosWorld-rb.position).normalized.y);
        targetAngle=Mathf.Atan2((mousePosWorld-rb.position).normalized.y, (mousePosWorld-rb.position).normalized.x) *Mathf.Rad2Deg;
        //Debug.Log(targetAngle);
        //Debug.Log(mousePosWorld.normalized);
        //targetAngle=Debug.Log((mousePosWorld-rb.position).normalized.y,(mousePosWorld-rb.position).normalized.x);


        //if (moveInput != Vector2.zero){
        //targetAngle = Mathf.Atan2(moveInput.y, moveInput.x) * Mathf.Rad2Deg; }
        //transform.position=new Vector2(Mathf.Clamp(transform.position.x, -ScreenBoundary.x, ScreenBoundary.x), 
        //Mathf.Clamp(transform.position.y, -ScreenBoundary.y, ScreenBoundary.y));

    }
    
    void FixedUpdate()
    {
        float rotation = Mathf.MoveTowardsAngle(rb.rotation, targetAngle-90, rotationSpeed * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
    }

    void ResetInvincibility()
    {
        invincible=false;
    }
    void OnPurchase()
    {
        PurchaseManager.Instance.Purchase();
    }
    public void GrantAmmo(int amount)
    {
        currentAmmo+=amount;
        if (maxAmmo > 0)
        {
            currentAmmo=Mathf.Clamp(currentAmmo, 0, maxAmmo);
        }
        AmmoCounter.Instance.UpdateAmmoCounter(currentAmmo);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemies") && !invincible)
        {
            if (playerHealth <=1)
            {
                Destroy(gameObject);  
            }
            else
            {
                playerHealth --;
                invincible=true;
                Invoke("ResetInvincibility", invicibleTime);
                Debug.Log(playerHealth);
                HealthBar.Instance.updateHealthBar(playerHealth);
            }

        }

    }
}
