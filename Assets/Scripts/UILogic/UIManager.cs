namespace UILogic
{
    using Extension;
    using UILogic.Gameplay;
    using UILogic.Home;
    using UnityEngine;

    public class UIManager : SingletonMono<UIManager>
    {
        public GameEndPopupController   gameEndPopupController;
        public GameplayScreenController gameplayScreenController;
        public MainScreenController     mainScreenController;
        
        private void DeActiveAll()
        {
            this.mainScreenController.gameObject.SetActive(false);
            this.gameEndPopupController.gameObject.SetActive(false);
            this.gameplayScreenController.gameObject.SetActive(false);
        }

        public void ActiveHomeScreen()
        {
            this.DeActiveAll();
            this.mainScreenController.gameObject.SetActive(true);
        }
        public void ActiveGameplayScreen()
        {
            this.DeActiveAll();
            this.gameplayScreenController.gameObject.SetActive(true);
        }

        public void ActiveGameEndScreen()
        {
            this.DeActiveAll();
            this.gameEndPopupController.gameObject.SetActive(true);
        }
    }
}