﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SignalR.Restaurant.Web.UI.Dtos.CategoryDtos;
using SignalR.Restaurant.Web.UI.Dtos.ContactDtos;
using System.Text;

namespace SignalR.Restaurant.Web.UI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.GetAsync("https://localhost:7195/api/Contact");
            if (responsemessage.IsSuccessStatusCode)
            {
                var jsonData = await responsemessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultContactDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7195/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<IActionResult> DeleteContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsemessage = await client.DeleteAsync($"https://localhost:7195/api/Contact/{id}");
            if (responsemessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> UpdateContact(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync($"https://localhost:7195/api/Contact/{id}");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateContactDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateContactDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7195/api/Contact", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
