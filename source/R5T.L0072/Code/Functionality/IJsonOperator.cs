using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

using R5T.T0132;


namespace R5T.L0072
{
    /// <summary>
    /// JSON operator built around System.Text.Json functionality.
    /// </summary>
    /// <remarks>
    /// JSON functionality in .NET was previously through the Json.NET third-party library.
    /// This was crazy, since the official ASP.NET Core framework actually depended on the third-party Json.NET library!
    /// As of .NET Core 3.0 (see <inheritdoc cref="Links.ForSysmteTextJsonFrameworkAvailability" path="/summary"/>),
    /// JSON functionality in .NET has been brought into the framework.
    /// </remarks>
    [FunctionalityMarker]
    public partial interface IJsonOperator : IFunctionalityMarker
    {
        public async Task<JsonDocument> Deserialize_AsJsonDocument(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(
                jsonFilePath);

            var output = await JsonDocument.ParseAsync(fileStream);
            return output;
        }

        public async Task<JsonElement> Deserialize_AsJsonElement(string jsonFilePath)
        {
            using var document = await this.Deserialize_AsJsonDocument(jsonFilePath);

            // Always return a clone of the element you want, since the JsonDocument is disposable.
            var output = document.RootElement.Clone();
            return output;
        }

        public JsonSerializerOptions Get_Options_Standard()
        {
            var output = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            return output;
        }

        public Task Serialize(
            string jsonFilePath,
            JsonElement element)
        {
            var options = this.Get_Options_Standard();

            return this.Serialize(
                jsonFilePath,
                element,
                options);
        }

        public async Task Serialize(
            string jsonFilePath,
            JsonElement element,
            JsonSerializerOptions options)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            await JsonSerializer.SerializeAsync(
                fileStream,
                element,
                options);
        }

        public T Load_FromFile_Synchronous<T>(string jsonFilePath)
        {
            var jsonText = Instances.FileOperator.Read_Text_Synchronous(jsonFilePath);

            var output = JsonSerializer.Deserialize<T>(jsonText);
            return output;
        }

        public async Task<T> Load_FromFile<T>(string jsonFilePath)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Read(jsonFilePath);

            var output = await JsonSerializer.DeserializeAsync<T>(fileStream);
            return output;
        }

        //public async Task<T> Load_FromFile<T>(
        //    string jsonFilePath,
        //    string key)
        //{
        //    var rootElement = await this.Deserialize_AsJsonElement(jsonFilePath);

        //    var element = rootElement.GetProperty(key);

        //    var output = element.Deserialize<T>();
        //    return output;
        //}

        public async Task<T> Load_FromFile<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = await Instances.FileOperator.Read_Text(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        public T Load_FromFile_Synchronous<T>(
            string jsonFilePath,
            string objectKey)
        {
            var jsonText = Instances.FileOperator.Read_Text_Synchronous(jsonFilePath);

            var rootElement = JsonSerializer.Deserialize<JsonElement>(jsonText);

            var keyedElement = rootElement.GetProperty(objectKey);

            var output = keyedElement.Deserialize<T>();
            return output;
        }

        public T Load_FromString<T>(string jsonString)
        {
            var output = JsonSerializer.Deserialize<T>(jsonString);
            return output;
        }

        public JsonArray New_Array(IEnumerable<JsonNode> nodes)
            => this.New_Array(nodes.ToArray());

        public JsonArray New_Array(params JsonNode[] nodes)
            => new(nodes);

        public JsonObject New_Object()
            => new();

        public void Save_ToFile_Synchronous<T>(
            string jsonFilePath,
            T value)
        {
            using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            JsonSerializer.Serialize(
                fileStream,
                value);
        }

        public async Task Save_ToFile<T>(
            string jsonFilePath,
            T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            // "await using" because file steam is IAsyncDisposable.
            await using var fileStream = Instances.FileStreamOperator.Open_Write(
                jsonFilePath);

            await JsonSerializer.SerializeAsync(
                fileStream,
                value,
                options);
        }

        public string Save_ToString<T>(T value)
        {
            var options = new JsonSerializerOptions
            {
                WriteIndented = true,
            };

            var output = JsonSerializer.Serialize(
                value,
                options);

            return output;
        }
    }
}
