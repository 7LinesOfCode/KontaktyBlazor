using KontaktyBlazor.Client.Viewmodels;

namespace KontaktyBlazor.Client.Interfaces
{
    public interface IContactService
    {
        Task<List<SubCategoryVm>> GetSubCategoryList();
        Task<List<CategoryVm>> GetCategoryList();
        Task<ListContactForListVm> GetListContactForListVm();
        Task<ListContactForListVm> PostListContactForListVm(int pageSize, int pageNo, string searchString, int? selectedCategoryId);
        Task<ContactDetailsVm> GetContactDetails(int id);
        Task DeleteContact(int id);
        Task<int> CreateNewSubCategory(string newSubCatName);
        Task CreateNewContact(ContactDetailsVm newContact);
        Task UpdateContact(ContactDetailsVm newContact);
    }
}
