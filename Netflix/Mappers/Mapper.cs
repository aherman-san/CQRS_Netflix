using Netflix.Database.Entities;
using Netflix.DTOS;

namespace Netflix.Mappers;

public static class Mapper
{
    public static CardMovieDto ToCardMovieDto(this Movie entity)
    {
        return new CardMovieDto
        {
            Id = entity.Id,
            Title = entity.Title.Length >= 50 ? $"{entity.Title.Substring(0, 50)} ..." : entity.Title,
            Image = entity.Image,
        };
    }

    public static CategoryDto ToCategoryDto(this Category entity)
    {
        return new CategoryDto
        {
            Id = entity.Id,
            Name = entity.Name,
        };
    }
}
