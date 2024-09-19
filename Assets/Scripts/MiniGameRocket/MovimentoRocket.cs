using UnityEngine;

public class MovimentoRocket : MonoBehaviour
{
    public float amplitude = 30f; // Amplitude máxima do movimento (altura total)
    public float initialFrequency = 0.5f; // Frequência inicial do movimento (velocidade inicial)
    public float accelerationDuration = 60f; // Tempo para a aceleração (em segundos)
    public float maxFrequencyMultiplier = 2f; // Multiplicador máximo para a frequência final
    public float tiltAngle = 5f; // Ângulo de inclinação máxima

    private float elapsedTime = 0f; // Tempo decorrido desde o início da aceleração
    private float frequency; // Frequência atual do movimento
    private float initialYPosition; // Posição inicial em Y
    private Vector3 initialRotation; // Rotação inicial do GameObject
    private bool endOfTheGame = false;
    // Start is called before the first frame update

    void Start()
    {
        initialYPosition = transform.localPosition.y; // Salva a posição inicial em Y
        initialRotation = transform.localEulerAngles; // Salva a rotação inicial do GameObject
        frequency = initialFrequency; // Define a frequência inicial
        endOfTheGame = false;
    }

    void Update()
    {
        if (endOfTheGame)
        {
            this.enabled = false;
        }

        // Atualiza o tempo decorrido
        elapsedTime += Time.deltaTime;

        // Calcula a frequência atual com base na aceleração ao longo do tempo
        float t = Mathf.Clamp01(elapsedTime / accelerationDuration); // Normaliza o tempo de 0 a 1
        frequency = Mathf.Lerp(initialFrequency, initialFrequency * maxFrequencyMultiplier, t);

        // Calcula um deslocamento vertical aleatório usando uma função PerlinNoise
        float randomOffset = Mathf.PerlinNoise(Time.time * frequency, 0) * amplitude * 2 - amplitude;

        // Aplica o deslocamento vertical ao GameObject
        transform.localPosition = new Vector3(transform.localPosition.x, initialYPosition + randomOffset, transform.localPosition.z);

        // Calcula a inclinação com base na direção do movimento
        float tilt = Mathf.Clamp(randomOffset, -amplitude, amplitude) / amplitude * tiltAngle;

        // Ajusta a rotação do GameObject com base no movimento
        transform.localRotation = Quaternion.Euler(initialRotation.x, initialRotation.y, -tilt);

        // Opcional: Para o movimento após a duração da aceleração
        if (elapsedTime >= accelerationDuration)
        {
            // Opcional: reseta o tempo decorrido para repetir o ciclo
            // elapsedTime = 0f;
        }
    }

    public void setEndOfTheGame()
    {
        endOfTheGame = true;
    }
}