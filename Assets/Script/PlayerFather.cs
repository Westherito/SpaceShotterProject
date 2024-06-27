
using UnityEngine;
using UnityEngine.UI;
public class PlayerFatherController : MonoBehaviour
{
    [SerializeField] protected AudioSource[] SoundFX;
    // Movimentação
    [SerializeField] private Rigidbody2D rbPlayer;
    private Vector2 movPlayer;
    [SerializeField] private float vel;
    // Tiros do Player
    [SerializeField] protected float timerBullet = 0.1f;
    [SerializeField] protected GameObject tiros;
    [SerializeField] protected GameObject tiros2;
    protected float velTiro = 10f;
    [SerializeField] protected int levelTiro = 1;
    // Escudo do player
    [SerializeField] private GameObject escudo;
    private GameObject escudoAtual;
    private float timerEscudo = 0f;
    [SerializeField] protected int qteEscudo = 3;
    // Vida do player
    protected int lifePlayer;
    [SerializeField] private GameObject Morte;
    // Limite de tela
    [SerializeField] private float xMin, yMin, xMax, yMax;
    // Mostrando as informações do player
    [SerializeField] protected Text EscudoDisplay;
    [SerializeField] protected Image vidaDisplay;
    [SerializeField] protected int lifeMax;

    // Movimentação
    protected void MovimentoPlayer()
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
    // Método do escudo
    protected void EscudoPlayer()
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
        }
        if (collision.CompareTag("Life"))//Recompensa Vida
        {
            lifePlayer += 2;
            Destroy(collision.gameObject);
            SoundFX[3].Play();
        }
        if (collision.CompareTag("Escudo"))//Recompensa Escudo
        {
            Destroy(collision.gameObject);
            SoundFX[3].Play();
            if (qteEscudo == 0)
            {
                qteEscudo = 3;
            }
        }
        if (collision.CompareTag("Special"))//Recompensa Special
        {
            Destroy(collision.gameObject);
            levelTiro = 5;
            lifePlayer = 10;
            qteEscudo = 3;
            SoundFX[3].Play();
        }
    }
}
