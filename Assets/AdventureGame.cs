using UnityEngine;
using UnityEngine.UI;

public class AdventureGame : MonoBehaviour
{
    
    [SerializeField] HexVerticalMinesweeper hexVertical;
    [SerializeField] Text textComponent;
    [SerializeField] Image imageComponent;
    [SerializeField] State startingState;
    [SerializeField] Player player;
    State state;
      bool endStory;
    public void Start()
    {
        state = startingState;
        textComponent.text = state.GetStateStory();
        imageComponent.sprite = state.GetStateStoryImage(); 
    }


    private void Update()
    {
        ManageState(); 
    }
 

    public void StoryButton(int noYes)
    {
        
        var nextStates = state.GetNextStates();
        if (noYes == 0)
        {
            state = nextStates[0];
            GetStoryBuff();
        }
        if (noYes == 1)
        {
            state = nextStates[1];
            GetStoryBuff();
        }
        textComponent.text = state.GetStateStory();
    } 
    private void GetStoryBuff()
    {
        player.currentHealth -= state.GetPlayerHPMinus();
        player.currentHealth += state.GetPlayerHPPlus();
        endStory = state.GetEndStory();
    }

    private void ManageState()
    {
        textComponent.text = state.GetStateStory();
        imageComponent.sprite = state.GetStateStoryImage();
        endStory = state.GetEndStory();
        if (endStory == true)
        {
            hexVertical.ConinueGame();
        }
        endStory = false;
       
    }


}
