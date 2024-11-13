namespace UILogic.Loading
{
    using System;
    using DG.Tweening;
    using Model.LocalData.Base;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class LoadingScreenController : MonoBehaviour
    {
        public  Slider loadingSlider;
        private void Start()
        {
            LocalDataManager.Instant.LoadAllLocalData();
            this.FakeLoading();
        }

        private void FakeLoading()
        {
            this.loadingSlider.DOValue(1, 1f).SetEase(Ease.Linear).onComplete += this.OnFakeLoadingComplete;
        }

        private void OnFakeLoadingComplete()
        {
            SceneManager.LoadScene("MainScene", LoadSceneMode.Single);
        }
    }
}