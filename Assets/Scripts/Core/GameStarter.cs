using UnityEngine;
using Asteroids.Services;
using UnityEngine.InputSystem;

namespace Asteroids.Game
{
    internal sealed class GameStarter : MonoBehaviour
    {
        [SerializeField] Camera mainCamera;

        private UpdateService _updateService;
        private GameLoader _gameLoader;
        private Inputs input;

        private StartPanelView _startPanelView;
        private EndPanelView _endPanelView;
        private void Awake()
        {
            input = new Inputs();
            _updateService = new UpdateService();

            StartGameMenu();
        }
        private void StartGameMenu()
        {
            _startPanelView = Instantiate(Resources.Load<StartPanelView>("UI/CanvasStartPanel"));
            _endPanelView = Instantiate(Resources.Load<EndPanelView>("UI/CanvasEndPanel"));
            _endPanelView.gameObject.SetActive(false);

            input.MainMenu.Enable();
            input.MainMenu.Start.performed += StartGameLevel;
        }
        private void StartGameLevel(InputAction.CallbackContext context)
        {
            input.MainMenu.Start.performed -= StartGameLevel;
            input.MainMenu.Disable();
            _startPanelView.gameObject.SetActive(false);
            _endPanelView.gameObject.SetActive(false);

            LoadGame();
        }
        private void LoadGame()
        {
            _gameLoader = new GameLoader(_updateService, input, EndGameLevel, mainCamera);
            _gameLoader.LoadGame();
        }
        private void EndGameLevel(int points)
        {
            _endPanelView.gameObject.SetActive(true);
            _endPanelView.scoreValue.text = points.ToString();

            input.MainMenu.Enable();
            input.MainMenu.Start.performed += StartGameLevel;
        }
        private void Update()
        {
            _updateService.Update();
        }
        private void FixedUpdate()
        {
            _updateService.FixedUpdate();
        }
        private void LateUpdate()
        {
            _updateService.LateUpdate();
        }
    }
}
