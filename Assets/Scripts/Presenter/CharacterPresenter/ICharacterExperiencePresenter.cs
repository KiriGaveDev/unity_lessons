using Presenter;
using System;


namespace Presenter.CharacterPresenter
{
    public interface ICharacterExperiencePresenter : IPresenter
    {
        public int CurrentExperience { get; }
        public int RequiredExperience { get; }
        public string ExperienceText { get; }
        public string Level { get; }

        event Action<int> OnExperienceChanged;
        event Action OnLevelUp;
    }
}
