using System.Collections.Generic;

namespace FilmWishlist.Models
{
    public class GetFilmsResult
    {
        public RepositoryResult Result { get; set; }
        public IEnumerable<FilmEntity> Value { get; set; }

        public static GetFilmsResult Unsuccessful() => new GetFilmsResult{Result = RepositoryResult.Failed};
        public static GetFilmsResult Success(IEnumerable<FilmEntity> films) => new GetFilmsResult{Result = RepositoryResult.Successful, Value = films};
    }
}