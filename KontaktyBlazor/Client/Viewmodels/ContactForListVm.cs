using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KontaktyBlazor.Client.Viewmodels
{
    public class ContactForListVm 
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
    }
}
