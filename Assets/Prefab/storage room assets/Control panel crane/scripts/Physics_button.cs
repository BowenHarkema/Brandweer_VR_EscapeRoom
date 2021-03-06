using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;

public class Physics_button : MonoBehaviour
{
    [SerializeField] private float threshold = 0.1f;
    [SerializeField] private float deadZone = 0.025f, minDistance= 0.002f;
    [SerializeField] private Rigidbody rigidBodyButton;
    private List<Transform> handsTransform = new List<Transform>();
    private List<Vector3> prefHandPosses = new List<Vector3>();
    private List<float> distances = new List<float>();

    private bool _isPressed;
    private Vector3 _startPos;
    private ConfigurableJoint _joint;

    public UnityEvent onPressed, onReleased;

    [SerializeField] private ButtonPressed _ButtonPressed;

    // Start is called before the first frame update
    void Start()
    {
        _startPos = transform.localPosition;
        _joint = GetComponent<ConfigurableJoint>();
        GameObject[] hands = GameObject.FindGameObjectsWithTag("Hands");
        foreach (GameObject hand in hands)
        {
            handsTransform.Add(hand.transform);
            prefHandPosses.Add(Vector3.zero);
            distances.Add(0);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!_isPressed && GetValue() + threshold >= 1)
            Pressed();
        if (_isPressed && GetValue() - threshold <= 0)
            Released();
        for(int i = 0; i<handsTransform.Count; i++)
        {
            float distance = Vector3.Distance(handsTransform[i].position, prefHandPosses[i]);
            distances[i] = distance;
            prefHandPosses[i] = handsTransform[i].position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Hands" && !_ButtonPressed.P_isButtonPressed)
        {
            for (int i = 0; i < distances.Count; i++)
                if (distances[i] >= minDistance)
                {
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                    GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                    GetComponent<Rigidbody>().AddForce(0, -3, 0);
                    _ButtonPressed.P_isButtonPressed = true;
                }
        }
        else if (other.tag == "Hands" && _ButtonPressed.P_isButtonPressed)
        {
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Hands")
        {
            GetComponent<Rigidbody>().AddForce(0, -3, 0);
            _ButtonPressed.P_isButtonPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Hands")
        {
            _ButtonPressed.P_isButtonPressed = false;
        }
    }



    private float GetValue()
    {
        var value = Vector3.Distance(_startPos, transform.localPosition) / _joint.linearLimit.limit;

        if (System.Math.Abs(value) < deadZone)
            value = 0;
        return Mathf.Clamp(value, -1f, 1f);
    }

    private void Pressed()
    {
        _isPressed = true;
        onPressed.Invoke();
    }

    private void Released()
    {
        _isPressed = false;
        onReleased.Invoke();
    }






}
