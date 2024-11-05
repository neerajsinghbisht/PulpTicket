using AutoMapper;
using PulpTicket.Application.DTOs;
using PulpTicket.Application.Interfaces;
using PulpTicket.Domain.Entities;
using PulpTicket.Domain.Repositories;


namespace PulpTicket.Application.Services
{
    public class MovieServices : IMovieService
    {
        
    private readonly IMovieRepository _movieRepository;
    private readonly IMapper _mapper;

    public MovieServices(IMovieRepository movieRepository, IMapper mapper)
    {
        _movieRepository = movieRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<MovieDtos>> GetAllAsync(string? filterOn = null, string? filterQuery = null, string? sortBy = "Name",
    bool isDescending = false, int pageNumber=1,int pageSize=1000)

    {
        var movie = await _movieRepository.GetAllAsync(filterOn,filterQuery,sortBy,isDescending,pageNumber,pageSize);
        return _mapper. Map<IEnumerable<MovieDtos>>(movie);
    }
    public async Task<MovieDtos> GetMovieByIdAsync(Guid MovieId)
    {
     var movie = await _movieRepository.GetByIdAsync(MovieId);
        return _mapper.Map<MovieDtos>(movie);
    }

      
        public async Task<MovieDtos> CreateMovieAsync(MovieDtos movieDtos)
        {
            var movies= _mapper.Map<Movie>(movieDtos);
            await _movieRepository.AddAsync(movies);
            return _mapper.Map<MovieDtos>(movies);
        }

        //public async Task UpdateMovieAsync(MovieDtos MovieDtos)
        //{
        //    var movie = _mapper.Map<Movie>(MovieDtos);
        //      await _movieRepository.UpdateAsync(movie);
        //}
        public async Task DeleteMovieAsync(Guid MovieId)
        {
            await _movieRepository.DeleteAsync(MovieId);
        }





    }
}
