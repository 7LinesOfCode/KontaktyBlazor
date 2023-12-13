using KontaktyBlazor.Client.DTO;
using KontaktyBlazor.Client.Interfaces;
using KontaktyBlazor.Client.Viewmodels;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace KontaktyBlazor.Client.Services
{
    public class ContactService : IContactService
    {
        private readonly HttpClient _httpClient;
        private readonly NavigationManager _navigationManager;

        public ContactService(HttpClient http, NavigationManager navigationManager)
        {
            _httpClient = http;
            _navigationManager = navigationManager;
        }

        public async Task<ListContactForListVm> GetListContactForListVm()
        {
            var result = await _httpClient.GetFromJsonAsync<ListContactForListVm>("/Get/Contacts");
            return result;
        }

        public async Task<List<CategoryVm>> GetCategoryList()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<CategoryVm>>("/Get/Categories");
            return result.ToList();
        }

        public async Task<List<SubCategoryVm>> GetSubCategoryList()
        {
            var result = await _httpClient.GetFromJsonAsync<IEnumerable<SubCategoryVm>>("/Get/SubCategories");
            return result.ToList();
        }

        public async Task<ListContactForListVm> PostListContactForListVm(int pageSize, int pageNo, string searchString, int? selectedCategoryId)
        {
            // Utwórz obiekt, który chcesz wysłać w zapytaniu POST
            var contactsPageDTO = new ContactsPageDTO 
            { 
                pageNo = pageNo,
                PageSize= pageSize,
                SearchString = searchString,
                SelectedCategoryId = selectedCategoryId
            };

            // Wykonaj zapytanie POST i pobierz odpowiedź
            var response = await _httpClient.PostAsJsonAsync("/Post/Contacts", contactsPageDTO);

            // Sprawdź, czy zapytanie zakończyło się sukcesem (status HTTP 200)
            if (response.IsSuccessStatusCode)
            {
                // Pobierz odpowiedź jako tekst
                var responseContent = await response.Content.ReadAsStringAsync();

                // Deserializuj tekst do oczekiwanej struktury
                var result = JsonSerializer.Deserialize<ListContactForListVm>(responseContent, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true // Ustawienia deserializacji, możesz dostosować do potrzeb
                });

                return result;
            }
            else
            {
                return null;
            }
        }

        public async Task<ContactDetailsVm> GetContactDetails(int id)
        {
            var result = await _httpClient.GetFromJsonAsync<ContactDetailsVm>($"/Get/Contact/{id}");
            return result;
        }

        public async Task DeleteContact(int id)
        {
            var result = await _httpClient.DeleteAsync($"/Delete/Contact/{id}");
        }

        public async Task<int> CreateNewSubCategory(string newSubCatName)
        {
            SubCategoryVm newSubCat = new SubCategoryVm();
            newSubCat.Name = newSubCatName;
            newSubCat.CategoryId = 3;

            try
            {
                var response = await _httpClient.PostAsJsonAsync("/New/SubCategory", newSubCat);

                if (response.IsSuccessStatusCode)
                {
                    int resultId = await response.Content.ReadFromJsonAsync<int>();
                    return resultId;
                }
                else
                {
                    return -1; 
                }
            }
            catch (Exception)
            {
                
                return -1; 
            }
        }

        public async Task CreateNewContact(ContactDetailsVm newContact)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync("/New/Contact", newContact);
                
            }
            catch (Exception)
            {

            }
        }

        public async Task UpdateContact(ContactDetailsVm newContact)
        {
            try
            {
                var response = await _httpClient.PutAsJsonAsync($"Edit/Contact/{newContact.Id}", newContact);
            }
            catch (Exception) { }
        }
    }
}
