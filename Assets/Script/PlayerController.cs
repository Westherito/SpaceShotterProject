
using UnityEngine;
using UnityEngine.UI;
public class PlayerController : MonoBehaviour
{
    [SerializeField] private AudioSource[] SoundFX;
    // Movimentação
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    // Tiros do Player
    [SerializeField] private float timerBullet = 0.1f;
    [SerializeField] private GameObject tiros;
    [SerializeField] private GameObject tiros2;
    private float velTiro = 10f;
    [SerializeField] private int levelTiro = 1;
    // Escudo do player
    [SerializeField] private GameObject escudo;
    private GameObject escudoAtual;
    private float timerEscudo = 0f;
    [SerializeField] private int qteEscudo = 3;
    // Vida do player
    private int lifePlayer;
    [SerializeField] private GameObject Morte;
    // Limite de tela
    [SerializeField] private float xMin, yMin, xMax, yMax;
    // Mostrando as informações do player
    [SerializeField] private Text EscudoDisplay;
    [SerializeField] private Image vidaDisplay;
    [SerializeField] private int lifeMax;
    // Start is called before the first frame update
    void Start()
    {
        lifePlayer = lifeMax;
    }
    // Update is called once per frame
    void Update()
    {
        MovimentoPlayer();
        TirosPlayer();
        EscudoPlayer();
        vidaDisplay.fillAmount = ((float)lifePlayer / (float)lifeMax);
        EscudoDisplay.text = qteEscudo.ToString();
    }
    // Movimentação
    private void MovimentoPlayer()
    {
        // Pegando o Input do usuário e adicionando velocidade
        movPlayer.x = Input.GetAxis("Horizontal");
        movPlayer.y = Input.GetAxis("Vertical");
        // Normalizando a direção
        movPlayer.Normalize();
        // Passando para o player
        rbPlayer.velocity = movPlayer * vel;
        // Checando os limites do player na tela com Clamp
        float limiteX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float limiteY = Mathf.Clamp(transform.position.y, yMin, yMax);
        // Aplicando o limite 
        transform.position = new Vector3(limiteX, limiteY, transform.position.z);
    }
    // Criando os tiros no jogo com sistema de level
    private void TirosPlayer()
    {

        if (Input.GetButton("Fire1"))
        {
            timerBullet -= Time.deltaTime;
            switch (levelTiro)
            {
                case 1:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros, transform.position);
                        timerBullet = 0.15f;
                    }
                    break;

                case 2:
                    if (timerBullet < 0f)
                    {
                        // Tiro esquerdo
                        Vector3 posTiro = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiro);
                        // Tiro direito
                        posTiro = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiro);
                        timerBullet = 0.12f;
                    }
                    break;
                case 3:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros2, transform.position);
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros2, posTiroD);
                        timerBullet = 0.20f;
                    }
                    break;
                case 4:
                    if (timerBullet < 0f)
                    {
                        CriaTiro(tiros, transform.position);
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.4f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroD);
                        timerBullet = 0.10f;
                    }
                    break;
                case 5:
                    if (timerBullet < 0f)
                    {
                        var enemy = FindAnyObjectByType<EnemyFatherController>();
                        // Tiro esquerdo
                        Vector3 posTiroE = new Vector3(transform.position.x - 0.2f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroE);
                        posTiroE = new Vector3(transform.position.x - 0.6f, transform.position.y - 0.2f, 0f);
                        CriaTiro(tiros2, posTiroE);
                        // Tiro direito
                        Vector3 posTiroD = new Vector3(transform.position.x + 0.2f, transform.position.y + 0.1f, 0f);
                        CriaTiro(tiros, posTiroD);
                        posTiroD = new Vector3(transform.position.x + 0.6f, transform.position.y - 0.2f, 0f);
                        CriaTiro(tiros2, posTiroD);
                        timerBullet = 0.10f;
                    }
                    break;
            }
        }
    }
    // Método do escudo
    private void EscudoPlayer()
    {
        if (Input.GetButtonDown("Shield") && qteEscudo > 0)
        {
            // Criando escudo se não tiver nenhum no jogo
            if (!escudoAtual) { escudoAtual = Instantiate(escudo, transform.position, transform.rotation); SoundFX[2].Play(); }
        }
        if (escudoAtual)
        {
            // Determinando o tempo do escudo e a posição
            escudoAtual.transform.position = transform.position;
            timerEscudo += Time.deltaTime;
            if (timerEscudo > 9.2f)
            {
                qteEscudo--;
                Destroy(escudoAtual);
                timerEscudo = 0f;
            }
        }
    }
    // Criando os tiros com base no tipo de tiro recebido
    private void CriaTiro(GameObject playerTiro, Vector3 pos)
    {
        GameObject Tiro;
        Tiro = Instantiate(playerTiro, pos, transform.rotation);
        Tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
        SoundFX[0].Play();
    }
    // Destruindo player caso ele perda todas as vidas e reiniciando o jogo
    public void PlayerLife(int dano)
    {
        lifePlayer -= dano;
        vidaDisplay.fillAmount = lifePlayer;
        if (lifePlayer <= 0)
        {
            Destroy(gameObject);
            Destroy(escudoAtual);
            Instantiate(Morte, transform.position, transform.rotation);
        }
    }
    // Colisão com o PowerUp
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PowerUp"))//Recompensa PowerUp
        {
            levelTiro++;
            Destroy(collision.gameObject);
            SoundFX[3].Play();
            if (levelTiro >= 5)
            {
                levelTiro = 5;
            }
            if (qteEscudo <= 0)
            {
                qteEscudo = 3;
            }
        }
        if (collision.CompareTag("Life"))//Recompensa Vida
        {
            lifePlayer += 2;
            Destroy(collision.gameObject);
            SoundFX[3].Play();
        }
        if (collision.CompareTag("Escudo"))//Recompensa Escudo
        {

        }
        if (collision.CompareTag("Special"))//Recompensa Special
        {

        }
    }
}
