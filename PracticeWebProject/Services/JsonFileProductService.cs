using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using PracticeWebProject.Models;
using Microsoft.AspNetCore.Hosting;
using System.Text;

namespace PracticeWebProject.Services
{
    public class JsonFileProductService
    {
        public IWebHostEnvironment WebHostEnvironment { get; }

        private string JsonFileName => Path.Combine(WebHostEnvironment.WebRootPath, "Data", "Products.json");

        public JsonFileProductService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IEnumerable<Product> GetProducts()
        {
            using var jsonFileReader = File.OpenText(JsonFileName);
            return JsonSerializer.Deserialize<Product[]>(jsonFileReader.ReadToEnd(),
                new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public void AddRating(string productId, int rating)
        {
            var products = GetProducts();

            //LINQ
            var query = products.First(x => x.ID == productId);

            if (query.Ratings == null)
            {
                query.Ratings = new int[] {rating};
            }
            else
            {
                var ratings = query.Ratings.ToList();
                ratings.Add(rating);
                query.Ratings = ratings.ToArray();
            }

            using (var outputStream = File.OpenWrite(JsonFileName)) 
            {
                JsonSerializer.Serialize<IEnumerable<Product>>(
                    new Utf8JsonWriter(outputStream, new JsonWriterOptions
                    {
                        SkipValidation = true,
                        Indented = true
                    }),
                    products
                );
            }
        }
    }
}