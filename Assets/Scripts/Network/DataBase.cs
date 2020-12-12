using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Amazon;
using Amazon.CognitoIdentity;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;

public class DataBase : MonoBehaviour
{
    DynamoDBContext context;
    AmazonDynamoDBClient DBClient;
    CognitoAWSCredentials credentials;

    public InputField idInput;
    public InputField passInput;
    public Text invalidText;
    public Text CreateText;
    public InputField createID;
    public InputField createPass;

    private bool isCreatePanelOn;

    private void Awake()
    {
        UnityInitializer.AttachToGameObject(gameObject);
        credentials = new CognitoAWSCredentials("ap-northeast-2:48d7b34a-8723-41ff-a872-da35c8eaa049", RegionEndpoint.APNortheast2);
        DBClient = new AmazonDynamoDBClient(credentials, RegionEndpoint.APNortheast2);
        context = new DynamoDBContext(DBClient);
    }

    [DynamoDBTable("Login")]
    public class Player
    {
        [DynamoDBHashKey]
        public string ID { get; set; }
        [DynamoDBProperty]
        public string Password { get; set; }
    }

    public void AuthorizeButton()
    {
        FindItem(idInput.text, passInput.text);
    }

    public void CreateCharacter()
    {
        if (createID.text != null && createPass.text != null)
        {
            Player player = new Player
            {
                ID = createID.text,
                Password = createPass.text,
            };
            context.SaveAsync(player, (result) =>
            {
                if (result.Exception == null)
                {
                    CreateText.text = "Create " + createID.text + " on Database";
                    CreateText.enabled = true;
                    Invoke("CreateTextDelete", 2.0f);
                }
                else
                    Debug.Log(result.Exception);
            });
        }
    }

    public void FindItem(string id, string pass)
    {
        Player player;

        context.LoadAsync<Player>(id, (AmazonDynamoDBResult<Player> result) =>
        {
            if(result.Result != null)
            {
                player = result.Result;
            }
            else
            {
                invalidText.enabled = true;
                Invoke("TextDelete", 2.0f);
                Debug.Log("ID not autorized");
                return;
            }

            if (player.ID != id)
            {
                invalidText.enabled = true;
                Invoke("TextDelete", 2.0f);
                Debug.Log("password not autorized");
                return;
            }
            else if(player.Password != pass)
            {
                invalidText.enabled = true;
                Invoke("TextDelete", 2.0f);
                Debug.Log("password not autorized");
                return;
            }
            else
            {
                GameManager.Instance.SceneChange("Matchmaking");
            }
        }, null);
    }

    void TextDelete()
    {
        invalidText.enabled = false;
    }

    void CreateTextDelete()
    {
        CreateText.enabled = false;
    }
}
