namespace BusinessLayer.Common
{
    public interface IDateManager
    {
        bool CheckDateConflictingInterval(DateTime dateFrom, DateTime dateTo, DateTime dateCheckFrom, DateTime dateCheckTo);
    }
}
