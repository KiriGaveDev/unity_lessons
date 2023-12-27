using Character;
using System.Collections.Generic;


namespace Presenter.CharacterPresenter
{
    public interface ICharacterStatsPresenter : IPresenter
    {
        public HashSet<CharacterStat> CharacterStats { get; }
    }

}
