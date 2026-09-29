using System;
using TMPro;
using UnityEngine;

public class RequisitionManager : MonoBehaviour
{
    public static RequisitionManager Instance;
    [SerializeField] public float requisition = 0f;
    [SerializeField] float maxRequisition = -1f;
    [SerializeField] TextMeshProUGUI reqCounter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateRequisitionCounter(requisition);
    }
    void Awake()
    {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GrantRequisition(float amount)
    {
        requisition+=amount;
        if (maxRequisition > 0)
        {
            requisition = Mathf.Clamp(requisition, 0, maxRequisition);
        }
        UpdateRequisitionCounter(requisition);

    }
    public void UpdateRequisitionCounter(float value)
    {
        reqCounter.text="Requisition:" + value;
    }
}
