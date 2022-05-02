
using UnityEngine;
[CreateAssetMenu(menuName = "State")]
public class State : ScriptableObject
{

    public bool storyEnd;
    [SerializeField] Sprite storyTextSprite;
    [TextArea(14, 10)]
    [SerializeField] string storyText;
    [SerializeField] State[] nextStates;
    [SerializeField] int playerMihusHp;
    [SerializeField] int playerHPPlus;

    public string GetStateStory()
    {
        return storyText;
    }
    public Sprite GetStateStoryImage()
    {
        return storyTextSprite;
    }
    public State[] GetNextStates()
    {
        return nextStates;
    }
    public int GetPlayerHPMinus()
    {
        return playerMihusHp;
    }
    public int GetPlayerHPPlus()
    {
        return playerHPPlus;
    }
    public bool GetEndStory()
    {
        return storyEnd;
    }



}
