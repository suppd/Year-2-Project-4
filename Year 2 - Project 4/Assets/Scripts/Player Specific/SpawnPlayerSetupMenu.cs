
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;


public class SpawnPlayerSetupMenu : MonoBehaviour
{
    //prefabs
    public GameObject playerSetupMenuPrefab;
    public GameObject playerSpriteSetupMenuPrefab;

    public PlayerInput playerInput;


    public GameObject spriteMenu;
    public GameObject menu;

    public Button button;
    public InputField inputField;



    private void Awake()
    {       
        var rootMenu = GameObject.Find("MainUI");
        var rootMenu2 = GameObject.Find("SpritesUI");
        if (rootMenu != null)
        {
            menu = Instantiate(playerSetupMenuPrefab, rootMenu.transform);
            playerInput.uiInputModule = menu.GetComponentInChildren<InputSystemUIInputModule>();
            Debug.Log(playerInput.playerIndex);
            menu.GetComponent<PlayerSetupMenuController>().SetPlayerIndex(playerInput.playerIndex);
        }
        if (rootMenu2.transform.childCount == 0)
        {
            spriteMenu = Instantiate(playerSpriteSetupMenuPrefab, rootMenu2.transform);
            AssignVariables();
        }
        else
        {
            spriteMenu = GameObject.FindGameObjectWithTag("SpriteBox");
            AssignVariables();
        }
    }
    public void AssignVariables()
    {
        inputField = menu.GetComponentInChildren<InputField>();
        button = spriteMenu.GetComponentInChildren<Button>();
        inputField.navigation = ChangeNavigation(inputField.navigation, button);
        button.navigation = ChangeNavigation(button.navigation, inputField);
    }
    private Navigation ChangeNavigation(Navigation nav, Selectable button) // make method to avoid code repition 
    {
        nav.selectOnUp = button;
        nav.selectOnLeft = button;
        nav.selectOnRight = button;
        nav.selectOnDown = button;
        return nav;
    }
}
