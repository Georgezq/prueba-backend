public class ProductoFilter
{
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 10;
    public string? Global { get; set; }
    public string? SortField { get; set; }
    public int SortOrder { get; set; }
    public List<int>? TypeBodega { get; set; }
    public DateTime? FechaIngresada { get; set; }

}
