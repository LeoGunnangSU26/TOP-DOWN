using UnityEngine;

public class PurchaseManager : MonoBehaviour
{
    public static PurchaseManager Instance;
    [SerializeField] float costBasic = 100f;
    [SerializeField] int ammoPurchased = 100;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }
    void Awake()
    {
        Instance=this;
    }

    // Update is called once per frame
    public void Purchase()
    {
        if (RequisitionManager.Instance.requisition>=costBasic)
        {
            Player.Instance.GrantAmmo(ammoPurchased);
            RequisitionManager.Instance.requisition-=costBasic;
            RequisitionManager.Instance.UpdateRequisitionCounter(RequisitionManager.Instance.requisition);
        }
    }
    void Update()
    {
        
    }
}
