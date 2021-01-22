namespace Valenia.Verity.Context
{
    public interface IContextRepository
    {
        Context Load();
        void Add(Context entity);
    }
}
