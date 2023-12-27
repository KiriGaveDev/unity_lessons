using Character;
using System;


namespace Presenter.CharacterPresenter
{
    public sealed class CharacterExperiencePresenter : ICharacterExperiencePresenter, IDisposable
    {
        public event Action<int> OnExperienceChanged;
        public event Action OnLevelUp;

        public int CurrentExperience => _playerLevel.CurrentExperience;
        public int RequiredExperience => _playerLevel.RequiredExperience;

        public string Level => GetLevelText();

        public string ExperienceText => GetExperienceText();

        private readonly CharacterLevel _playerLevel;


        public CharacterExperiencePresenter(CharacterLevel playerLevel)
        {
            _playerLevel = playerLevel;

            _playerLevel.OnExperienceChanged += PlayerLevel_OnExperienceChanged;
            _playerLevel.OnLevelUp += PlayerLevel_OnLevelUp;
        }


        public string GetExperienceText()
        {
            return $"XP : {CurrentExperience} / {RequiredExperience}";
        }

        public string GetLevelText()
        {
            return $"Level {_playerLevel.CurrentLevel}";
        }


        public void Dispose()
        {
            _playerLevel.OnExperienceChanged -= PlayerLevel_OnExperienceChanged;
            _playerLevel.OnLevelUp -= PlayerLevel_OnLevelUp;
        }


        private void PlayerLevel_OnLevelUp()
        {
            OnLevelUp?.Invoke();
        }


        private void PlayerLevel_OnExperienceChanged(int value)
        {
            OnExperienceChanged?.Invoke(value);
        }
    }
}
