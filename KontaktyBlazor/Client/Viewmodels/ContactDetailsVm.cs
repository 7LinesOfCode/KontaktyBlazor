using static System.Runtime.InteropServices.JavaScript.JSType;

namespace KontaktyBlazor.Client.Viewmodels
{
    public class ContactDetailsVm
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDay { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }

    }
}
