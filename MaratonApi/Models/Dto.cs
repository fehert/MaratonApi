namespace MaratonApi.Models
{
    public record GetFemaleDto(string? Fnev,int? Szulev );
    public record GetRunnersDto(string? Fnev, int? Eletkor );
    public record BestRunnersDto(string? Fnev,int? Korido);
}
