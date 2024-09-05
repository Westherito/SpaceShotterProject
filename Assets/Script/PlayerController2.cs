
using UnityEngine;
public class PlayerController2 : PlayerFatherController
{
    [SerializeField] private PlayerInputActions PlayerControl;

    private void OnEnable()
    {
        PlayerControl.Enable();
        PlayerControl.Player.Movimento.Enable();
        PlayerControl.Player.Fire.Enable();
        PlayerControl.Player.Shield.Enable();
    }
    private void OnDisable()
    {
        PlayerControl.Disable();
        PlayerControl.Player.Movimento.Disable();
        PlayerControl.Player.Fire.Disable();
        PlayerControl.Player.Shield.Disable();
    }

    // Start is called before the first frame update
    void Awake()
    {
        PlayerControl = new PlayerInputActions();
        lifePlayer = lifeMax;
    }
    // Update is called once per frame
    void Update()
    {
        vidaDisplay.fillAmount = ((float)lifePlayer / (float)lifeMax);
        EscudoDisplay.text = qteEscudo.ToString();
        MovimentoPlayer();
        EscudoPlayer();
        TirosPlayer();
    }
    // Movimentação
    public void MovimentoPlayer()
    {

        // Pegando o Input do usuário e adicionando velocidade
        movPlayer = PlayerControl.Player.Movimento.ReadValue<Vector2>();
        //movPlayer.x = Input.GetAxis("Horizontal");
        //movPlayer.y = Input.GetAxis("Vertical");
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
    public void EscudoPlayer()
    {
        if (PlayerControl.Player.Shield.IsPressed())
            if (qteEscudo > 0)
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
    // Criando os tiros do player
    public void TirosPlayer()
    {
        if (PlayerControl.Player.Fire.IsPressed())
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
    // Criando os tiros com base no tipo de tiro recebido
    private void CriaTiro(GameObject playerTiro, Vector3 pos)
    {
        GameObject Tiro;
        Tiro = Instantiate(playerTiro, pos, transform.rotation);
        Tiro.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, velTiro);
        SoundFX[0].Play();
    }
}
