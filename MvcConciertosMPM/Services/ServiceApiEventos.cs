﻿using MvcConciertosMPM.Models;
using System.Net.Http.Headers;

namespace MvcConciertosMPM.Services
{
    public class ServiceApiEventos
    {
        private string UrlApi;
        private MediaTypeWithQualityHeaderValue header;
        public ServiceApiEventos(KeysModels keys)
        {
            this.UrlApi = keys.ApiConciertos;
            this.header = new MediaTypeWithQualityHeaderValue
                ("application/json");

        }
        private async Task<T> CallApiAsync<T>(string request)
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(this.header);
                HttpResponseMessage response =
                    await client.GetAsync(this.UrlApi + request);
                if (response.IsSuccessStatusCode)
                {
                    T data = await response.Content.ReadAsAsync<T>();
                    return data;
                }
                else
                {
                    return default(T);
                }
            }
        }
        public async Task<List<Evento>> GetEventosAsync()
        {
            string request = "api/eventos";
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasAsync()
        {
            string request = "api/categoriaeventos";
            List<CategoriaEvento> data =
                await this.CallApiAsync<List<CategoriaEvento>>(request);
            return data;
        }
        public async Task<List<Evento>>
            FindEventos(int id)
        {
            string request = "api/eventos/" + id;
            List<Evento> data =
                await this.CallApiAsync<List<Evento>>(request);
            return data;
        }




    }
}
