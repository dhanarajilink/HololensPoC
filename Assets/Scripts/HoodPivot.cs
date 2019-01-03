using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodPivot : MonoBehaviour
{
    public float PivotSize = 0.75f;
    public Color PivotColor = Color.yellow;

    private void OnDrawGizmos()
    {
        Gizmos.color = PivotColor;
        Gizmos.DrawWireSphere(transform.position, PivotSize);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
