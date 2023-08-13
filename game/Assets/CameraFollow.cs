using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Referência para o objeto que a câmera irá seguir
    public float followSpeed = 5f; // Velocidade de interpolação da câmera
    public float verticalOffset = 5f; // Distância vertical da câmera em relação ao personagem
    public float minHeight = 5f; // Altura mínima da câmera durante a queda

    private Vector3 initialOffset; // Offset inicial entre a câmera e o personagem

    private void Start()
    {
        // Calcula o offset inicial entre a câmera e o personagem
        initialOffset = transform.position - target.position;
    }

    private void FixedUpdate()
    {
        // Define uma posição de destino para a câmera, levando em consideração a posição do personagem e o offset inicial
        Vector3 targetPosition = target.position + initialOffset;

        // Verifica se o personagem está caindo (por exemplo, comparando sua posição Y com a posição Y da câmera)
        if (target.position.y < transform.position.y - minHeight)
        {
            // Se o personagem estiver caindo, ajusta a posição da câmera para descer suavemente
            targetPosition.y = target.position.y + verticalOffset;
        }

        // Move a câmera em direção à posição de destino suavemente usando a interpolação linear
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * followSpeed);
    }
}
