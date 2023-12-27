using Character;
using System.Collections.Generic;


namespace Presenter.CharacterPresenter
{
    public interface ICharacterPresenter : IPresenter
    {
        public ICharacterInfoPresenter CharacterInfoPresenter { get; }
        public ICharacterExperiencePresenter ExperiencePresenter { get; }
        public HashSet<CharacterStat> CharacterStats { get; }
    }
}
