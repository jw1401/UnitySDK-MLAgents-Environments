using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;


public class Object : MonoBehaviour
{
    public GameObject MainHub;
    public int Case = 0;
    private bool _doUpdate;
    private Transform[] _targets;
    private float _speed;
    private int _current;


    public Transform[] Targets
    {
        set
        {
            this._targets = value;
        }
    }

    public float Speed
    {
        set
        {
            this._speed = value;
        }
    }

    public void setUpdate(bool value)
    {
        this._doUpdate = value;
    }

    void Awake()
    {
    }

    void Start()
    {
        Case = Mathf.RoundToInt(UnityEngine.Random.Range(0f, 1f));
        print(Case);
    }

    void Update()
    {
        if (this._doUpdate)
        {
            if (Vector3.Distance(this.gameObject.transform.position, _targets[_current].transform.position) > 0.1)
            {
                Vector3 pos = Vector3.MoveTowards(this.gameObject.transform.position, _targets[_current].transform.position, _speed * Time.deltaTime);
                this.gameObject.GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
                _current = (_current + 1) % _targets.Length;
            }
        }
        if (this.transform.localPosition.y < 0)
        {
            Destroy(this.gameObject);
        }
    }

    // void OnMouseDown()
    // {
    //     print ("clicked" + this.gameObject.name);
    //     Destroy(this.gameObject);
    // }

}
