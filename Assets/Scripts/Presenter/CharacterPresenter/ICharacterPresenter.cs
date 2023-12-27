namespace Presenter.CharacterPresenter
{
    public interface ICharacterPresenter : IPresenter
    {
        public ICharacterInfoPresenter InfoPresenter { get; }
        public ICharacterExperiencePresenter ExperiencePresenter { get; }
        public ICharacterStatsPresenter StatsPresenter { get; }     
    }
}
