using PB08.Dto;

namespace PB08.Interfaces
{
    public interface IHistoryService
    {
        HistoryDto GetHistory(int pageIndex);

        bool DeleteEntry(int entryId, int userId);
    }
}
