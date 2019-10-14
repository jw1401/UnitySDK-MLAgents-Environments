using UnityEngine;
using System.Collections;

public class CameraOrbit : MonoBehaviour
{

    protected Transform _XForm_Camera;
    protected Transform _XForm_Parent;

    protected Vector3 _LocalRotation;
    protected Vector3 _LocalPosition;
    protected float _CameraDistance = 10f;

    public float MouseSensitivity = 4f;
    public float ScrollSensitvity = 2f;
    public float OrbitDampening = 10f;
    public float ScrollDampening = 6f;
    public float PanSensitivity = 2f;
    public float PanDampening = 6f;
    public bool CameraDisabled = false;

    protected Hub Hub;


    // Use this for initialization
    void Start()
    {
        this._XForm_Camera = this.transform;
        this._XForm_Parent = this.transform.parent;
        this._LocalPosition = this._XForm_Camera.localPosition;

        this.Hub = GameObject.Find("Hub").GetComponent<Hub>();
    }


    void LateUpdate()
    {

        if (!CameraDisabled)
        {
            //Rotation of the Camera based on Mouse Coordinates and Mouse Button pressed
            if (Input.GetMouseButton(1))
            {
                if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
                {
                    _LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                    _LocalRotation.y -= Input.GetAxis("Mouse Y") * MouseSensitivity;

                    //Clamp the y Rotation to horizon and not flipping over at the top
                    if (_LocalRotation.y < 0f)
                        _LocalRotation.y = 0f;
                    else if (_LocalRotation.y > 90f)
                        _LocalRotation.y = 90f;
                }

            }

            //Zooming Input from our Mouse Scroll Wheel
            if (Input.GetAxis("Mouse ScrollWheel") != 0f)
            {
                float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitvity;
                ScrollAmount *= (this._CameraDistance * 0.3f);
                this._CameraDistance += ScrollAmount * -1f;
                this._CameraDistance = Mathf.Clamp(this._CameraDistance, 1.5f, 100f);
            }

            //Pan Camera on Mouse Button pressed
            if (Input.GetMouseButton(2))
            {
                _LocalPosition += transform.right * (Input.GetAxis("Mouse X") * -1) * PanSensitivity;
                _LocalPosition += transform.up * (Input.GetAxis("Mouse Y") * -1) * PanSensitivity;
            }

            // if left button pressed...
            if (Input.GetMouseButtonDown(0))
            { 
                UnityEngine.Ray ray = GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit))
                {
                    // the object identified by hit.transform was clicked
                    this.Hub.objectClicked(hit.transform.gameObject);
                }
            }

        }

        //Actual Camera Rig Transformations
        Quaternion QT = Quaternion.Euler(_LocalRotation.y, _LocalRotation.x, 0);
        this._XForm_Parent.rotation = Quaternion.Lerp(this._XForm_Parent.rotation, QT, Time.deltaTime * OrbitDampening);
        this._XForm_Camera.localPosition = new Vector3(Mathf.Lerp(this._XForm_Camera.localPosition.x, this._LocalPosition.x, Time.deltaTime * PanDampening),
            Mathf.Lerp(this._XForm_Camera.localPosition.y, this._LocalPosition.y, Time.deltaTime * PanDampening),
            Mathf.Lerp(this._XForm_Camera.localPosition.z, this._CameraDistance * -1f, Time.deltaTime * ScrollDampening));
    }
}
