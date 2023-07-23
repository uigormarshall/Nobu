using UnityEngine;

public class Light2DFadeController : MonoBehaviour
{
    public float minIntensity = 2f; // Intensidade mínima da luz
    public float maxIntensity = 3f; // Intensidade máxima da luz
    public float intensityAnimationDuration = 5f; // Duração da animação de intensidade em segundos

    public float minFalloutStrength = 0.1f; // Valor mínimo do Fallout Strength
    public float maxFalloutStrength = 0.5f; // Valor máximo do Fallout Strength
    public float falloutStrengthAnimationDuration = 3f; // Duração da animação do Fallout Strength em segundos

    public UnityEngine.Rendering.Universal.Light2D light2D;
    private float timeElapsedIntensity = 0f;
    private float timeElapsedFalloutStrength = 0f;
    private bool increasingIntensity = true;
    private bool increasingFalloutStrength = true;

    private AnimationCurve intensityCurve;
    private AnimationCurve falloutStrengthCurve;

    private void Start()
    {
        light2D = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        // Inicializa a curva de animação de intensidade.
        intensityCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(intensityAnimationDuration * 0.5f, 1f),
            new Keyframe(intensityAnimationDuration, 0f)
        );

        // Inicializa a curva de animação do Fallout Strength.
        falloutStrengthCurve = new AnimationCurve(
            new Keyframe(0f, 0f),
            new Keyframe(falloutStrengthAnimationDuration * 0.5f, 1f),
            new Keyframe(falloutStrengthAnimationDuration, 0f)
        );
    }

    private void FixedUpdate()
    {
        // Atualiza o tempo decorrido para a animação de intensidade.
        timeElapsedIntensity += Time.deltaTime;

        // Verifica se o tempo decorrido excedeu a duração da animação de intensidade.
        if (timeElapsedIntensity > intensityAnimationDuration)
        {
            // Inverte a direção da animação de intensidade e reinicia o tempo decorrido.
            increasingIntensity = !increasingIntensity;
            timeElapsedIntensity = 0f;
        }

        // Atualiza o tempo decorrido para a animação do Fallout Strength.
        timeElapsedFalloutStrength += Time.deltaTime;

        // Verifica se o tempo decorrido excedeu a duração da animação do Fallout Strength.
        if (timeElapsedFalloutStrength > falloutStrengthAnimationDuration)
        {
            // Inverte a direção da animação do Fallout Strength e reinicia o tempo decorrido.
            increasingFalloutStrength = !increasingFalloutStrength;
            timeElapsedFalloutStrength = 0f;
        }

        // Obtém os valores de intensidade e Fallout Strength das curvas de animação.
        float intensityCurveValue = intensityCurve.Evaluate(timeElapsedIntensity);
        float falloutStrengthCurveValue = falloutStrengthCurve.Evaluate(timeElapsedFalloutStrength);

        // Interpola a intensidade entre os valores mínimo e máximo usando a curva de animação de intensidade.
        float newIntensity = Mathf.Lerp(minIntensity, maxIntensity, intensityCurveValue);

        // Interpola o Fallout Strength entre os valores mínimo e máximo usando a curva de animação do Fallout Strength.
        float newFalloutStrength = Mathf.Lerp(minFalloutStrength, maxFalloutStrength, falloutStrengthCurveValue);

        // Adiciona a variação de "Fallout Strength" à intensidade da luz.
        float strengthVariation = Random.Range(-newFalloutStrength, newFalloutStrength);
        newIntensity += strengthVariation;

        // Limita a intensidade dentro dos valores mínimo e máximo.
        newIntensity = Mathf.Clamp(newIntensity, minIntensity, maxIntensity);

        // Aplica a nova intensidade à luz.
        light2D.intensity = newIntensity;
    }
}
