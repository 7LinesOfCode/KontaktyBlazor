namespace KontaktyBlazor.Client.DTO
{
    public class ContactsPageDTO
    {
        public int PageSize { get; set; }
        public int? pageNo { get; set; }
        public string? SearchString { get; set; }
        public int? SelectedCategoryId { get; set; }
    }
}
