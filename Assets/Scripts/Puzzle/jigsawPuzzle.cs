using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsawPuzzle : MonoBehaviour{
[Header("Game Elements")]
[Range(2,6)]
[SerializeField] private int difficulty = 4;
[SerializeField] private Transform gameHolder;
[SerializeField] private Transform piecePrefab;

[SerializeField] private Texture2D imageTexture;
[SerializeField] private Transform mainImage;
[SerializeField] private Camera camera;

private List<Transform> pieces;
private Vector2Int dimensions; 
float width;
float height;

    // Start is called before the first frame update
    void Start()
    {
        mainImage.gameObject.SetActive(false);
        pieces = new List<Transform>();
        dimensions = GetDimensions(imageTexture, difficulty); //função que retorna dimensão da imagem em peças (quantas na horizontal, quantas na vertical)
        CreateJigsawPieces(imageTexture); //cria peças com suas devidas proporções e texturas
        Scatter();
    }

    private void Scatter(){
        float orthoHeight = camera.orthographicSize; //orthographic size = (altura da câmera/2)
        float camAspect = (float) Screen.width / Screen.height; //proporção de largura para altura
        float orthoWidth = camAspect * orthoHeight; //calculo para medir orthographic width utilizada (largura/2)

        float pieceWidth = width * gameHolder.localScale.x;
        float pieceHeight = height * gameHolder.localScale.y;

        orthoHeight = orthoHeight -= pieceHeight/2; //ajusta tamanhos para peças caberem na tela
        orthoWidth = orthoWidth -= pieceWidth/2;

        //espalhar peças de forma aleatória
        foreach (Transform piece in pieces){
            float x = Random.Range(-orthoWidth, orthoWidth);
            float y = Random.Range(-orthoHeight, orthoHeight);
            piece.position = new Vector3(x, y, -1);
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
