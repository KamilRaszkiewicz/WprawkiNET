using PB09.Dto;

namespace PB09.Interfaces
{
    public interface IHistoryService
    {
        HistoryDto GetHistory(int pageIndex);

        bool DeleteEntry(int entryId, int userId);
    }
}
