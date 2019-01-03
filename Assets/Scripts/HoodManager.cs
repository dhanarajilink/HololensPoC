using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoodManager : MonoBehaviour, IInputClickHandler
{
    public GameObject EngineHood;

    public Vector3 HoodClosedPosition;
    public Quaternion HoodClosedRotation;

    public Vector3 HoodOpenedPosition;
    public Quaternion HoodOpenedRotation;

    public float HoodOpenSpeed = 10;
    public float HoodRotationSpeed = 90;

    public bool IsSceneOpens;
    public bool IsHoodOpened;
    
    public Vector3 EngineHoodPosition;
    public Quaternion EngineHoodRotation;

    // Start is called before the first frame update
    void Start()
    {
        InputManager.Instance.PushModalInputHandler(this.gameObject);

        EngineHood = GameObject.Find("engine hood");

        HoodClosedPosition = EngineHood.transform.position;
        HoodClosedRotation = EngineHood.transform.rotation;

        HoodOpenedPosition = new Vector3(2.945843f, -0.4393661f, 49.98956f);
        HoodOpenedRotation = new Quaternion(-0.1751339f, 0.4564559f, -0.2929251f, 0.8216879f);

        IsSceneOpens = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (IsSceneOpens) return;

        EngineHood.transform.position = Vector3.MoveTowards(EngineHood.transform.position,
                                                               EngineHoodPosition,
                                                               HoodOpenSpeed * Time.deltaTime);

        EngineHood.transform.rotation = Quaternion.RotateTowards(EngineHood.transform.rotation,
                                                        EngineHoodRotation,
                                                        HoodRotationSpeed * Time.deltaTime);
    }

    public void OnInputClicked(InputClickedEventData eventData)
    {
        //TODO: Implement cursor focusing and get if the car focused to proceed opening it's hood!

        IsSceneOpens = false;

        if (IsHoodOpened)
        {
            // Close the hood
            IsHoodOpened = false;

            EngineHoodPosition = HoodClosedPosition;
            EngineHoodRotation = HoodClosedRotation;
        }
        else
        {
            // Open the hood
            IsHoodOpened = true;

            EngineHoodPosition = HoodOpenedPosition;
            EngineHoodRotation = HoodOpenedRotation;
        }
    }
}
