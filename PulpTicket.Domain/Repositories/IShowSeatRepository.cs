using PulpTicket.Domain.Entities;


namespace PulpTicket.Domain.Repositories
{
    public interface IShowSeatRepository
    {
        Task<ShowSeat> GetByIdAsync(Guid showSeatId);
        Task<IEnumerable<ShowSeat>> GetAllAsync();
        Task AddAsync(ShowSeat showSeat);
        Task UpdateAsync(ShowSeat showSeat);
        Task DeleteAsync(Guid showSeatId);
    }
}
