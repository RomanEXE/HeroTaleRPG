using GameStates;
using UnityEngine;

namespace UI
{
    public class ButtonsVisibility : MonoBehaviour
    {
        [SerializeField] private GameObject[] idleButtons;
        [SerializeField] private GameObject[] fightButtons;
        
        private void OnDestroy()
        {
            GameState.IdleState.IdleStateStarted -= OnIdleStateStarted;
            GameState.FightState.FightStarted -= OnFightStarted;
        }

        public void Init()
        {
            GameState.IdleState.IdleStateStarted += OnIdleStateStarted;
            GameState.FightState.FightStarted += OnFightStarted;
        }

        private void OnIdleStateStarted()
        {
            ShowButtons(idleButtons);
            HideButtons(fightButtons);
        }
        
        private void OnFightStarted()
        {
            ShowButtons(fightButtons);
            HideButtons(idleButtons);
        }
        
        private void ShowButtons(GameObject[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(true);
            }
        }

        private void HideButtons(GameObject[] buttons)
        {
            for (int i = 0; i < buttons.Length; i++)
            {
                buttons[i].SetActive(false);
            }  
        }
    }
}