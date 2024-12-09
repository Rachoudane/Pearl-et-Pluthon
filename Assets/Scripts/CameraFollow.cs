using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;       // Personnage à suivre
    public float smoothSpeed = 0.125f;
    public Vector3 offset;

    private Vector3 velocity = Vector3.zero;    

    void LateUpdate()
    {
        if (target != null)
        {
            // Obtenir la position souhaitée avec la même valeur pour z (-10)
            Vector3 desiredPosition = target.position + offset;
            desiredPosition.z = -10f; // Assure que z reste à -10

            // Calculer une position lissée
            Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

            // Mettre à jour la position de la caméra
            transform.position = smoothedPosition;
        }
    }
}
