using UnityEngine;

public class CameraMove : MonoBehaviour {
    
    // public GameObject Player;
    public float SmoothTime = 0.5f;
    public Transform Target;

    private Vector3 _velocity = Vector3.zero;

    void Update () {

        if (Target)
        {
            var destination = new Vector3(Target.position.x, Target.position.y, gameObject.transform.position.z);

            transform.position = 
                Vector3.SmoothDamp(transform.position, destination, ref _velocity, SmoothTime);
        }
    }
}
