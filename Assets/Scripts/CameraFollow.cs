using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Personnage � suivre
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;    

    void LateUpdate()
    {
        if (target != null)
        {
            // Obtenir la position souhait�e avec la m�me valeur pour z (-10)
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = -10f; // Assure que z reste � -10

            // Calculer une position liss�e
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

            // Mettre � jour la position de la cam�ra
            transform.position = smoothedPosition;
        }
    }
}
