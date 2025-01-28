using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class jigsawPuzzle : MonoBehaviour{
[Header("Game Elements")]
[Range(2,6)]
[SerializeField] private int difficulty = 4;
[SerializeField] private Transform gameHolder;
[SerializeField] private Transform piecePrefab;

[SerializeField] private float var;
[SerializeField] private Texture2D imageTexture;
[SerializeField] private Transform mainImage;
[SerializeField] private Camera camera;
[SerializeField] private float remainingTime;
[SerializeField] private TextMeshProUGUI timerText;

private List<Transform> pieces;
private Vector2Int dimensions; 
private Vector3 offset = Vector3.zero;
float width;
float height;
private Transform draggingPiece = null;

    // Start is called before the first frame update
    void Start()
    {
        mainImage.gameObject.SetActive(false);
        pieces = new List<Transform>();
        dimensions = GetDimensions(imageTexture, difficulty); //função que retorna dimensão da imagem em peças (quantas na horizontal, quantas na vertical)
        CreateJigsawPieces(imageTexture); //cria peças com suas devidas proporções e texturas
        Scatter();
        UpdateBorder(); //cria uma borda de fundo para o quebra cabeça
    }

    private void UpdateBorder(){
        LineRenderer line = gameHolder.GetComponent<LineRenderer>();

        //dividir altura/largura para dimensionar line renderer
        float halfHeight = (height * dimensions.y)/2;
        float halfWidth = (width * dimensions.x)/2;

        float borderz = 0.0f; //deixar borda sempre atrás das peças

        //dimensionando borda
        line.SetPosition(0, new Vector3(-halfWidth+var, halfHeight, borderz));
        line.SetPosition(1, new Vector3(halfWidth+var, halfHeight, borderz));
        line.SetPosition(2, new Vector3(halfWidth+var, -halfHeight, borderz));
        line.SetPosition(3, new Vector3(-halfWidth+var, -halfHeight, borderz));

        //altera tamanho da borda
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;

        //mostra borda
        line.enabled = true;
    }

    private void Scatter(){
        float orthoHeight = camera.orthographicSize; //orthographic size = (altura da câmera/2)
        float camAspect = (float) Screen.width / Screen.height; //proporção de largura para altura
        float orthoWidth = camAspect * orthoHeight; //calculo para medir orthographic width utilizada (largura/2)

        float pieceWidth = width * gameHolder.localScale.x;
        float pieceHeight = height * gameHolder.localScale.y;

        orthoHeight -= (pieceHeight/2 + pieceHeight/6); //ajusta tamanhos para peças caberem na tela
        orthoWidth -= (pieceWidth/2 + pieceWidth/8);

        //espalhar peças de forma aleatória
        foreach (Transform piece in pieces){
            float x = Random.Range(-orthoWidth, -orthoWidth/3);
            float y = Random.Range(-orthoHeight, orthoHeight);
            piece.position = new Vector3(x, y, -1);
        }

    }

    private void Snap(){
        int pieceIdx = pieces.IndexOf(draggingPiece); //seleciona peça no array de peças
        
        int col = pieceIdx % dimensions.x;
        int row = pieceIdx / dimensions.x;

        Vector2 targetPosition = new((-width * dimensions.x / 2) + (width * col) + (width/2) + var,
                                    (-height * dimensions.y / 2) + (height * row) + (height/2)); //guarda posição final da peça

        if(Vector2.Distance(draggingPiece.localPosition, targetPosition) < (width/2)){ //define espaço para aceitar o encaixe da peça
            //trava peça no local correto
            draggingPiece.localPosition = targetPosition;

            //desabilita movimento de peça já encaixada corretamente
            draggingPiece.GetComponent<BoxCollider2D>().enabled = false;
        }

    }

    void CreateJigsawPieces(Texture2D imageTexture){
        height = 1f/dimensions.y;
        float aspect = (float) (imageTexture.width/imageTexture.height);
        width = aspect/dimensions.x;

        for(int row = 0; row < dimensions.x; row++){    //iterando pelas linhas e colunas, índices de cada peça
            for(int col = 0; col < dimensions.y; col++){
                //criando peças do tamanho e posições corretos
                Transform piece = Instantiate(piecePrefab, gameHolder); //cria intancia(ou cópia) de uma piecePrefab, filha de gameHolder
                piece.localPosition = new Vector3(
                    (-width * dimensions.x/2) + (width * col) + (width/2), //1 - instancia célula no local inicial da linha correto / 2 - move célula de acordo com a coluna / 3 - centraliza objeto na célula
                    (-height * dimensions.y/2) + (height * row) + (height/2),
                    -1
                );
                piece.localScale = new Vector3(width, height, 1f);

                //nome dado para facilitar debug
                piece.name = $"Piece {(row * dimensions.x) + col}"; 
                pieces.Add(piece); //adiciona peças na lista de peças

                //acertando textura de cada peça do jogo
                //precisamos normalizar width e height para utilização de coordenadas uv
                float width1 = 1f/dimensions.x;
                float height1 = 1f/dimensions.y;
                //ordenação dos pontos uv é: (0,0), (1,0), (1,0), (1,1)
                Vector2[] uv = new Vector2[4];
                uv[0] = new Vector2(width1 * col, height1 * row);
                uv[1] = new Vector2(width1 * (col + 1), height1 * row);
                uv[2] = new Vector2(width1 * col, height1 * (row + 1));
                uv[3] = new Vector2(width1 * (col + 1), height1 * (row + 1));
                // atribuir os uvs para mesh
                Mesh mesh = piece.GetComponent<MeshFilter>().mesh;
                mesh.uv = uv;
                piece.GetComponent<MeshRenderer>().material.SetTexture("_MainTex", imageTexture);
            }
        }
    }

    Vector2Int GetDimensions(Texture2D imageTexture, int difficulty){
        Vector2Int dimensions = Vector2Int.zero;
        if(imageTexture.height > imageTexture.width){ //aproximar todas as peças a um formato quadrado
            dimensions.x = difficulty;
            dimensions.y = (difficulty * imageTexture.height) / imageTexture.width;
        } else{
            dimensions.y = difficulty;
            dimensions.x = (difficulty * imageTexture.width) / imageTexture.height;
        }
        return dimensions;
    }

    /*void Temporizer(){
        if(remainingTime > 0){
            remainingTime -= Time.deltaTime;
        }
        else{
            remainingTime = 0;
        }
        remainingTime -= Time.deltaTime;
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }*/

    // Update is called once per frame
    void Update()
{
    // Calcula dimensões da câmera ortográfica
    float orthoHeight = Camera.main.orthographicSize; // Altura da câmera (metade)
    float camAspect = (float)Screen.width / Screen.height; // Proporção largura/altura
    float orthoWidth = camAspect * orthoHeight; // Largura da câmera (metade)

    // Posição do mouse no mundo
    Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    // Arrastar a peça ao clicar
    if (Input.GetMouseButtonDown(0))
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit)
        {
            draggingPiece = hit.transform; // Seleciona o objeto
            offset = draggingPiece.position - mousePosition; // Calcula offset
            draggingPiece.position += Vector3.back; // Move para frente na camada
        }
    }

    // Soltar a peça ou verificar limites
    if (draggingPiece != null)
    {
        draggingPiece.position = mousePosition + offset;

            Vector3 clampedPosition = draggingPiece.position;
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, -orthoWidth + (width / 2), orthoWidth - (width / 2));
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, -orthoHeight + (height / 2), orthoHeight - (height / 2));
            draggingPiece.position = clampedPosition;

            if (Input.GetMouseButtonUp(0))
            {
                Snap();
                draggingPiece.position += Vector3.forward;
                draggingPiece = null;
            }
    }
}

}
